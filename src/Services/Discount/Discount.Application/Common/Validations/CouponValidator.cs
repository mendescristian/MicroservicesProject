using FluentValidation;
using MicroservicesProject.Core.Entities.PostgreSQL;

namespace Discount.Application.Common.Validations
{
    public class CouponValidator : AbstractValidator<Coupon>
    {
        public CouponValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().MaximumLength(24);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Amount).NotNull();
        }
    }
}
