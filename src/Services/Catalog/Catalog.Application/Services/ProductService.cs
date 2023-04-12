using AutoMapper;
using Catalog.Application.Common.Dtos;
using Catalog.Application.Common.Models;
using Catalog.Application.Services.Interfaces;
using Catalog.Infrastructure.Repositories.Interface;
using MicroservicesProject.Core.Entities.Mongo;
using MongoDB.Bson;

namespace Catalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var products = await _repository.GetAllProductsAsync();
            if (!products.Any())
                return Enumerable.Empty<ProductDto>();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetProductByNameAsync(string name)
        {
            var products = await _repository.GetProductByNameAsync(name);
            if (!products.Any())
                return Enumerable.Empty<ProductDto>();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategoryAsync(string category)
        {
            var products = await _repository.GetProductByCategoryAsync(category);
            if (!products.Any())
                return Enumerable.Empty<ProductDto>();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductInserted> InsertProductAsync(ProductDto newProduct)
        {
            var handle = new Product
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = newProduct.Name,
                Category = newProduct.Category,
                Summary = newProduct.Summary,
                Description = newProduct.Description,
                ImageFile = newProduct.ImageFile,
                Price = newProduct.Price
            };

            var insert = await _repository.InsertProductAsync(handle);
            if (insert == null)
                return new ProductInserted(false, null);

            var productDto = _mapper.Map<ProductDto>(insert);

            return new ProductInserted(true, productDto);
        }

        public async Task<bool> UpdateProductAsync(ProductDto productDto)
        {
            var handle = _mapper.Map<Product>(productDto);

            return await _repository.UpdateProductAsync(handle);
        }

        public async Task<bool> DeleteProductAsync(ProductDto productDto)
            => await _repository.DeleteProductAsync(productDto.Id);
    }
}
