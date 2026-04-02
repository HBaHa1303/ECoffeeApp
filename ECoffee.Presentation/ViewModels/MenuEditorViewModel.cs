namespace ECoffee.Presentation.ViewModels
{
    public class MenuEditorViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public decimal PriceSmall { get; set; }
        public decimal PriceMedium { get; set; }
        public decimal PriceLarge { get; set; }
        public int QuantityAvailable { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
