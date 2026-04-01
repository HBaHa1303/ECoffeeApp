using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IRoleRepository
    {
        List<RoleResponse> FindAll();
        List<Role> GetByNames(List<string> roles);
    }
}
