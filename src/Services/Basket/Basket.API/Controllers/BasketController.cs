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

        [HttpGet("search/{userName}")]
        public async Task<IActionResult> GetBasketAsync([FromRoute] string userName)
        {
            var basket = await _basketService.GetBasketAsync(userName);

            return Ok(basket);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBasketAsync([FromBody] ShoppingCart basket)
        {
            var basketUpdated = await _basketService.UpdateBasketAsync(basket);

            return Ok(basketUpdated);
        }

        [HttpDelete("delete/{userName}")]
        public async Task<IActionResult> DeleteBasketAsync([FromRoute] string userName)
        {
            await _basketService.DeleteBasketAsync(userName);

            return NoContent();
        }
    }
}
