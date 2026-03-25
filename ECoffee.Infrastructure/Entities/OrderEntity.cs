using ECoffeeBE.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Infrastructure.Entities
{
    public enum OrderStatus
    {
        Draft,
        Submitted,
        Paid,
        Cancelled
    }

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
