using ECoffee.Application.Enums;

namespace ECoffee.Application.DTOs.Request;

public sealed class CreateCategoryRequest
{
    public string Name { get; set; } = string.Empty;

    public CategoryStatus Status { get; set; }
}