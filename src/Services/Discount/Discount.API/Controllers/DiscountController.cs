using Discount.Application.Common.Dtos;
using Discount.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountController(IDiscountService service)
        {
            _service = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetDiscountAsync([FromQuery] string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return BadRequest("Product name not informed.");

            var coupon = await _service.GetDiscountAsync(productName);

            return Ok(coupon);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDiscountAsync([FromBody] CouponDto data)
        {
            if (data is null)
                return BadRequest("Coupon data not informed.");

            var insert = await _service.CreateDiscountAsync(data);

            return Ok(insert);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDiscountAsync([FromBody] CouponDto data)
        {
            if (data is null)
                return BadRequest("Coupon data not informed to update.");

            var update = await _service.UpdateDiscountAsync(data);

            return Ok(update);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDiscountAsync([FromQuery] string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return BadRequest("Product name not informed.");

            var delete = await _service.DeleteDiscountAsync(productName);

            return Ok(delete);
        }
    }
}