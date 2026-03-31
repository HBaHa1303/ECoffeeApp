using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Repositories
{
    
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        
        public OrderRepository(AppDbContext db)
        {
            _db = db;
            
        }

        public void Add(Order order)
        {
            var entity = order.Adapt<OrderEntity>();

            entity.TotalAmount = order.CalculateTotal();

            _db.Orders.Add(entity);
        }
            
    public void SaveChanges()
        {
            _db.SaveChanges();
        }


        public Order? GetById(long id)
        {
            
            var entity = _db.Orders
                            .Include(o => o.Items) 
                            .FirstOrDefault(o => o.Id == id);

            return entity?.Adapt<Order>();
        }

        public void Update(Order order)
        {
            
            var entity = order.Adapt<OrderEntity>();

            _db.Orders.Update(entity);
            _db.SaveChanges();
        }
        public IEnumerable<Order> GetAll()
        {
            // Phải lấy từ _db.Orders
            return _db.Orders.ProjectToType<Order>().ToList();
        }
        
    }

    
}
