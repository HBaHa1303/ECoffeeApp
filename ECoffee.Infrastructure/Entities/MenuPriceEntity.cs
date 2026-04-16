using ECoffee.Application.Models;

namespace ECoffee.Infrastructure.Entities
{
    public class MenuPriceEntity : BaseEntity
    {
        public long MenuId { get; set; }
        public MenuEntity Menu { get; set; } = null!;

        public MenuSize Size { get; set; }
        public decimal Price { get; set; }
    }
}
