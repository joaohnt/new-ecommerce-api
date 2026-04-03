using Ecommerce.Application.Order.Commands;
using Ecommerce.Application.Order.DTOs;
using Ecommerce.Application.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllAsync()
    {
        var orders = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(orders);
    }

    [HttpGet]
    [Route("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetByIdAsync(int orderId)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(){OrderId = orderId});
        return Ok(order);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<OrderDto>> CreateAsync([FromBody] CreateOrderCommand command)
    {
        var order = await _mediator.Send(command);
        return Ok(order);
    }

    [HttpDelete]
    [Route("{orderId}")]
    public async Task<ActionResult> DeleteAsync(int orderId)
    {
        await _mediator.Send(new CancelOrderCommand(){OrderId = orderId});
        return NoContent();
    }

    [HttpPut]
    [Route("{orderId}")]
    public async Task<ActionResult<OrderDto>> UpdateAsync(int orderId, [FromBody] UpdateOrderCommand command)
    {
        var order = await _mediator.Send(command);
        return Ok(order);
    }

    [HttpPatch]
    [Route("{orderId}/process")]
    public async Task<ActionResult<OrderDto>> ProcessOrderAsync(int orderId)
    {
        await _mediator.Send(new ProcessOrderCommand{OrderId = orderId});
        return Ok();
    }
    
    [HttpPatch]
    [Route("{orderId}/ship")]
    public async Task<ActionResult<OrderDto>> ShipOrderAsync(int orderId)
    {
        await _mediator.Send(new ShipOrderCommand{OrderId = orderId});
        return Ok();
    }
    
}