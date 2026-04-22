using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECoffee.Application.Models
{
    [Table("ShiftEntity")] // Ánh xạ đúng tên bảng trong Migration của bạn
    public class Shift : BaseDomain
    {
        public long UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public decimal OpeningCash { get; set; }

        public decimal? ClosingCash { get; set; }

        public int Status { get; set; }

        // Navigation property (Nếu cần dùng để lấy thông tin User của ca đó)
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}