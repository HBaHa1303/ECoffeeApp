using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Models;
using System;
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

        //kds
        IEnumerable<Order> GetActiveOrders();

        //
        string GetCurrentShiftName();
        // 
        void UpdateOrderStatus(long orderId, string status);
        List<KdsOrderDto> GetOrdersByStatus(string status);
    }
}
