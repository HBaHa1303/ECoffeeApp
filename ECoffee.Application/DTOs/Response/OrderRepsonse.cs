using ECoffee.Application.Enums;

namespace ECoffee.Application.DTOs.Response
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public string? PromotionName { get; set; }

        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        //public ICollection<OrderItemResponse> Items { get; set; } = new List<OrderItemResponse>();

        public string StatusText =>
            Status switch
            {
                OrderStatus.Cancelled => "Đã hủy",
                OrderStatus.Draft => "Nháp",
                OrderStatus.Paid => "Đã thanh toán",
                OrderStatus.Processing => "Đang thực hiện",
                OrderStatus.Submitted => "Đã chấp nhận",
                OrderStatus.Completed => "Hoàn thành",
                _ => ""
            };
    }
}
