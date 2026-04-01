using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECoffee.Application.Repositories
{
    public interface IMenuRepository
    {
        List<MenuResponse> FindAll(string? keyword = null);
        MenuResponse? FindById(long id);
        void Create(CreateMenuRequest request, string audit);
        void Update(long id, UpdateMenuRequest request, string audit);
        void ToggleAvailability(long id, string audit);
    }
}
