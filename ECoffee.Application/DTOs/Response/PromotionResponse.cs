using ECoffee.Application.Enums;
namespace ECoffee.Application.Models
{
    public class PromotionResponse : BaseDomain
    {
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string Name { get; set; } = null!;
        public PromotionType Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public PromotionStatus Status { get; set; }

        public string StatusText => 
            Status switch
        {
            PromotionStatus.Activate => "Hoạt động",
            PromotionStatus.Inactive => "Bị khóa",
            _ => ""
        };

        public string TypeText =>
            Type switch
            {
                PromotionType.Percent => "Percent",
                PromotionType.BuyXGetYFree => "BuyXGetYFree",
                PromotionType.FixedAmount => "FixedAmount",
                _ => ""
            };
    }
}
