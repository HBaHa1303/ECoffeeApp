using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Models
{
    public class Order : BaseDomain
    {
        public long UserId {  get; set; }
        public long ShiftId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Submitted;
        public List<OrderItem> Items { get; set; } = new();

        public decimal CalculateTotal()
        {
            return Items.Sum(x => x.UnitPrice * x.Quantity);
        }
    }

    public class OrderItem
    {
        public long MenuId {  get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public MenuSize Size { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
