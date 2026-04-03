using Ecommerce.Application.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Customer.Commands;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
