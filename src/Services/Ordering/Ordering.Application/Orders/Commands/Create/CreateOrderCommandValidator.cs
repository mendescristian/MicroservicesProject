using FluentValidation;
using MicroservicesProject.Core.Enums;

namespace Ordering.Application.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("User name is required.")
                                    .MinimumLength(5)
                                    .MaximumLength(14).WithMessage("User name cannot exceed 14 characters");

            RuleFor(p => p.TotalPrice).GreaterThan(0.01m);

            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First name is required.")
                                     .MaximumLength(20).WithMessage("First name cannot exceed 20 characters");

            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last name is required.")
                                    .MaximumLength(40).WithMessage("Last name cannot exceed 40 characters");

            RuleFor(p => p.EmailAddress).NotEmpty().WithMessage("Email is required.");

            RuleFor(p => p.AddressLine).NotEmpty().WithMessage("Address is required.");

            RuleFor(p => p.Country).NotEmpty().WithMessage("Country is required.");

            RuleFor(p => p.State).NotEmpty().WithMessage("State is required.");

            RuleFor(p => p.ZipCode).NotEmpty().WithMessage("Postal code is required.");

            RuleFor(p => p.PaymentMethod).Must(paymentMethod => BeValidPaymentMethod(paymentMethod))
                                         .WithMessage("Invalid payment method.");

            When(p => IsCardPaymentMethod(p.PaymentMethod), () =>
            {
                RuleFor(p => p.CardName).NotEmpty()
                                        .WithMessage("Card Name is required for selected payment methods.");

                RuleFor(p => p.CardNumber).NotEmpty()
                                          .WithMessage("Card Number is required for selected payment methods.");

                RuleFor(p => p.Expiration).NotEmpty()
                                          .WithMessage("Expiration is required for selected payment methods.");

                RuleFor(p => p.CVV).NotEmpty()
                                   .WithMessage("CVV is required for selected payment methods.");
            });
        }

        private bool BeValidPaymentMethod(PaymentMethodEnum paymentMethod) =>
            Enum.GetValues(typeof(PaymentMethodEnum)).Cast<PaymentMethodEnum>().Contains(paymentMethod);

        private bool IsCardPaymentMethod(PaymentMethodEnum paymentMethod) =>
            paymentMethod == PaymentMethodEnum.CreditCard || paymentMethod == PaymentMethodEnum.DebitCard;
    }
}
