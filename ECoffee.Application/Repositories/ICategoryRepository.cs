using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;

namespace ECoffee.Application.Repositories;

public interface ICategoryRepository
{
    Category? GetById(long id);
    List<CategoryResponse> GetAll();

    void Save(Category category);
    void Update(Category category);
    CategoryResponse? ProjectionFindById(long id);
    List<CategoryResponse> FindAllByNameAsync(string keyword);
    List<CategoryResponse> FindAllActiveAsync();
}
