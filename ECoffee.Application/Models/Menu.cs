using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Models
{
   public class Menu : BaseDomain
    {
        public string Name { get; set; } = null!;

        public decimal Price {  get; set; }
        public int CategoryId { get; set; }
        public ICollection<MenuPrice> Prices { get; set; } = new List<MenuPrice>();
    }
}
