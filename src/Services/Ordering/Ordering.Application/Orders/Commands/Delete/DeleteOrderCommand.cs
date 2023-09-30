using AutoMapper;
using MediatR;
using MicroservicesProject.Core.Common.Exceptions;
using MicroservicesProject.Core.Entities.PostgreSQL;
using Ordering.Infrastructure.Repositories.Interfaces;

namespace Ordering.Application.Orders.Commands.Delete
{
    public record DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(command.Id);
            if (order is null)
                throw new NotFoundException(nameof(Order), command.Id);

            await _orderRepository.DeleteAsync(order);

            return Unit.Value;
        }
    }
}
