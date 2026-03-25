using ECoffee.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application
{
    public interface IUserRepository
    {
        User? FindByEmail(string Email);
    }
}
