using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IReportQuery
    {
        Task<ReportResponse> BuildReportAsync(ReportFilter filter);
        Task<ReportResponse> BuildReportDayAsync(ReportFilter filter);
        Task<ReportResponse> BuildReportMonthAsync(ReportFilter filter);
        Task<ReportResponse> BuildReportWeekAsync(ReportFilter filter);
    }
}
