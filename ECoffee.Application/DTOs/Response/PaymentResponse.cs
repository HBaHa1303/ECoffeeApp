using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Response
{
    public class PaymentResponse
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? TransactionRef { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string QrContent => $"PAY|Order:{OrderId}|Amount:{Amount:0.##}|Method:{Method}|Ref:{TransactionRef ?? "PENDING"}";
    }
}
