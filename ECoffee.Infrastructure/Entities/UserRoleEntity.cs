using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Entities
{
    public class UserRoleEntity
    {
        public long UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public long RoleId { get; set; }
        public RoleEntity Role { get; set; } = null!;
    }
}
