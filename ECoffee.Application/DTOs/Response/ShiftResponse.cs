using ECoffee.Application.Enums;

namespace ECoffee.Application.DTOs.Response
{
    public class ShiftResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal OpeningCash { get; set; }
        public decimal? ClosingCash { get; set; }
        public decimal TotalRevenue { get; set; }
        public ShiftStatus Status { get; set; }

        public string StatusText => Status switch
        {
            ShiftStatus.Open => "Đang mở",
            ShiftStatus.Closed => "Đã đóng",
            _ => ""
        };
    }
}
