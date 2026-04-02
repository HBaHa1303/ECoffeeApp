using ECoffee.Application.DTOs.Request;
using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Exceptions;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECoffee.Application.Services
{
    public class PromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IUnitOfWork _uow;
        private readonly IUserContext _userContext;
        private readonly string currentUser;

        public PromotionService(IPromotionRepository promotionRepository,
            PasswordHasher<User> passwordHasher, 
            IUnitOfWork uow,
            IUserContext userContext
            )
        {
            _promotionRepository = promotionRepository;
            _uow = uow;
            _userContext = userContext;
            currentUser = _userContext.Email;
        }


        public Task<List<PromotionResponse>> FindAllAsync() => Task.FromResult(_promotionRepository.FindAll());
        public Task<List<PromotionResponse>> FindAllByNameAsync(string name) => Task.FromResult(_promotionRepository.FindAllByName(name));
        public Task<List<PromotionResponse>> FindAllActiveAsync(string name) => Task.FromResult(_promotionRepository.FindAllActiveAsync());

        public async Task InactiveAsync(long id)
        {
            Promotion? promotion = _promotionRepository.FindById(id);

            if (promotion == null) throw new NotFoundException("Chương trình khuyến mãi không tồn tại trong hệ thống");

            promotion.Inactive();
            _promotionRepository.Update(id, promotion);

            await _uow.SaveChangesAsync();
        }

        public async Task ActiveAsync(long id)
        {
            Promotion? promotion = _promotionRepository.FindById(id);

            if (promotion == null) throw new NotFoundException("Chương trình khuyến mãi không tồn tại trong hệ thống");

            promotion.Active();
            _promotionRepository.Update(id, promotion);

            await _uow.SaveChangesAsync();
        }

        public PromotionResponse FindById(long id)
        {
            PromotionResponse? promotion = _promotionRepository.ProjectionFindById(id);

            if (promotion == null)
            {
                throw new NotFoundException("Chương trình khuyến mãi không tồn tại trong hệ thống");
            }

            return promotion;
        }

        public async Task CreatePromotionAsync(CreatePromotionRequest request)
        {
            var newPromotion = Promotion.Create(request);

            _promotionRepository.Save(newPromotion);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdatePromotionAsync(long id, UpdatePromotionRequest request)
        {
            Promotion? promotion = _promotionRepository.FindById(id);

            if (promotion == null) throw new NotFoundException("Chương trình khuyến mãi không tồn tại trong hệ thống");

            promotion.ChangeType(request.Type);
            promotion.ChangeDiscountAmount(request.DiscountAmount);
            promotion.ChangeDiscountPercent(request.DiscountPercent);
            promotion.Rename(request.Name);
            promotion.ChangeStartDate(request.StartDate);
            promotion.ChangeEndDate(request.EndDate);

            _promotionRepository.Update(id, promotion);
            await _uow.SaveChangesAsync();


        }
    }
}
