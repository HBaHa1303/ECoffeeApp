using ECoffee.Application.Enums;
using ECoffee.Application.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Response
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Email { get;  set; }
        public string FullName { get;  set; }
        public string Address { get;  set; }
        public DateOnly DateOfBirth { get;  set; }
        public UserStatus Status { get; set; }
        public List<string> Roles { get;  set; }

        public string StatusText =>
        Status switch
        {
            UserStatus.Activate => "Hoạt động",
            UserStatus.Locked => "Bị khóa",
            _ => ""
        };
    }
}
