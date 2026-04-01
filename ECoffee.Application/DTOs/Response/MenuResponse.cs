using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Response
{
    public class MenuResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal SmallPrice { get; set; }
        public decimal MediumPrice { get; set; }
        public decimal LargePrice { get; set; }
        public int QuantityAvailable { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsAvailable { get; set; }
        public string StatusText => IsAvailable ? "Available" : "Unavailable";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
