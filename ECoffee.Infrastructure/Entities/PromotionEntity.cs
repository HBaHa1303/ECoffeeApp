using ECoffee.Application.Enums;

namespace ECoffee.Infrastructure.Entities
{
    public class PromotionEntity : BaseEntity
    {
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string Name { get; set; } = null!;
        public PromotionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PromotionStatus Status { get; set; }
    }
}
