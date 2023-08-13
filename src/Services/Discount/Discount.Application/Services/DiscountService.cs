using AutoMapper;
using Discount.Application.Common.Dtos;
using Discount.Application.Services.Interfaces;
using Discount.Infrastructure.Repositories.Interfaces;
using MicroservicesProject.Core.Entities.PostgreSQL;
using System.Threading.Tasks;

namespace Discount.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetDiscountAsync(string productName)
        {
            var coupon = await _repository.GetDiscountAsync(productName);
            if (coupon is null)
                return new CouponDto("Not registered", "There isn't discount registered for this coupon.", 0);

            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task<bool> UpdateDiscountAsync(CouponDto data)
        {
            var handle = _mapper.Map<Coupon>(data);

            var updateStatus = await _repository.UpdateDiscountAsync(handle);

            return updateStatus;
        }

        public async Task<bool> CreateDiscountAsync(CouponDto data)
        {
            var handle = _mapper.Map<Coupon>(data);

            var insertStatus = await _repository.CreateDiscountAsync(handle);

            return insertStatus;
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            var deleteStatus = await _repository.DeleteDiscountAsync(productName);

            return deleteStatus;
        }
    }
}
