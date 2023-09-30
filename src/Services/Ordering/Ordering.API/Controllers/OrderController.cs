using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Orders.Commands.Create;
using Ordering.Application.Orders.Commands.Delete;
using Ordering.Application.Orders.Commands.Update;
using Ordering.Application.Orders.Queries.GetOrdersList;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search/{userName}")]
        public async Task<IActionResult> GetOrdersAsync([FromRoute] string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var orders = await _mediator.Send(query);

            return Ok(orders);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command)
        {
            var requestId = await _mediator.Send(command);

            return Ok(requestId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("delete/{orderId}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int orderId)
        {
            var command = new DeleteOrderCommand(orderId);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}