using Ecommerce.Application.Features.Customer.Commands;
using Ecommerce.Application.Features.Customer.DTOs;
using Ecommerce.Application.Features.Customer.Queries;
using Ecommerce.Application.Features.Customer.Commands.CreateCustomer;
using Ecommerce.Application.Features.Customer.Commands.DeleteCustomer;
using Ecommerce.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<CustomerDto>>> GetAllAsync([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCustomersQuery(pageParams), cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    [Route("{customerId}")]
    public async Task<ActionResult<CustomerDto>> GetByIdAsync(int customerId, CancellationToken cancellationToken)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(customerId), cancellationToken);
        return Ok(customer);
    }

    [HttpPost] 
    public async Task<ActionResult<CustomerDto>> CreateAsync([FromBody] CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _mediator.Send(command, cancellationToken);
        return Ok(customer);
    }

    [HttpDelete]
    [Route("{customerId}")]
    public async Task<ActionResult> DeleteAsync(int customerId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteCustomerCommand(customerId), cancellationToken);
        return NoContent();
    }
}
