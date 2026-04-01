using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Repositories;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Entities;

namespace ECoffee.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _db;
        public PaymentRepository(AppDbContext db) { _db = db; }

        public List<PaymentMethodOptionResponse> GetMethods() => Enum.GetNames<PaymentMethod>().Select(x => new PaymentMethodOptionResponse { Name = x }).ToList();

        public List<PaymentResponse> FindAll(string? keyword = null)
        {
            var query = _db.Payments.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(x => x.OrderId.ToString().Contains(keyword) || x.Method.ToString().Contains(keyword) || x.Status.ToString().Contains(keyword) || (x.TransactionRef ?? string.Empty).Contains(keyword));
            }
            return query.OrderByDescending(x => x.CreatedAt).AsEnumerable().Select(MapPayment).ToList();
        }

        public PaymentResponse? FindById(long id) => _db.Payments.Where(x => x.Id == id).AsEnumerable().Select(MapPayment).FirstOrDefault();

        public void Create(CreatePaymentRequest request, string audit)
        {
            var order = _db.Orders.FirstOrDefault(x => x.Id == request.OrderId);
            if (order == null) throw new NotFoundException("Order không tồn tại trong hệ thống");
            if (!Enum.TryParse<PaymentMethod>(request.Method, true, out var method)) throw new BadRequestException("Phương thức thanh toán không hợp lệ");
            var amount = request.Amount.GetValueOrDefault(order.TotalAmount);
            if (amount <= 0) throw new BadRequestException("Số tiền thanh toán phải lớn hơn 0");
            var now = DateTime.Now;
            var entity = new PaymentEntity { OrderId = request.OrderId, Method = method, Amount = amount, Status = PaymentStatus.Pending, TransactionRef = request.TransactionRef, CreatedAt = now, UpdatedAt = now, CreatedBy = audit, UpdatedBy = audit };
            _db.Payments.Add(entity);
        }

        public void MarkSuccess(long id, string transactionRef, string audit)
        {
            var entity = _db.Payments.First(x => x.Id == id);
            entity.Status = PaymentStatus.Paid;
            entity.TransactionRef = transactionRef.Trim();
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = audit;
        }

        private static PaymentResponse MapPayment(PaymentEntity entity) => new() { Id = entity.Id, OrderId = entity.OrderId, Method = entity.Method.ToString(), Amount = entity.Amount, Status = entity.Status.ToString(), TransactionRef = entity.TransactionRef, CreatedAt = entity.CreatedAt, UpdatedAt = entity.UpdatedAt };
    }
}
