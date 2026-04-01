using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _db;

        public MenuRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<MenuResponse> FindAll(string? keyword = null)
        {
            var query = _db.Menus
                .Include(m => m.Category)
                .Include(m => m.Inventory)
                .Include(m => m.Prices)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(x => x.Name.Contains(keyword) || x.Category.Name.Contains(keyword));
            }

            return query.OrderBy(x => x.Name).AsEnumerable().Select(MapMenu).ToList();
        }

        public MenuResponse? FindById(long id)
        {
            return _db.Menus.Include(m => m.Category).Include(m => m.Inventory).Include(m => m.Prices)
                .Where(m => m.Id == id).AsEnumerable().Select(MapMenu).FirstOrDefault();
        }

        public void Create(CreateMenuRequest request, string audit)
        {
            var category = FindOrCreateCategory(request.CategoryName, audit);
            var now = DateTime.Now;
            var entity = new MenuEntity
            {
                Name = request.Name.Trim(),
                Category = category,
                CreatedAt = now,
                UpdatedAt = now,
                CreatedBy = audit,
                UpdatedBy = audit,
                Inventory = new InventoryEntity
                {
                    QuantityAvailable = request.QuantityAvailable,
                    ReorderLevel = request.ReorderLevel,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = audit,
                    UpdatedBy = audit,
                },
                Prices = BuildPrices(request, audit, now)
            };
            _db.Menus.Add(entity);
        }

        public void Update(long id, UpdateMenuRequest request, string audit)
        {
            var entity = _db.Menus.Include(m => m.Category).Include(m => m.Inventory).Include(m => m.Prices).First(x => x.Id == id);
            var now = DateTime.Now;
            entity.Name = request.Name.Trim();
            entity.Category = FindOrCreateCategory(request.CategoryName, audit);
            entity.UpdatedAt = now;
            entity.UpdatedBy = audit;
            entity.Inventory.QuantityAvailable = request.QuantityAvailable;
            entity.Inventory.ReorderLevel = request.ReorderLevel;
            entity.Inventory.UpdatedAt = now;
            entity.Inventory.UpdatedBy = audit;
            UpsertPrice(entity, MenuSize.Small, request.SmallPrice, audit, now);
            UpsertPrice(entity, MenuSize.Medium, request.MediumPrice, audit, now);
            UpsertPrice(entity, MenuSize.Large, request.LargePrice, audit, now);
        }

        public void ToggleAvailability(long id, string audit)
        {
            var entity = _db.Menus.Include(m => m.Inventory).First(x => x.Id == id);
            var now = DateTime.Now;
            entity.Inventory.QuantityAvailable = entity.Inventory.QuantityAvailable > 0 ? 0 : Math.Max(1, entity.Inventory.ReorderLevel);
            entity.Inventory.UpdatedAt = now;
            entity.Inventory.UpdatedBy = audit;
            entity.UpdatedAt = now;
            entity.UpdatedBy = audit;
        }

        private CategoryEntity FindOrCreateCategory(string categoryName, string audit)
        {
            var normalized = categoryName.Trim();
            var category = _db.Categories.FirstOrDefault(x => x.Name.ToLower() == normalized.ToLower());
            if (category != null) return category;
            category = new CategoryEntity
            {
                Name = normalized,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = audit,
                UpdatedBy = audit
            };
            _db.Categories.Add(category);
            return category;
        }

        private static List<MenuPriceEntity> BuildPrices(CreateMenuRequest request, string audit, DateTime now) => new()
        {
            CreatePrice(MenuSize.Small, request.SmallPrice, audit, now),
            CreatePrice(MenuSize.Medium, request.MediumPrice, audit, now),
            CreatePrice(MenuSize.Large, request.LargePrice, audit, now)
        };

        private static MenuPriceEntity CreatePrice(MenuSize size, decimal price, string audit, DateTime now) => new()
        {
            Size = size,
            Price = price,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedBy = audit,
            UpdatedBy = audit
        };

        private static void UpsertPrice(MenuEntity entity, MenuSize size, decimal price, string audit, DateTime now)
        {
            var menuPrice = entity.Prices.FirstOrDefault(x => x.Size == size);
            if (menuPrice == null)
            {
                entity.Prices.Add(CreatePrice(size, price, audit, now));
                return;
            }
            menuPrice.Price = price;
            menuPrice.UpdatedAt = now;
            menuPrice.UpdatedBy = audit;
        }

        private static MenuResponse MapMenu(MenuEntity entity)
        {
            decimal GetPrice(MenuSize size) => entity.Prices.FirstOrDefault(p => p.Size == size)?.Price ?? 0;
            return new MenuResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                CategoryName = entity.Category?.Name ?? string.Empty,
                SmallPrice = GetPrice(MenuSize.Small),
                MediumPrice = GetPrice(MenuSize.Medium),
                LargePrice = GetPrice(MenuSize.Large),
                QuantityAvailable = entity.Inventory?.QuantityAvailable ?? 0,
                ReorderLevel = entity.Inventory?.ReorderLevel ?? 0,
                IsAvailable = (entity.Inventory?.QuantityAvailable ?? 0) > 0,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
