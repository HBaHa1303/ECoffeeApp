using System.Text;
using System.Threading.Tasks;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations; // Namespace chứa AppDbContext
using System.Collections.Generic;
using System.Linq;
using ECoffee.Infrastructure.Entities;

namespace ECoffee.Infrastructure.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _context;

        public ShiftRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Shift> GetAll()
        {
            return _context.Shifts.Select(e => new Shift
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
            //return _context.Set<Shift>().Find(id);
            var e = _context.Shifts.Find(id);
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

        public void Add(Shift shift)
        {

            var entity = new ShiftEntity
            {
                UserId = shift.UserId,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                OpeningCash = shift.OpeningCash,
                ClosingCash = shift.ClosingCash,
                Status = (ShiftStatus)shift.Status // Ép kiểu về Enum của Entity
            };
            _context.Shifts.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
