namespace ECoffee.Application.DTOs.Response.Report
{
    public class MetricCompareDto
    {
        public decimal Current { get; set; }
        public decimal Previous { get; set; }
        public decimal PercentChange { get; set; }

        public bool IsIncrease => PercentChange >= 0;

        public static MetricCompareDto Build(decimal current, decimal previous)
        {
            decimal change = 0;
            if (previous != 0)
            {
                change = (current - previous) / previous * 100;
            }

            return new MetricCompareDto
            {
                Current = current,
                Previous = previous,
                PercentChange = Math.Round(change, 2) 
            };
        }
    }
}
