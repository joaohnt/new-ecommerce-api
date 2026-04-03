using Ecommerce.Application.Features.Order.Commands.CancelOrder;
using Ecommerce.Application.Features.Order.Commands.CreateOrder;
using Ecommerce.Application.Features.Order.Commands.ShipOrder;
using Ecommerce.Application.Features.Order.Commands.ProcessOrder;
using Ecommerce.Application.Features.Order.Commands.UpdateOrder;
using Ecommerce.Application.Features.Order.DTOs;
using Ecommerce.Application.Features.Order.Queries;
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
    public async Task<ActionResult<PagedList<OrderDto>>> GetAllAsync([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var orders = await _mediator.Send(new GetAllOrdersQuery(pageParams), cancellationToken);
        return Ok(orders);
    }

    [HttpGet]
    [Route("{orderId}")]
    public async Task<ActionResult<OrderDto>> GetByIdAsync(int orderId, CancellationToken cancellationToken)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(orderId), cancellationToken);
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateAsync([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _mediator.Send(command, cancellationToken);
        return Ok(order);
    }

    [HttpDelete]
    [Route("{orderId}")]
    public async Task<ActionResult> DeleteAsync(int orderId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CancelOrderCommand(orderId), cancellationToken);
        return NoContent();
    }

    [HttpPut]
    [Route("{orderId}")]
    public async Task<ActionResult<OrderDto>> UpdateAsync(int orderId, [FromBody] UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _mediator.Send(command, cancellationToken);
        return Ok(order);
    }

    [HttpPatch]
    [Route("{orderId}/process")]
    public async Task<ActionResult<OrderDto>> ProcessOrderAsync(int orderId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ProcessOrderCommand(orderId), cancellationToken);
        return Ok();
    }

    [HttpPatch]
    [Route("{orderId}/ship")]
    public async Task<ActionResult<OrderDto>> ShipOrderAsync(int orderId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ShipOrderCommand(orderId), cancellationToken);
        return Ok();
    }
}
