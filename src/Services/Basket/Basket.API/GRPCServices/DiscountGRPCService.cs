using Discount.GRPC.Protos;

namespace Basket.API.GRPCServices
{
    public class DiscountGRPCService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _service;

        public DiscountGRPCService(DiscountProtoService.DiscountProtoServiceClient service)
        {
            _service = service;
        }

        public async Task<CouponModel> GetDiscountAsync(string productName)
        {
            var request = new GetDiscountRequest { ProductName = productName };

            var coupon = await _service.GetDiscountAsync(request);

            return coupon;
        }
    }
}
