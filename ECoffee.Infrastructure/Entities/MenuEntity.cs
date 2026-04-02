namespace ECoffee.Infrastructure.Entities
{
    public class MenuEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public long CategoryId { get; set; }
        public bool IsActive { get; set; } = true;

        public CategoryEntity Category { get; set; } = null!;
        public ICollection<MenuPriceEntity> Prices { get; set; } = new List<MenuPriceEntity>();
        public InventoryEntity Inventory { get; set; } = null!;
    }
}
