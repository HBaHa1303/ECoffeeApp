namespace ECoffee.Application.DTOs.Response.Report
{
    public class ProductStatDto
    {
        public int Rank { get; set; }
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
        public double Percent { get; set; }
    }
}
