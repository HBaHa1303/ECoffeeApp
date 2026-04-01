using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories
{
    public interface IPromotionRepository
    {
        List<PromotionResponse> FindAll();
        List<PromotionResponse> FindAllActiveAsync();
        List<PromotionResponse> FindAllByName(string name);
        Promotion? FindById(long id);
        PromotionResponse? ProjectionFindById(long id);
        void Save(Promotion newPromotion);
        void Update(long id, Promotion promotion);
    }
}
