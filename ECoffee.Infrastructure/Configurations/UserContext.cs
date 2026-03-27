using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Configurations
{
    public class UserContext : IUserContext
    {
        private UserResponse? _currentUser;

        public UserResponse? CurrentUser => _currentUser;

        public bool IsAuthenticated => _currentUser != null;

        public void SetCurrentUser(UserResponse user)
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        public void Clear()
        {
            _currentUser = null;
        }

        public bool HasRole(string roleName)
        {
            if (_currentUser == null) return false;
            return _currentUser.Roles.Contains(roleName);
        }
    }
}
