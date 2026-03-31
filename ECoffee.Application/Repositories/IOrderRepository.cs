using System;
using ECoffee.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void SaveChanges();
        Order? GetById(long id);
        void Update(Order order);
        IEnumerable<Order> GetAll();
    }
}
