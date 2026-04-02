namespace ECoffee.Infrastructure.Entities
{
    public enum PaymentMethod
    {
        Cash = 0,
        Card = 1,
        EWallet = 2,
        BankTransfer = 3
    }

    public enum PaymentStatus
    {
        Pending = 0,
        Paid = 1,
        Failed = 2,
        Refunded = 3
    }

    public class PaymentEntity : BaseEntity
    {
        public long OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string? TransactionRef { get; set; }
    }
}
