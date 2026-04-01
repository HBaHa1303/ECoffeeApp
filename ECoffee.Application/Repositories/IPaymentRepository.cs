using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECoffee.Application.Repositories
{
    public interface IPaymentRepository
    {
        List<PaymentMethodOptionResponse> GetMethods();
        List<PaymentResponse> FindAll(string? keyword = null);
        PaymentResponse? FindById(long id);
        void Create(CreatePaymentRequest request, string audit);
        void MarkSuccess(long id, string transactionRef, string audit);
    }
}
