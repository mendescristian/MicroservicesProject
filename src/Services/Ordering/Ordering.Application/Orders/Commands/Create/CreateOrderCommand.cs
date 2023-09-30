using AutoMapper;
using MediatR;
using MicroservicesProject.Core.Entities.PostgreSQL;
using MicroservicesProject.Core.Enums;
using Ordering.Application.Common.Dtos;
using Ordering.Infrastructure.Repositories.Interfaces;

namespace Ordering.Application.Orders.Commands.Create
{
    public record CreateOrderCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatusEnum OrderStatus => OrderStatusEnum.Review;
        public string OrderStatusDescription => "Your order request is now under review.";

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(command);

            var newOrder = await _orderRepository.AddAsync(order);

            return newOrder.Id;
        }
    }
}
