using ECoffee.Application;
using ECoffee.Application.Models;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) {
            _db = db;
        }

        public User? FindByEmail(string Email) {
            return _db.Users.Where(u => u.Email == Email)
                .Select(u => u.Adapt<User>())
                .FirstOrDefault();
        }

        public void Save(User user) {
            UserEntity entity = user.Adapt<UserEntity>();
            _db.Users.Add(entity);
            _db.SaveChanges();
        }
    }
}
