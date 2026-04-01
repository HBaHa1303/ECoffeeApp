using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db)
    {
        _db = db;
    }

    public List<CategoryResponse> FindAllByNameAsync(string keyword)
    {
        return _db.Categories
            .AsNoTracking()
            .Select(e => new CategoryResponse
            {
                Id = e.Id,
                Name = e.Name,
                Status = e.Status,
            })
            .Where(c => c.Name.Contains(keyword))
            .ToList();
    }

    public List<CategoryResponse> GetAll()
    {
        return _db.Categories
            .AsNoTracking()
            .Select(e => new CategoryResponse
            {
                Id = e.Id,
                Name = e.Name,
                Status = e.Status,
            })
            .ToList();
    }

    public Category? GetById(long id)
    {
        var entity = _db.Categories
            .FirstOrDefault(x => x.Id == id);

        if (entity == null) return null;

        return Category.Rehydrate(
            entity.Id,
            entity.Name,
            entity.Status);
    }

    public CategoryResponse? ProjectionFindById(long id)
    {
        return _db.Categories
            .Where(x => x.Id == id)
            .Select(u => u.Adapt<CategoryResponse>())
            .FirstOrDefault();
    }

    public void Save(Category category)
    {
        var entity = new CategoryEntity
        {
            Name = category.Name,
            Status = category.Status
        };

        _db.Categories.Add(entity);
    }

    public void Update(Category category)
    {
        var entity = _db.Categories.First(x => x.Id == category.Id);

        entity.Name = category.Name;
        entity.Status = category.Status;
        entity.UpdatedAt = category.UpdatedAt;
        entity.UpdatedBy = category.UpdatedBy;
    }
}