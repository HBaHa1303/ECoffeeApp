namespace ECoffee.Infrastructure.Entities
{
    public enum ShiftStatus
    {
        Open,
        Closed
    }

    public class ShiftEntity : BaseEntity
    {
        public long UserId { get; set; }
        public UserEntity User { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal OpeningCash { get; set; }
        public decimal? ClosingCash { get; set; }
        public ShiftStatus Status { get; set; }
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
