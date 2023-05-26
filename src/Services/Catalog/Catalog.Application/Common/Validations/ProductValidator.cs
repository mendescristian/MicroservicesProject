using FluentValidation;
using MicroservicesProject.Core.Entities.Mongo;

namespace Catalog.Application.Common.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(80);
            RuleFor(p => p.Price).NotNull().GreaterThan(0);
            RuleFor(p => p.Category).NotEmpty().MaximumLength(20);
            RuleFor(p => p.ImageFile).NotEmpty();
        }
    }
}
