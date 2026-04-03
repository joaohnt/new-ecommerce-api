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
    public async Task<ActionResult<PagedList<CustomerDto>>> GetAllAsync([FromQuery] PageParams pageParams)
    {
        var result = await _mediator.Send(new GetAllCustomersQuery(pageParams));
        return Ok(result);
    }

    [HttpGet]
    [Route("{customerId}")]
    public async Task<ActionResult<CustomerDto>> GetByIdAsync(int customerId)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(customerId));
        return Ok(customer);
    }

    [HttpPost] 
    public async Task<ActionResult<CustomerDto>> CreateAsync([FromBody] CreateCustomerCommand command)
    {
        var customer = await _mediator.Send(command);
        return Ok(customer);
    }

    [HttpDelete]
    [Route("{customerId}")]
    public async Task<ActionResult> DeleteAsync(int customerId)
    {
        await _mediator.Send(new DeleteCustomerCommand(customerId));
        return NoContent();
    }
}