using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Services
{
    public class KdsService
    {
        private readonly IOrderRepository _repo;

        public KdsService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<KdsOrderDto> GetOrdersForDisplay()
        {
            var orders = _repo.GetActiveOrders();

            return orders.Select(o => new KdsOrderDto
            {
                OrderId = o.Id,
                CreatedAt = o.CreatedAt,
                Status = o.Status.ToString(),
                // Trong hàm GetOrdersForDisplay()
                Items = o.Items.Select(i => new KdsItemDto
                {
                    // Bỏ phần i.Menu?.Name đi vì Model không có thuộc tính này
                    ProductName = string.IsNullOrEmpty(i.ProductName) ? "Món chưa đặt tên" : i.ProductName,
                    Quantity = i.Quantity,
                    Note = ""
                }).ToList()
            }).ToList();
        }


        public string GetCurrentShiftName()
        {
            // Gọi xuống Repository để lấy tên ca thực tế từ database
            return _repo.GetCurrentShiftName();
        }

        // Trong file KdsService.cs
        public List<KdsOrderDto> GetActiveOrders()
        {
            
            return GetOrdersForDisplay();
        }
        public void UpdateOrderStatus(long orderId, string status)
        {
            // Gọi xuống repository để cập nhật trạng thái trong database
            // Giả sử repository của bạn có hàm UpdateStatus hoặc tương tự
            _repo.UpdateOrderStatus(orderId, status);
        }

        public List<KdsOrderDto> GetOrdersByStatus(string status)
        {
            // Gọi xuống Repository để lấy dữ liệu
            return _repo.GetOrdersByStatus(status);
        }
    }
}
