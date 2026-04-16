using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Repositories;

namespace ECoffee.Application.Services
{
    public class ShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IUserContext _userContext;

        public ShiftService(IShiftRepository shiftRepository, IUserContext userContext)
        {
            _shiftRepository = shiftRepository;
            _userContext = userContext;
        }

        public ShiftResponse? GetOpenShift()
        {
            return _shiftRepository.GetOpenShift();
        }

        public long OpenShift(CreateShiftRequest request)
        {
            if (_shiftRepository.HasOpenShift())
                throw new BadRequestException("Đã có ca làm việc đang mở. Vui lòng đóng ca hiện tại trước.");

            if (request.OpeningCash < 0)
                throw new BadRequestException("Tiền mở ca không được nhỏ hơn 0.");

            return _shiftRepository.OpenShift(_userContext.UserId, request.OpeningCash);
        }

        public void CloseShift(long shiftId, CloseShiftRequest request)
        {
            if (request.ClosingCash < 0)
                throw new BadRequestException("Tiền đóng ca không được nhỏ hơn 0.");

            _shiftRepository.CloseShift(shiftId, request.ClosingCash);
        }

        public bool HasOpenShift()
        {
            return _shiftRepository.HasOpenShift();
        }
    }
}
