namespace ECoffee.Infrastructure.Entities
{
    public enum PaymentMethod
    {
        Cash,
        Card,
        EWallet,
        BankTransfer
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Refunded
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
