using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using ECoffee.Presentation.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Presentation.Services
{
    public class MenuModuleService
    {
        private readonly AppDbContext _db;

        public MenuModuleService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryEntity>> GetCategoriesAsync()
        {
            return await _db.Categories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<MenuGridItemViewModel>> GetMenuItemsAsync(string? keyword = null)
        {
            var query = _db.Menus
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Prices)
                .Include(x => x.Inventory)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(x => x.Name.Contains(keyword) || x.Category.Name.Contains(keyword));
            }

            var items = await query
                .OrderBy(x => x.Name)
                .Select(x => new MenuGridItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    PriceSmall = x.Prices.Where(p => p.Size == MenuSize.Small).Select(p => (decimal?)p.Price).FirstOrDefault(),
                    PriceMedium = x.Prices.Where(p => p.Size == MenuSize.Medium).Select(p => (decimal?)p.Price).FirstOrDefault(),
                    PriceLarge = x.Prices.Where(p => p.Size == MenuSize.Large).Select(p => (decimal?)p.Price).FirstOrDefault(),
                    QuantityAvailable = x.Inventory != null ? x.Inventory.QuantityAvailable : 0,
                    ReorderLevel = x.Inventory != null ? x.Inventory.ReorderLevel : 0,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            return items;
        }

        public async Task<MenuEditorViewModel?> GetByIdAsync(long id)
        {
            var entity = await _db.Menus
                .Include(x => x.Prices)
                .Include(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return new MenuEditorViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                CategoryId = entity.CategoryId,
                PriceSmall = entity.Prices.FirstOrDefault(p => p.Size == MenuSize.Small)?.Price ?? 0,
                PriceMedium = entity.Prices.FirstOrDefault(p => p.Size == MenuSize.Medium)?.Price ?? 0,
                PriceLarge = entity.Prices.FirstOrDefault(p => p.Size == MenuSize.Large)?.Price ?? 0,
                QuantityAvailable = entity.Inventory?.QuantityAvailable ?? 0,
                ReorderLevel = entity.Inventory?.ReorderLevel ?? 0,
                IsActive = entity.IsActive
            };
        }

        public async Task<long> SaveAsync(MenuEditorViewModel model, string currentUser)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new InvalidOperationException("Tên món không được để trống.");
            }

            if (model.CategoryId <= 0)
            {
                throw new InvalidOperationException("Vui lòng chọn loại nước.");
            }

            if (model.PriceSmall < 0 || model.PriceMedium < 0 || model.PriceLarge < 0)
            {
                throw new InvalidOperationException("Giá tiền không hợp lệ.");
            }

            if (model.QuantityAvailable < 0 || model.ReorderLevel < 0)
            {
                throw new InvalidOperationException("Số lượng tồn không hợp lệ.");
            }

            var now = DateTime.Now;
            MenuEntity entity;

            if (model.Id.HasValue)
            {
                entity = await _db.Menus
                    .Include(x => x.Prices)
                    .Include(x => x.Inventory)
                    .FirstAsync(x => x.Id == model.Id.Value);

                entity.Name = model.Name.Trim();
                entity.CategoryId = model.CategoryId;
                entity.IsActive = model.IsActive;
                entity.UpdatedAt = now;
                entity.UpdatedBy = currentUser;
            }
            else
            {
                entity = new MenuEntity
                {
                    Name = model.Name.Trim(),
                    CategoryId = model.CategoryId,
                    IsActive = model.IsActive,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = currentUser,
                    UpdatedBy = currentUser,
                    Inventory = new InventoryEntity
                    {
                        QuantityAvailable = model.QuantityAvailable,
                        ReorderLevel = model.ReorderLevel,
                        CreatedAt = now,
                        UpdatedAt = now,
                        CreatedBy = currentUser,
                        UpdatedBy = currentUser
                    }
                };

                _db.Menus.Add(entity);
            }

            SavePrice(entity, MenuSize.Small, model.PriceSmall, currentUser, now);
            SavePrice(entity, MenuSize.Medium, model.PriceMedium, currentUser, now);
            SavePrice(entity, MenuSize.Large, model.PriceLarge, currentUser, now);

            if (entity.Inventory == null)
            {
                entity.Inventory = new InventoryEntity
                {
                    QuantityAvailable = model.QuantityAvailable,
                    ReorderLevel = model.ReorderLevel,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = currentUser,
                    UpdatedBy = currentUser
                };
            }
            else
            {
                entity.Inventory.QuantityAvailable = model.QuantityAvailable;
                entity.Inventory.ReorderLevel = model.ReorderLevel;
                entity.Inventory.UpdatedAt = now;
                entity.Inventory.UpdatedBy = currentUser;
            }

            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task ToggleStatusAsync(long id, string currentUser)
        {
            var entity = await _db.Menus.FirstAsync(x => x.Id == id);
            entity.IsActive = !entity.IsActive;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = currentUser;
            await _db.SaveChangesAsync();
        }

        private static void SavePrice(MenuEntity entity, MenuSize size, decimal price, string currentUser, DateTime now)
        {
            var existing = entity.Prices.FirstOrDefault(x => x.Size == size);
            if (existing == null)
            {
                entity.Prices.Add(new MenuPriceEntity
                {
                    Size = size,
                    Price = price,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = currentUser,
                    UpdatedBy = currentUser
                });
            }
            else
            {
                existing.Price = price;
                existing.UpdatedAt = now;
                existing.UpdatedBy = currentUser;
            }
        }
    }
}
