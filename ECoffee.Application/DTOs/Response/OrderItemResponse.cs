using ECoffee.Application.Models;

namespace ECoffee.Application.DTOs.Response
{
    public class OrderItemResponse
    {
        public string MenuName { get; set; }

        public MenuSize Size { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
