using ECoffee.Application.Enums;

namespace ECoffee.Infrastructure.Entities
{
    public class OrderEntity : BaseEntity
    {
        public long UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public long ShiftId { get; set; }
        public ShiftEntity Shift { get; set; } = null!;

        public long? PromotionId { get; set; }
        public PromotionEntity? Promotion { get; set; }

        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItemEntity> Items { get; set; } = new List<OrderItemEntity>();
        public ICollection<PaymentEntity> Payments { get; set; } = new List<PaymentEntity>();
    }
}
