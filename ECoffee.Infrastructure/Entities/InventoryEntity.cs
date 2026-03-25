using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Entities
{
    public class InventoryEntity : BaseEntity
    {
        public long MenuId { get; set; }
        public MenuEntity Menu { get; set; } = null!;

        public int QuantityAvailable { get; set; }
        public int ReorderLevel { get; set; }
    }
}
