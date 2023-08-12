using FluentValidation;
using MicroservicesProject.Core.Entities.Redis;

namespace Basket.Application.Common.Validations
{
    public class ShoppingCartValidator : AbstractValidator<ShoppingCart>
    {
        public ShoppingCartValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().MaximumLength(80);
        }
    }
}
