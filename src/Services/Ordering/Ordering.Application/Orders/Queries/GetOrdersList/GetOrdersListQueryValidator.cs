using FluentValidation;

namespace Ordering.Application.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryValidator : AbstractValidator<GetOrdersListQuery>
    {
        public GetOrdersListQueryValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("User name is required.")
                                               .MinimumLength(5)
                                               .MaximumLength(14).WithMessage("User name cannot exceed 14 characters");
        }
    }
}
