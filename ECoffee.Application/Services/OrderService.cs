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
        private readonly IPromotionRepository _promotionRepository;

        public OrderService(IOrderRepository orderRepository, IMenuRepository menuRepository, IPromotionRepository promotionRepository)
        {
            _orderRepository = orderRepository;
            _menuRepository = menuRepository;
            _promotionRepository = promotionRepository;
        }




        public long Create(CreateOrderRequest request, long userId, long shiftId)
        {
            var order = new Order
            {
                //Id = preSelectedId,
                UserId = userId,
                ShiftId = shiftId,
                Status = OrderStatus.Paid,
                PromotionId = request.PromotionId,
                CreatedAt = DateTime.Now, // Tự động lấy giờ hiện tại
                UpdatedAt = DateTime.Now,
                CreatedBy = "System", // Có thể thay bằng tên User nếu muốn
                UpdatedBy = "System",
                //TotalAmount = 0,
                Items = new List<OrderItem>()
            };
            decimal finalAmount = 0;

            // 2. Tính tiền gốc từ Items
            foreach (var itemReq in request.Items)
            {
                var price = _menuRepository.GetPrice(itemReq.MenuId, itemReq.Size);
                finalAmount += price * itemReq.Quantity;
                order.Items.Add(new OrderItem
                {
                    MenuId = itemReq.MenuId,
                    Quantity = itemReq.Quantity,
                    Size = itemReq.Size,
                    UnitPrice = price,
                    Note = itemReq.Note
                });
            }

            if (request.PromotionId.HasValue && request.PromotionId > 0)
            {
                // Sử dụng hàm FindById bạn đã viết trong Repository
                var promo = _promotionRepository.FindById(request.PromotionId.Value);

                if (promo != null)
                {
                    // Gán lại lần nữa cho chắc chắn object order nhận PromotionId
                    order.PromotionId = promo.Id;

                    if (promo.Type == 0) // Giảm theo %
                    {
                        decimal percent = promo.DiscountPercent ?? 0;
                        finalAmount -= (finalAmount * (percent / 100));
                    }
                    else // Giảm theo số tiền cụ thể
                    {
                        decimal amount = promo.DiscountAmount ?? 0;
                        finalAmount -= amount;
                    }
                }
            }
            order.TotalAmount = finalAmount > 0 ? finalAmount : 0;
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
                order.Status = OrderStatus.Paid;
                _orderRepository.Update(order);
                _orderRepository.SaveChanges();
            }
        }
        
        public long GetLastOrderId()
        {
            // Lấy ID cao nhất hiện tại, nếu không có trả về 0
            return _orderRepository.GetLastOrderId();
        }
    }
}
