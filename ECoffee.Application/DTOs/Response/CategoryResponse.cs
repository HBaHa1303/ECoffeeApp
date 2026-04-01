using ECoffee.Application.Enums;

namespace ECoffee.Application.DTOs.Response;

public sealed class CategoryResponse
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public CategoryStatus Status { get; set; }

    public string StatusText =>
        Status switch
        {
            CategoryStatus.Active => "Hoạt động",
            CategoryStatus.Inactive => "Ngưng",
            _ => Status.ToString()
        };

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}