using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using Mapster;

namespace ECoffee.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;

        public RoleRepository (AppDbContext db)
        {
            _db = db;
        }

        public List<RoleResponse> FindAll()
        {
            return _db.Roles.Select(r => r.Adapt<RoleResponse>()).ToList();
        }

        public List<Role> GetByNames(List<string> roles)
        {
            return _db.Roles
                .Where(r => roles.Contains(r.Name))
                .Select(r => r.Adapt<Role>())
                .ToList();
        }
    }
}
