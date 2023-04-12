using Catalog.Application.Common.Dtos;
using Catalog.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productService.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("search/name/{name}")]
        public async Task<IActionResult> GetProductByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var product = await _productService.GetProductByNameAsync(name);

            return Ok(product);
        }

        [HttpGet]
        [Route("search/category/{category}")]
        public async Task<IActionResult> GetProductsByCategoryAsync(string category)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest();

            var products = await _productService.GetProductByCategoryAsync(category);

            return Ok(products);
        }

        [HttpPost]
        [Route("product/insert")]
        public async Task<IActionResult> InsertProductAsync(ProductDto product)
        {
            if (product == null)
                return BadRequest();

            var insertReturn = await _productService.InsertProductAsync(product);

            return Ok(insertReturn);
;        }

        [HttpPut]
        [Route("product/update")]
        public async Task<IActionResult> UpdateProductAsync(ProductDto product)
        {
            if (product == null)
                return BadRequest();

            var update = await _productService.UpdateProductAsync(product);

            return Ok(update);
        }

        [HttpPut]
        [Route("product/delete")]
        public async Task<IActionResult> DeleteProductAsync(ProductDto product)
        {
            if (product == null)
                return BadRequest();

            var delete = await _productService.DeleteProductAsync(product);

            return Ok(delete);
        }
    }
}
