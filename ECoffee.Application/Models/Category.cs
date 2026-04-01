using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;

namespace ECoffee.Application.Models;

public class Category : BaseDomain
{
    public string Name { get; private set; }
    public CategoryStatus Status { get; private set; }

    private Category(string name, CategoryStatus status)
    {
        Rename(name);
        Status = status;
    }

    // create
    public static Category Create(string name)
        => new(name, CategoryStatus.Active);

    public static Category Rehydrate(
        long id,
        string name,
        CategoryStatus status)
    {
        var category = new Category(name, status);
        category.Id = id;
        return category;
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BadRequestException("Tên category không được rỗng");

        Name = name.Trim();
    }

    public void Activate() => Status = CategoryStatus.Active;

    public void Inactivate() => Status = CategoryStatus.Inactive;
}