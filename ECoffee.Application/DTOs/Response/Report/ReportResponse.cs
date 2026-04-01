namespace ECoffee.Application.DTOs.Response.Report
{
    public class ReportResponse
    {
        public SummaryDto Summary { get; set; } = new();

        public LineChartDto RevenueChart { get; set; } = new();
        public BarChartDto OrderChart { get; set; } = new();

        public List<ProductStatDto> TopProducts { get; set; } = [];
        public List<ProductStatDto> BottomProducts { get; set; } = [];
    }
}
