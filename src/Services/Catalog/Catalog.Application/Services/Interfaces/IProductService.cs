using Catalog.Application.Common.Dtos;
using Catalog.Application.Common.Models;

namespace Catalog.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<IEnumerable<ProductDto>> GetProductByNameAsync(string name);
        Task<IEnumerable<ProductDto>> GetProductByCategoryAsync(string category);
        Task<ProductInserted> InsertProductAsync(ProductDto newProduct);
        Task<bool> UpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(ProductDto productDto);
    }
}
