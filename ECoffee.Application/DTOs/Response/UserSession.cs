using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Response
{
    public sealed record UserSession(
        long UserId,
        string Email,
        string ActiveRole,
        IReadOnlyList<string> Roles
    );
}
