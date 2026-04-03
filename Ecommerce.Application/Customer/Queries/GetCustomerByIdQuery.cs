using Ecommerce.Application.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Customer.Queries;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public int CustomerId { get; set; }
}
