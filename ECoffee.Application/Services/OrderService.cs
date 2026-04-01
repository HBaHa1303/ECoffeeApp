using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Repositories;
using ECoffee.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECoffee.Application.Enums;

namespace ECoffee.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuRepository _menuRepository;

        public OrderService(IOrderRepository orderRepository, IMenuRepository menuRepository)
        {
            _orderRepository = orderRepository;
            _menuRepository = menuRepository;
        }

        


        public long Create(CreateOrderRequest request, long userId, long shiftId)
        {
            var order = new Order
            {
                UserId = userId,
                ShiftId = shiftId,
                Status = OrderStatus.Submitted,
                CreatedAt = DateTime.Now // Đảm bảo có ngày tạo
            };

            foreach (var itemReq in request.Items)
            {
                var price = _menuRepository.GetPrice(itemReq.MenuId, itemReq.Size);
                order.Items.Add(new OrderItem
                {
                    MenuId = itemReq.MenuId,
                    Quantity = itemReq.Quantity,
                    Size = itemReq.Size,
                    UnitPrice = price
                });
            }

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            return order.Id; // Trả về mã Id vừa được tạo trong DB
        }

        public long GetNextOrderId()
        {
            var orders = _orderRepository.GetAll();
            if (orders == null || !orders.Any()) return 1;

            // Lấy ID lớn nhất trong bảng Orders
            return orders.Max(o => o.Id) + 1;
        }


        public void SendToKitchen(long orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.Status = OrderStatus.Submitted;
                _orderRepository.Update(order);
                _orderRepository.SaveChanges();
            }
        }
    }
}
