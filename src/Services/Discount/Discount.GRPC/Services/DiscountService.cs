using AutoMapper;
using Discount.GRPC.Protos;
using Discount.Infrastructure.Repositories.Interfaces;
using Grpc.Core;
using MicroservicesProject.Core.Entities.PostgreSQL;

namespace Discount.GRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscountAsync(request.ProductName);
            if (coupon is null)
                return new CouponModel
                {
                    ProductName = "Not registered",
                    Description = "There isn't discount registered for this coupon.",
                    Amount = 0
                };

            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var handle = _mapper.Map<Coupon>(request.Coupon);

            var insertStatus = await _repository.CreateDiscountAsync(handle);
            if (!insertStatus)
                throw new RpcException(new Status(StatusCode.Internal, "An internal error occurred when trying to register the coupon"));

            return request.Coupon;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var handle = _mapper.Map<Coupon>(request.Coupon);

            var updateStatus = await _repository.UpdateDiscountAsync(handle);
            if (!updateStatus)
                throw new RpcException(new Status(StatusCode.Internal, "An internal error occurred when trying to update the coupon"));

            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleteStatus = await _repository.DeleteDiscountAsync(request.ProductName);

            var response = new DeleteDiscountResponse { Success = deleteStatus };

            return response;
        }
    }
}
