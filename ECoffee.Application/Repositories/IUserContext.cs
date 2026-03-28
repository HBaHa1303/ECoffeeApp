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
        bool IsAuthenticated { get; }

        long UserId { get; }
        string Email { get; }
        string ActiveRole { get; }

        void Set(UserSession session);
        void Clear();

        bool HasRole(string role);
    }
}
