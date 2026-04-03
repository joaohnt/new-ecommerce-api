using Ecommerce.Application.Order.Commands;
using Ecommerce.Application.Order.DTOs;
using Ecommerce.Application.Order.Queries;
using Ecommerce.Domain.Pagination;
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
    public async Task<ActionResult<PagedList<OrderDto>>> GetAllAsync([FromQuery] PageParams pageParams)
    {
        var orders = await _mediator.Send(new GetAllOrdersQuery(pageParams));
        return Ok(orders);
    }

    [HttpGet]
    [Route("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetByIdAsync(int orderId)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(orderId));
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateAsync([FromBody] CreateOrderCommand command)
    {
        var order = await _mediator.Send(command);
        return Ok(order);
    }

    [HttpDelete]
    [Route("{orderId}")]
    public async Task<ActionResult> DeleteAsync(int orderId)
    {
        await _mediator.Send(new CancelOrderCommand(orderId));
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
        await _mediator.Send(new ProcessOrderCommand(orderId));
        return Ok();
    }

    [HttpPatch]
    [Route("{orderId}/ship")]
    public async Task<ActionResult<OrderDto>> ShipOrderAsync(int orderId)
    {
        await _mediator.Send(new ShipOrderCommand(orderId));
        return Ok();
    }
}
