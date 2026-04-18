using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Enums;
using ECoffee.Application.Models; // Dùng cho class Shift (DTO/Model)
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECoffee.Infrastructure.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _db;

        public ShiftRepository(AppDbContext db)
        {
            _db = db;
        }

        // --- NHÓM LOGIC NGHIỆP VỤ (Từ file 1) ---

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
                // TotalRevenue được tính từ tổng các đơn hàng trong ca
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

        // --- NHÓM LOGIC TRUY XUẤT (Từ file 2) ---

        public IEnumerable<Shift> GetAll()
        {
            return _db.Shifts.Select(e => new Shift
            {
                Id = e.Id,
                UserId = e.UserId,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                OpeningCash = e.OpeningCash,
                ClosingCash = e.ClosingCash,
                Status = (int)e.Status
            }).ToList();
        }

        public Shift GetById(long id)
        {
            var e = _db.Shifts.Find(id);
            if (e == null) return null;

            return new Shift
            {
                Id = e.Id,
                UserId = e.UserId,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                OpeningCash = e.OpeningCash,
                ClosingCash = e.ClosingCash,
                Status = (int)e.Status
            };
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        
    }
}