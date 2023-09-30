using AutoMapper;
using MediatR;
using MicroservicesProject.Core.Common.Exceptions;
using MicroservicesProject.Core.Entities.PostgreSQL;
using Ordering.Infrastructure.Repositories.Interfaces;

namespace Ordering.Application.Orders.Commands.Update
{
    public record UpdateOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(command.Id);
            if (order is null)
                throw new NotFoundException(nameof(Order), command.Id);

            _mapper.Map(command, order, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
