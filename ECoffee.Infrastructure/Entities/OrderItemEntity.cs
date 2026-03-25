using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        public long OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;

        public long MenuId { get; set; }
        public MenuEntity Menu { get; set; } = null!;

        public MenuSize Size { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
