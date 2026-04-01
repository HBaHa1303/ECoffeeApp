namespace ECoffee.Application.DTOs.Response.Report
{
    public class SummaryDto
    {
        public MetricCompareDto Revenue { get; set; } = new();
        public MetricCompareDto Orders { get; set; } = new();
        public MetricCompareDto AvgOrderValue { get; set; } = new();


    }
}
