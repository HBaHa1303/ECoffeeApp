using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IUserRepository
    {
        List<UserResponse> FindAll();
        List<UserResponse> FindAllByName(string name);
        User? FindByEmail(string email);
        User? FindById(long id);
        UserResponse? ProjectionFindById(long id);
        void Save(User newUser, List<Role> roles);
        void Update(User user);
    }
}
