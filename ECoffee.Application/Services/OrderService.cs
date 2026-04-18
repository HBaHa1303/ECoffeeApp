using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Repositories;
using ECoffee.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECoffee.Application.Enums;
using ECoffee.Application.DTOs.Response;

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
                //Id = preSelectedId,
                UserId = userId,
                ShiftId = shiftId,
                Status = OrderStatus.Submitted,
                PromotionId = null,
                CreatedAt = DateTime.Now, // Tự động lấy giờ hiện tại
                UpdatedAt = DateTime.Now,
                CreatedBy = "System", // Có thể thay bằng tên User nếu muốn
                UpdatedBy = "System",
                TotalAmount = 0,
                Items = new List<OrderItem>()
            };

            foreach (var itemReq in request.Items)
            {
                var price = _menuRepository.GetPrice(itemReq.MenuId, itemReq.Size);
                order.TotalAmount += price * itemReq.Quantity;

                order.Items.Add(new OrderItem
                {
                    MenuId = itemReq.MenuId,
                    Quantity = itemReq.Quantity,
                    Size = itemReq.Size,
                    UnitPrice = price,
                    Note = itemReq.Note
                });
            }

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return order.Id;
        }

        public async Task<List<OrderResponse>> FindAllByCreatedAtAsync(DateTime from, DateTime to)
        {
            from = from.Date;
            to = to.Date.AddDays(1).AddTicks(-1);
            return _orderRepository.FindAllByCreatedAtAsync(from, to);
        }

        public async Task<List<OrderItemResponse>> FindAllOrderItemById(long orderId)
        {
            return _orderRepository.FindAllOrderItemById(orderId);
        }

        public long GetNextOrderId()
        {
            //var orders = _orderRepository.GetAll();
            //if (orders == null || !orders.Any()) return 1;

            //// Lấy ID lớn nhất trong bảng Orders
            //return orders.Max(o => o.Id) + 1;
            return _orderRepository.GetNextSequenceValue();
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
