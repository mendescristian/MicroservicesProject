using Catalog.Infrastructure.Data.Interface;
using Catalog.Infrastructure.Repositories.Interface;
using MicroservicesProject.Core.Entities.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoDBContext _context;
        private readonly IMongoCollection<Product> _collection;

        public ProductRepository(IMongoDBContext context)
        {
            _context = context;
            _collection = _context.Database.GetCollection<Product>("Products");
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
            => await _collection.Find(p => true).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            var regex = new BsonRegularExpression(name, "i");
            var filter = Builders<Product>.Filter.Regex(p => p.Name, regex);

            return await _collection.Find(filter).ToListAsync();
        }
        
        public async Task<Product> GetProductByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string category)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, category);

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<Product> InsertProductAsync(Product product)
        {
            await _collection.InsertOneAsync(product);

            var productInserted = await GetProductByIdAsync(product.Id);

            return productInserted;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            var result = await _collection.ReplaceOneAsync(filter, product);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var result = await _collection.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}