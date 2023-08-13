using Discount.Application.Common.Dtos;
using System.Threading.Tasks;

namespace Discount.Application.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<bool> CreateDiscountAsync(CouponDto data);
        Task<bool> DeleteDiscountAsync(string productName);
        Task<CouponDto> GetDiscountAsync(string productName);
        Task<bool> UpdateDiscountAsync(CouponDto data);
    }
}
