using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Infrastructure.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly AppDbContext _db;

        public PromotionRepository(AppDbContext db) {
            _db = db;
        }

        public List<PromotionResponse> FindAll()
        {
            return _db.Promotions
                .Select(u => u.Adapt<PromotionResponse>())
                .ToList();
        }

        public List<PromotionResponse> FindAllByName(string name)
        {
            return _db.Promotions
                .Where(u => u.Name.Contains(name))
                .Select(u => u.Adapt<PromotionResponse>())
                .ToList();
        }

        public Promotion? FindById(long id)
        {
            var entity = _db.Promotions
                .FirstOrDefault(p => p.Id == id);

            return entity == null
                ? null
                : Promotion.Hibrid(
                    entity.Id,
                    entity.DiscountPercent,
                    entity.DiscountAmount,
                    entity.Name,
                    entity.Type,
                    entity.StartDate,
                    entity.EndDate,
                    entity.Status);
        }

        public PromotionResponse? ProjectionFindById(long id)
        {
            return _db.Promotions
                .Where(u => u.Id == id)
                .Select(u => u.Adapt<PromotionResponse>())
                .FirstOrDefault();
        }

        public void Save(Promotion newPromotion)
        {
            _db.Promotions.Add(newPromotion.Adapt<PromotionEntity>());
        }


        public void Update(long id, Promotion promotion)
        {
            PromotionEntity promotionEntity = _db.Promotions.Where(p => p.Id == id).First();
            promotionEntity.DiscountPercent = promotion.DiscountPercent;
            promotionEntity.DiscountAmount = promotion.DiscountAmount;
            promotionEntity.Status = promotion.Status;
            promotionEntity.StartDate = promotion.StartDate;
            promotionEntity.EndDate = promotion.EndDate;
            promotionEntity.UpdatedAt = promotion.UpdatedAt;
            promotionEntity.UpdatedBy = promotion.UpdatedBy;
            promotionEntity.Type = promotion.Type;
            promotionEntity.Name = promotion.Name;
        }
    }
}
