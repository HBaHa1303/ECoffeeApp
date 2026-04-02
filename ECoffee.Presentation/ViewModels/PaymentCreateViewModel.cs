using ECoffee.Infrastructure.Entities;

namespace ECoffee.Presentation.ViewModels
{
    public class PaymentCreateViewModel
    {
        public long OrderId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionRef { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string CreatedBy { get; set; } = "system";
    }
}
