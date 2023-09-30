using AutoMapper;
using MediatR;
using Ordering.Application.Common.Dtos;
using Ordering.Infrastructure.Repositories.Interfaces;

namespace Ordering.Application.Orders.Queries.GetOrdersList
{
    public record GetOrdersListQuery : IRequest<List<OrderDto>>
    {
        public string UserName { get; set; }

        public GetOrdersListQuery(string userName)
        {
            UserName = userName;
        }
    }

    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersListQuery command, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserNameAsync(command.UserName);

            var ordersParsed = _mapper.Map<List<OrderDto>>(orders);

            return ordersParsed;
        }
    }
}
