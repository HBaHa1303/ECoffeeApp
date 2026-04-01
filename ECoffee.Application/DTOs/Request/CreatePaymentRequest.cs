using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Request
{
    public class CreatePaymentRequest
    {
        public long OrderId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal? Amount { get; set; }
        public string? TransactionRef { get; set; }
    }
}
