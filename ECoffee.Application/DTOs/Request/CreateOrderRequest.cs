using System;
using MenuSize = ECoffee.Application.Models.MenuSize;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Request
{
    public class CreateOrderRequest
    {
        public List<OrderItemRequest> Items { get; set; } = new();
        public long? PromotionId { get; set; }
        public ECoffee.Application.Enums.OrderStatus Status { get; set; }
        public long Id { get; set; }
        public string? Note { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OrderItemRequest
    {
        public long MenuId { get; set; }
        public int Quantity { get; set; }
        public MenuSize Size { get; set; }
        public string? Note { get; set; }
    }
}
