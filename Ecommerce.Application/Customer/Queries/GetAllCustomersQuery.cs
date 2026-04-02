using Ecommerce.Application.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Customer.Queries;

public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{
}
