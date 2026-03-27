using ECoffee.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IUserContext
    {
        UserResponse? CurrentUser { get; }
        bool IsAuthenticated { get; }
        bool HasRole(string roleName);
        void SetCurrentUser(UserResponse user);
        void Clear();
    }
}
