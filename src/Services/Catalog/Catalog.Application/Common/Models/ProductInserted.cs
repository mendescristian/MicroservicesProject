using Catalog.Application.Common.Dtos;

namespace Catalog.Application.Common.Models
{
    public class ProductInserted
    {
        public bool UpsertedSucessfully { get; set; }
        public ProductDto? Product { get; set; }

        public ProductInserted(bool upsertedSucessfully, ProductDto? product)
        {
            UpsertedSucessfully = upsertedSucessfully;
            Product = product;
        }
    }
}
