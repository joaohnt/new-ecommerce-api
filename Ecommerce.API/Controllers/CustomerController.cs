using Ecommerce.Application.Customer.Commands;
using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Application.Customer.Queries;
using Ecommerce.Domain.Entities;
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
    [Route("")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllAsync()
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers);
    }

    [HttpGet]
    [Route("{customerId}")]
    public async Task<ActionResult<CustomerDto>> GetByIdAsync(int customerId)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery{CustomerId = customerId});
        return Ok(customer);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CustomerDto>> CreateAsync([FromBody] CreateCustomerCommand command)
    {
        var customer = await _mediator.Send(command);
        return Ok(customer);
    }

    [HttpDelete]
    [Route("{customerId}")]
    public async Task<ActionResult> DeleteAsync(int customerId)
    {
        await _mediator.Send(new DeleteCustomerCommand{CustomerId = customerId});
        return NoContent();
    }
}