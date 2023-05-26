using MicroservicesProject.Core.Entities.Mongo;

namespace Catalog.Infrastructure.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductByNameAsync(string name);
        Task<Product> GetProductByIdAsync(string id);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(string category);
        Task<Product> InsertProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(string id);
    }
}
