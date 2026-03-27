using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) {
            _db = db;
        }

        public List<UserResponse> FindAll()
        {
            return _db.Users
                .Select(u => u.Adapt<UserResponse>())
                .ToList();
        }

        public User? FindByEmail(string email)
        {
            var entity = _db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Email == email);

            if (entity == null)
                return null;

            return User.Rehydrate(
                entity.Id,
                entity.Email,
                entity.PasswordHash,
                null,
                entity.FullName,
                entity.Address,
                entity.DateOfBirth,
                entity.Status,
                entity.UserRoles.Select(x => x.Role.Name),
                entity.CreatedBy,
                entity.UpdatedBy,
                entity.CreatedAt,
                entity.UpdatedAt
            );
        }

        public User? FindById(long id)
        {
            var entity = _db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Id == id);

            if (entity == null)
                return null;

            return User.Rehydrate(
                entity.Id,
                entity.Email,
                entity.PasswordHash,
                null,
                entity.FullName,
                entity.Address,
                entity.DateOfBirth,
                entity.Status,
                entity.UserRoles.Select(x => x.Role.Name),
                entity.CreatedBy,
                entity.UpdatedBy,
                entity.CreatedAt,
                entity.UpdatedAt
            );
        }

        public UserResponse? ProjectionFindById(long id)
        {
            return _db.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Where(u => u.Id == id)
                .Select(u => new UserResponse
                {
                    Id = id,
                    Email = u.Email,
                    Address = u.Address,
                    DateOfBirth = u.DateOfBirth,
                    Status = u.Status,
                    FullName = u.FullName,
                    Roles = u.UserRoles.Select(ur => ur.Role.Name).ToList()
                })
                .FirstOrDefault();
        }

        public void Save(User newUser, List<Role> roles) {
            UserEntity entity = newUser.Adapt<UserEntity>();
            List<UserRoleEntity> userRoles = roles.Select(r => new UserRoleEntity
                {
                    RoleId = r.Id
                }).ToList();
            entity.UserRoles = userRoles;
            _db.Users.Add(entity);
        }

        public void Update(User user)
        {
            var entity = _db.Users
                .Include(u => u.UserRoles)
                .First(u => u.Id == user.Id);

            entity.FullName = user.FullName;
            entity.Address = user.Address;
            entity.DateOfBirth = user.DateOfBirth;
            entity.Status = user.Status;

            var currentRoleNames = entity.UserRoles.Select(ur => ur.Role.Name).ToList();
            var newRoles = user.Roles.Except(currentRoleNames).ToList();
            var removedRoles = currentRoleNames.Except(user.Roles).ToList();


            var toRemove = entity.UserRoles
                .Where(ur => removedRoles.Contains(ur.Role.Name))
                .ToList();

            foreach (var ur in toRemove)
            {
                entity.UserRoles.Remove(ur);
            }

            if (newRoles.Any())
            {
                var roles = _db.Roles.Where(r => newRoles.Contains(r.Name)).ToList();

                foreach (var roleName in newRoles)
                {
                    var roleEntity = roles.First(r => r.Name == roleName);
                    entity.UserRoles.Add(new UserRoleEntity
                    {
                        RoleId = roleEntity.Id,
                        UserId = entity.Id
                    });
                }
            }

            
        }
    }
}
