using Ecommerce.Application.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Customer.Commands;

public class CreateCustomerRequest : IRequest<CustomerDto>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
