namespace ECoffee.Application.DTOs.Request
{
    public class CreateShiftRequest
    {
        public decimal OpeningCash { get; set; }
    }

    public class CloseShiftRequest
    {
        public decimal ClosingCash { get; set; }
    }
}
