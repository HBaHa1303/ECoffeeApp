using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECoffee.Application.Models;
using ECoffee.Application.DTOs.Response;

namespace ECoffee.Application.Repositories
{
    public interface IShiftRepository
    {
        ShiftResponse? GetOpenShift();
        long OpenShift(long userId, decimal openingCash);
        void CloseShift(long shiftId, decimal closingCash);
        bool HasOpenShift();
        IEnumerable<Shift> GetAll();
        Shift GetById(long id);
        void Add(Shift shift);
        void SaveChanges();
    }
}