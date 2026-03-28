using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Configurations
{
    public sealed class UserContext : IUserContext
    {
        private UserSession? _session;

        private UserSession Session =>
            _session ?? throw new InvalidOperationException(
                "User is not authenticated");

        public bool IsAuthenticated => _session != null;

        public long UserId => Session.UserId;
        public string Email => Session.Email;
        public string ActiveRole => Session.ActiveRole;
        public IReadOnlyList<string> Roles => _session?.Roles != null ? _session.Roles.ToList().AsReadOnly() : Array.Empty<string>();

        public void Set(UserSession session)
            => _session = session ?? throw new ArgumentNullException(nameof(session));

        public void Clear() => _session = null;

        public bool HasRole(string role)
            => _session?.Roles.Contains(role) ?? false;

    }
}
