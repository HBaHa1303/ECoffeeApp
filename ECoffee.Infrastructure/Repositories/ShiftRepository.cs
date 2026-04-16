using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Enums;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Infrastructure.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _db;

        public ShiftRepository(AppDbContext db)
        {
            _db = db;
        }

        public ShiftResponse? GetOpenShift()
        {
            var entity = _db.Shifts
                .Include(s => s.User)
                .Include(s => s.Orders)
                .FirstOrDefault(s => s.Status == ShiftStatus.Open);

            if (entity == null) return null;

            return new ShiftResponse
            {
                Id = entity.Id,
                UserId = entity.UserId,
                UserName = entity.User.FullName,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                OpeningCash = entity.OpeningCash,
                ClosingCash = entity.ClosingCash,
                TotalRevenue = entity.Orders.Sum(o => o.TotalAmount),
                Status = entity.Status
            };
        }

        public long OpenShift(long userId, decimal openingCash)
        {
            var entity = new ShiftEntity
            {
                UserId = userId,
                StartTime = DateTime.Now,
                OpeningCash = openingCash,
                Status = ShiftStatus.Open,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "system",
                UpdatedBy = "system"
            };

            _db.Shifts.Add(entity);
            _db.SaveChanges();

            return entity.Id;
        }

        public void CloseShift(long shiftId, decimal closingCash)
        {
            var entity = _db.Shifts
                .Include(s => s.Orders)
                .First(s => s.Id == shiftId);

            entity.EndTime = DateTime.Now;
            entity.ClosingCash = closingCash;
            entity.TotalRevenue = entity.Orders.Sum(o => o.TotalAmount);
            entity.Status = ShiftStatus.Closed;
            entity.UpdatedAt = DateTime.Now;

            _db.SaveChanges();
        }

        public bool HasOpenShift()
        {
            return _db.Shifts.Any(s => s.Status == ShiftStatus.Open);
        }
    }
}
