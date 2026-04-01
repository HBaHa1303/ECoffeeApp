using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Models
{
   
        public enum OrderStatus
        {
            Draft,
        Processing,
            Submitted,
            Paid,
            Cancelled
        }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Refunded
    }
    
}
