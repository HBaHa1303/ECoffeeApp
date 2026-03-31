using System;
using ECoffee.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IMenuRepository
    {
        Menu? GetById(long id);

        decimal GetPrice(long menuId, MenuSize size);
        List<Menu> GetAllProducts();
    }
}
