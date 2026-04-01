namespace ECoffee.Application.DTOs.Response.Report
{
    public class LineChartDto
    {
        public List<string> Labels { get; set; } = [];

        public List<decimal> Current { get; set; } = [];
        public List<decimal> Previous { get; set; } = [];
    }
}
