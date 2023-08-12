using FluentValidation;
using MicroservicesProject.Core.Entities.Redis;

namespace Basket.Application.Common.Validations
{
    public class ShoppingCartItemValidator : AbstractValidator<ShoppingCartItem>
    {
        public ShoppingCartItemValidator()
        {
            RuleFor(p => p.Quantity).NotNull().GreaterThan(0);
            RuleFor(p => p.Color).NotNull();
            RuleFor(p => p.Price).NotNull().GreaterThan(0);
            RuleFor(p => p.ProductId).NotNull().NotEmpty();
            RuleFor(p => p.ProductName).NotNull().NotEmpty();
        }
    }
}
