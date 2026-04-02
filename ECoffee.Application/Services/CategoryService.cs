using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;

namespace ECoffee.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repo;
    private readonly IUnitOfWork _uow;

    public CategoryService(
        ICategoryRepository repo,
        IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task CreateAsync(string name)
    {
        var category = Category.Create(name);

        _repo.Save(category);
        await _uow.SaveChangesAsync();
    }

    public async Task RenameAsync(long id, string name)
    {
        var category = _repo.GetById(id)
            ?? throw new NotFoundException("Category không tồn tại");

        category.Rename(name);

        _repo.Update(category);
        await _uow.SaveChangesAsync();
    }

    public async Task ToggleStatusAsync(long id)
    {
        var category = _repo.GetById(id)
            ?? throw new NotFoundException("Category không tồn tại");

        if (category.Status == CategoryStatus.Active)
            category.Inactivate();
        else
            category.Activate();

        _repo.Update(category);
        await _uow.SaveChangesAsync();
    }


    public async Task<CategoryResponse> FindByIdAsync(long id)
    {
        return _repo.ProjectionFindById(id) ?? throw new NotFoundException("Category không tồn tại");
    }

    public async Task<List<CategoryResponse>> FindAllAsync()
    {
        return _repo.GetAll(); 
    }

    public async Task<List<CategoryResponse>> FindAllActiveAsync()
    {
        return await _repo.FindAllActiveAsync();
    }

    public async Task InactiveAsync(long id)
    {
        var category = _repo.GetById(id) ?? throw new NotFoundException("Category không tồn tại");

        category.Inactivate();

        _repo.Update(category);
        await _uow.SaveChangesAsync();
    }

    public async Task ActiveAsync(long id)
    {
        var category = _repo.GetById(id) ?? throw new NotFoundException("Category không tồn tại");

        category.Activate();

        _repo.Update(category);
        await _uow.SaveChangesAsync();
    }


    public async Task<List<CategoryResponse>> FindAllByNameAsync(string keyword)
    {
        return _repo.FindAllByNameAsync(keyword);
    }

    public async Task<List<CategoryResponse>> FindAllActiveAsync()
    {
        // Gọi xuống repo để lấy danh sách Active
        return await _repo.FindAllActiveAsync();
    }
}