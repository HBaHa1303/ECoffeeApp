using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Enums
{
    public enum OrderStatus
    {
        Draft,// 0
        Processing,// 1
        Submitted,// 2
        Paid,// 3
        Cancelled,// 4
        Completed// 5  không xóa cái này
    }
}
