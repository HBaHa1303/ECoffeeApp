using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Models
{
    public class MenuPrice
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string? Size { get; set; }
        public decimal Price { get; set; }
    }
}
