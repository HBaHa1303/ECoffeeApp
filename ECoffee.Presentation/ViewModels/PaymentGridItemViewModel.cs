namespace ECoffee.Presentation.ViewModels
{
    public class PaymentGridItemViewModel
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? TransactionRef { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
