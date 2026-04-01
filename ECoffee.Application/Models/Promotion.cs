using ECoffee.Application.DTOs.Request;
using ECoffee.Application.Enums;
using ECoffee.Application.Exceptions;
namespace ECoffee.Application.Models
{
    public class Promotion : BaseDomain
    {
        public decimal? DiscountPercent { get; private set; }
        public decimal? DiscountAmount { get; private set; }
        public string Name { get; private set; }
        public PromotionType Type { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public PromotionStatus Status { get; private set; }

        public Promotion(decimal? discountPercent, decimal? discountAmount, string name, PromotionType type, DateTime startDate, DateTime endDate, PromotionStatus status)
        {
            DiscountPercent = discountPercent;
            DiscountAmount = discountAmount;
            Name = name;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        public static Promotion Hibrid(long id, decimal? discountPercent, decimal? discountAmount, string name, PromotionType type, DateTime startDate, DateTime endDate, PromotionStatus status)
        {
            var promotion = new Promotion(discountPercent, discountAmount, name, type, startDate, endDate, status);
            promotion.Id = id;
            return promotion;
        }

        public static Promotion Create(CreatePromotionRequest request)
        {
            return new Promotion(request.DiscountPercent, request.DiscountAmount, request.Name, request.Type, request.StartDate, request.EndDate, PromotionStatus.Activate);
        }

        public void ChangeDiscountPercent(decimal? discountPercent) {
            if (discountPercent <= 0) {
                throw new BadRequestException("Phần trăm giảm giá phải lớn hơn 0");
            }
            DiscountPercent = discountPercent;
        }

        public void ChangeDiscountAmount(decimal? discountAmount)
        {
            if (discountAmount <= 0)
            {
                throw new BadRequestException("Tổng tiền giảm giá phải lớn hơn 0");
            }
            DiscountAmount = discountAmount;
        }

        public void ChangeType (PromotionType type)
        {
            Type = type;
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new BadRequestException("Tên không được để trống");
            }
            Name = name;
        }

        public void Inactive()
        {
            Status = PromotionStatus.Inactive;
        }

        public void Active()
        {
            Status = PromotionStatus.Activate;
        }

        public void ChangeStartDate(DateTime startDate) { 
            StartDate = startDate;
        }

        public void ChangeEndDate(DateTime endDate) {
            EndDate = endDate;
        }
    }
}
