using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Entities
{
    public enum MenuSize
    {
        Small,
        Medium,
        Large
    }



    public class MenuPriceEntity : BaseEntity
    {
        public long MenuId { get; set; }
        public MenuEntity Menu { get; set; } = null!;

        public MenuSize Size { get; set; }
        public decimal Price { get; set; }
    }
}
