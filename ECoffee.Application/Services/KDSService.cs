using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECoffee.Application.Models;

namespace ECoffee.Application.Services
{
    public class KdsService
    {
        private readonly IOrderRepository _repo;
        private readonly IUserRepository _userRepo; // Thêm repo này
        private readonly IShiftRepository _shiftRepo;

        public KdsService(IOrderRepository repo, IUserRepository userRepo, IShiftRepository shiftRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _shiftRepo = shiftRepo;
        }

        public List<KdsOrderDto> GetOrdersForDisplay()
        {
            // Tương tự cho phần danh sách món đang đợi
            var orders = _repo.GetActiveOrders();

            return orders.Select(o => new KdsOrderDto
            {
                OrderId = o.Id,
                CreatedAt = o.CreatedAt,
                Status = o.Status.ToString(),
                Items = o.Items.Select(i => new KdsItemDto
                {
                    ProductName = string.IsNullOrEmpty(i.ProductName) ? "Món chưa đặt tên" : i.ProductName,
                    Quantity = i.Quantity,
                    // ĐẢM BẢO DÒNG NÀY CÓ TRONG CODE:
                    Note = i.Note ?? "",
                    SizeName = i.Size.ToString()
                }).ToList()
            }).ToList();
        }


        public string GetCurrentShiftName()
        {
            var hour = DateTime.Now.Hour;
            if (hour >= 6 && hour < 14) return "Ca Sáng";
            if (hour >= 14 && hour < 22) return "Ca Chiều";
            return "Ca Tối/Đêm";
        }


        // Trong KdsService.cs
        public long GetCurrentShiftId()
        {
            var now = DateTime.Now;

            // Dùng GetAll() từ IShiftRepository
            var activeShift = _shiftRepo.GetAll()
                .FirstOrDefault(s => now >= s.StartTime && (s.EndTime == null || now <= s.EndTime));

            if (activeShift != null) return activeShift.Id;

            // Dùng FindAll() từ IUserRepository
            var firstUser = _userRepo.FindAll().FirstOrDefault();
            if (firstUser == null) return 0;

            // Tạo ca mới dùng Model Shift
            var newShift = new Shift
            {
                UserId = firstUser.Id,
                StartTime = now,
                Status = 0, // Trạng thái mở
                OpeningCash = 0
            };

            _shiftRepo.Add(newShift);
            _shiftRepo.SaveChanges();

            return newShift.Id;
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
            // Repo hiện tại đã trả về List<KdsOrderDto> rồi, nên chỉ cần return hoặc xử lý thêm nếu muốn
            var orders = _repo.GetOrdersByStatus(status);

            // Đảm bảo Note không bị null trước khi gửi lên UI
            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    item.Note = item.Note ?? "";
                }
            }

            return orders;
        }
    }
}
