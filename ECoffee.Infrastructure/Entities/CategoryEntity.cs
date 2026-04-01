using ECoffee.Application.Enums;

namespace ECoffee.Infrastructure.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public CategoryStatus Status  { get; set; }
        public ICollection<MenuEntity> Menus { get; set; } = new List<MenuEntity>();
    }
}
