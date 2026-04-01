using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECoffee.Application.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUnitOfWork _uow;
        private readonly string _currentUser;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork uow, IUserContext userContext)
        {
            _menuRepository = menuRepository;
            _uow = uow;
            _currentUser = userContext.IsAuthenticated ? userContext.Email : "system";
        }

        public Task<List<MenuResponse>> FindAllAsync(string? keyword = null)
            => Task.FromResult(_menuRepository.FindAll(keyword));

        public MenuResponse FindById(long id)
            => _menuRepository.FindById(id) ?? throw new NotFoundException("Món không tồn tại trong hệ thống");

        public async Task CreateAsync(CreateMenuRequest request)
        {
            Validate(request);
            _menuRepository.Create(request, _currentUser);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(long id, UpdateMenuRequest request)
        {
            Validate(request);
            if (_menuRepository.FindById(id) == null) throw new NotFoundException("Món không tồn tại trong hệ thống");
            _menuRepository.Update(id, request, _currentUser);
            await _uow.SaveChangesAsync();
        }

        public async Task ToggleAvailabilityAsync(long id)
        {
            if (_menuRepository.FindById(id) == null) throw new NotFoundException("Món không tồn tại trong hệ thống");
            _menuRepository.ToggleAvailability(id, _currentUser);
            await _uow.SaveChangesAsync();
        }

        private static void Validate(CreateMenuRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new BadRequestException("Tên món không được để trống");
            if (string.IsNullOrWhiteSpace(request.CategoryName))
                throw new BadRequestException("Loại nước không được để trống");
            if (request.SmallPrice < 0 || request.MediumPrice < 0 || request.LargePrice < 0)
                throw new BadRequestException("Giá không được âm");
            if (request.QuantityAvailable < 0)
                throw new BadRequestException("Số lượng tồn không được âm");
            if (request.ReorderLevel < 0)
                throw new BadRequestException("Mức nhập lại không được âm");
        }
    }
}
