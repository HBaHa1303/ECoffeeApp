using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;
using ECoffee.Presentation.ViewModels;
using Microsoft.EntityFrameworkCore;
using ECoffee.Application.Enums; 

namespace ECoffee.Presentation.Services
{
    public class PaymentModuleService
    {
        private readonly AppDbContext _db;

        public PaymentModuleService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<PaymentGridItemViewModel>> GetPaymentsAsync(string? keyword = null)
        {
            var query = _db.Payments.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(x => x.TransactionRef!.Contains(keyword) || x.OrderId.ToString().Contains(keyword));
            }

            return await query
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PaymentGridItemViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    Method = x.Method.ToString(),
                    Amount = x.Amount,
                    Status = x.Status.ToString(),
                    TransactionRef = x.TransactionRef,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();
        }

        public List<KeyValuePair<string, PaymentMethod>> GetMethods()
        {
            return Enum.GetValues<PaymentMethod>()
                .Select(x => new KeyValuePair<string, PaymentMethod>(GetMethodText(x), x))
                .ToList();
        }

        public async Task<bool> OrderExistsAsync(long orderId)
        {
            return await _db.Orders.AnyAsync(x => x.Id == orderId);
        }

        public async Task<long> CreatePaymentAsync(PaymentCreateViewModel model)
        {
            if (!await OrderExistsAsync(model.OrderId))
            {
                throw new InvalidOperationException("OrderId không tồn tại trong hệ thống.");
            }

            if (model.Amount <= 0)
            {
                throw new InvalidOperationException("Số tiền thanh toán phải lớn hơn 0.");
            }

            var now = DateTime.Now;
            var entity = new PaymentEntity
            {
                OrderId = model.OrderId,
                Method = model.Method,
                Amount = model.Amount,
                Status = model.Status,
                TransactionRef = string.IsNullOrWhiteSpace(model.TransactionRef) ? BuildTransactionRef(model.OrderId) : model.TransactionRef.Trim(),
                CreatedAt = now,
                UpdatedAt = now,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.CreatedBy
            };

            _db.Payments.Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task MarkAsPaidAsync(long paymentId, string updatedBy)
        {
            var entity = await _db.Payments.FirstAsync(x => x.Id == paymentId);
            entity.Status = (ECoffee.Infrastructure.Entities.PaymentStatus)ECoffee.Application.Enums.PaymentStatus.Paid;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = updatedBy;
            await _db.SaveChangesAsync();
        }

        public async Task<PaymentGridItemViewModel?> FindByIdAsync(long paymentId)
        {
            return await _db.Payments
                .AsNoTracking()
                .Where(x => x.Id == paymentId)
                .Select(x => new PaymentGridItemViewModel
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    Method = x.Method.ToString(),
                    Amount = x.Amount,
                    Status = x.Status.ToString(),
                    TransactionRef = x.TransactionRef,
                    CreatedAt = x.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public string BuildTransactionRef(long orderId)
        {
            return $"PAY-{orderId}-{DateTime.Now:yyyyMMddHHmmss}";
        }

        public static string GetMethodText(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.Cash => "Tiền mặt",
                PaymentMethod.Card => "Thẻ",
                PaymentMethod.EWallet => "Ví điện tử",
                PaymentMethod.BankTransfer => "Chuyển khoản",
                _ => method.ToString()
            };
        }

        public async Task UpdateStatusToPaidAsync(long paymentId, string updatedBy)
        {
            // 1. Tìm bản ghi Payment theo Id
            var payment = await _db.Payments.FirstOrDefaultAsync(x => x.Id == paymentId);

            if (payment != null)
            {
                // 2. Cập nhật trạng thái Payment sang Paid
                payment.Status = (ECoffee.Infrastructure.Entities.PaymentStatus)ECoffee.Application.Enums.PaymentStatus.Paid;
                payment.UpdatedAt = DateTime.Now;
                payment.UpdatedBy = updatedBy;

                // 3. Tìm đơn hàng (Order) liên quan để bếp (KDS) có thể thấy đơn
                var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == payment.OrderId);
                if (order != null)
                {
                    // Chuyển trạng thái Order sang Paid (giá trị là 3 theo Enum của bạn)
                    order.Status = OrderStatus.Paid;
                    order.UpdatedAt = DateTime.Now;
                    order.UpdatedBy = updatedBy;
                }

                // 4. Lưu tất cả thay đổi vào Database
                await _db.SaveChangesAsync();
            }
        }
    }
}
