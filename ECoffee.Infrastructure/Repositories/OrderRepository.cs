using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Enums;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using ECoffeeBE.Infrastructure.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

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



        /// KDS
        //public IEnumerable<Order> GetActiveOrders()
        //{
        //    var entities = _db.Orders
        //        .Include(o => o.Items)
        //            .ThenInclude(i => i.Menu) // Nối từ OrderItems sang Menus để lấy tên món
        //        .Where(o => o.Status == ECoffee.Infrastructure.Entities.OrderStatus.Submitted
        //                 || o.Status == ECoffee.Infrastructure.Entities.OrderStatus.Paid)
        //        .ToList();

        //    return entities.Adapt<IEnumerable<Order>>();
        //}


        public IEnumerable<Order> GetActiveOrders()
        {
            var entities = _db.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Menu) // Quan trọng: Phải nạp bảng Menu
                .Where(o => o.Status == OrderStatus.Submitted || o.Status == OrderStatus.Paid)
                .ToList();

            // Map thủ công để đảm bảo Items không bị rỗng và có ProductName
            return entities.Select(e => new Order
            {
                Id = e.Id,
                Status = (OrderStatus)e.Status, // Ép kiểu Enum nếu cần
                CreatedAt = e.CreatedAt,
                Items = e.Items.Select(oi => new OrderItem
                {
                    MenuId = oi.MenuId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    // Lấy Name từ bảng Menu gán vào ProductName của Domain Model
                    ProductName = oi.Menu?.Name ?? "Món không tên",
                    Size = (ECoffee.Application.Models.MenuSize)oi.Size
                }).ToList()
            }).ToList();
        }


        //// ca làm (shift)

        public string GetCurrentShiftName()
        {
            // Lấy ca làm việc có trạng thái là Open
            var currentShift = _db.Shifts
                .Where(s => s.Status == ShiftStatus.Open) 
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefault();

            if (currentShift == null) return "Không trong ca";

            // Dựa vào StartTime để phân biệt Sáng/Tối
            // Nếu mở ca trước 14h (2 giờ chiều) thì coi là ca sáng, ngược lại là ca tối
            return currentShift.StartTime.Hour < 14 ? "Ca sáng" : "Ca tối";
    }



        public List<KdsOrderDto> GetOrdersByStatus(string status)
        {

            // Lấy dữ liệu từ DB (Entities)
            var entities = _db.Orders
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Menu)
                .Where(o => o.Status.ToString() == status)
                .ToList();

            // Dùng Adapt để chuyển sang DTO (Giúp code sạch hơn và tránh lỗi logic Select)
            return entities.Select(e => new KdsOrderDto
            {
                OrderId = e.Id,
                CreatedAt = e.CreatedAt,
                Status = e.Status.ToString(),
                Items = e.Items.Select(oi => new KdsItemDto
                {
                    ProductName = oi.Menu?.Name ?? "Không xác định",
                    Quantity = oi.Quantity,
                    Note = "",// bổ sung sau
                    SizeName = oi.Size.ToString()
                }).ToList()
            }).ToList();
        }

        public void UpdateOrderStatus(long orderId, string status)
        {
            var order = _db.Orders.Find(orderId);

            if (order != null)
            {
                if (Enum.TryParse<OrderStatus>(status, out var newStatus))
                {
                    order.Status = newStatus;
                    _db.SaveChanges();
                }
                else
                {
                    // Thay vì để trống, hãy quăng ra một lỗi để bạn biết đường mà sửa
                    throw new Exception($"Lỗi: Trạng thái '{status}' không tồn tại trong danh sách OrderStatus của hệ thống!");
                }
            }
            else
            {
                // Trường hợp không tìm thấy OrderId trong Database
                throw new Exception($"Lỗi: Không tìm thấy đơn hàng có ID là {orderId} để cập nhật.");
            }
        }
    }


}
