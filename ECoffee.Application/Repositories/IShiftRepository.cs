using ECoffee.Application.DTOs.Response;

namespace ECoffee.Application.Repositories
{
    public interface IShiftRepository
    {
        ShiftResponse? GetOpenShift();
        long OpenShift(long userId, decimal openingCash);
        void CloseShift(long shiftId, decimal closingCash);
        bool HasOpenShift();
    }
}
