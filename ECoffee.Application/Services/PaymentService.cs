using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECoffee.Application.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _uow;
        private readonly string _currentUser;

        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork uow, IUserContext userContext)
        {
            _paymentRepository = paymentRepository;
            _uow = uow;
            _currentUser = userContext.IsAuthenticated ? userContext.Email : "system";
        }

        public Task<List<PaymentMethodOptionResponse>> GetMethodsAsync()
            => Task.FromResult(_paymentRepository.GetMethods());

        public Task<List<PaymentResponse>> FindAllAsync(string? keyword = null)
            => Task.FromResult(_paymentRepository.FindAll(keyword));

        public PaymentResponse FindById(long id)
            => _paymentRepository.FindById(id) ?? throw new NotFoundException("Giao dịch không tồn tại trong hệ thống");

        public async Task CreateAsync(CreatePaymentRequest request)
        {
            if (request.OrderId <= 0) throw new BadRequestException("OrderId phải lớn hơn 0");
            if (string.IsNullOrWhiteSpace(request.Method)) throw new BadRequestException("Phương thức thanh toán là bắt buộc");
            _paymentRepository.Create(request, _currentUser);
            await _uow.SaveChangesAsync();
        }

        public async Task CheckSuccessAsync(long id, string transactionRef)
        {
            if (string.IsNullOrWhiteSpace(transactionRef))
                throw new BadRequestException("Mã giao dịch không được để trống");
            if (_paymentRepository.FindById(id) == null)
                throw new NotFoundException("Giao dịch không tồn tại trong hệ thống");
            _paymentRepository.MarkSuccess(id, transactionRef, _currentUser);
            await _uow.SaveChangesAsync();
        }
    }
}
