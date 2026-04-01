using ECoffee.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.DTOs.Request
{
    public record ReportFilter(
        DateTime From,
        DateTime To,
        ReportGranularity Granularity
    );
}
