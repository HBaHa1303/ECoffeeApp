using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECoffee.Application.Models;
namespace ECoffee.Application.Repositories
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetAll();
        Shift GetById(long id);
        void Add(Shift shift);
        void SaveChanges();
    }
}