namespace ECoffee.Infrastructure.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<MenuEntity> Menus { get; set; } = new List<MenuEntity>();
    }
}
