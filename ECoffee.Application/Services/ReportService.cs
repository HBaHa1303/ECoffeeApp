using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response.Report;
using ECoffee.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECoffee.Application.Services
{
    public class ReportService
    {
        private readonly IReportQuery _query;

        public ReportService(IReportQuery query)
        {
            _query = query;
        }

        //public async Task<ReportResponse> GetReportAsync(ReportFilter filter)
        //{
        //    return await _query.BuildReportAsync(filter);
        //}

        public async Task<ReportResponse> GetReportAsync(ReportFilter filter)
        {
            switch (filter.Granularity)
            {
                case Enums.ReportGranularity.Day:
                    return await _query.BuildReportDayAsync(filter);
                case Enums.ReportGranularity.Week:
                    return await _query.BuildReportWeekAsync(filter);
                case Enums.ReportGranularity.Month:
                    return await _query.BuildReportMonthAsync(filter);

                default:
                    return await _query.BuildReportAsync(filter);
            }
            
        }
    }
}
