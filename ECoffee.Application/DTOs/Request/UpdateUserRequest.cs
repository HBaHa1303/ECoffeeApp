using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Request
{
    public class UpdateUserRequest
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateOnly DayOfBirth { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
