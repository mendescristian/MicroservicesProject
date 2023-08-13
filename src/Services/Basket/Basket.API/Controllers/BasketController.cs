using Basket.Application.Services.Interfaces;
using MicroservicesProject.Core.Entities.Redis;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetBasketAsync([FromQuery] string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return BadRequest("User name not informed.");

            var basket = await _basketService.GetBasketAsync(userName);

            return Ok(basket);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBasketAsync([FromBody] ShoppingCart basket)
        {
            if (basket is null)
                return BadRequest("Cart data not informed.");

            var basketUpdated = await _basketService.UpdateBasketAsync(basket);

            return Ok(basketUpdated);
        }

        [HttpDelete("delete/{userName}")]
        public async Task<IActionResult> DeleteBasketAsync([FromRoute] string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return BadRequest("User name not informed.");

            await _basketService.DeleteBasketAsync(userName);

            return NoContent();
        }
    }
}
