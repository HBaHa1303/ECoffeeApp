using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Request
{
    public class KdsOrderDto
    {
        public long OrderId { get; set; } 
        public string OrderNumber => $"#{OrderId}";
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<KdsItemDto> Items { get; set; } = new(); 
    }

    public class KdsItemDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } 
    }
}
