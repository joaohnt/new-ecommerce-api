using Ecommerce.Application.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Customer.Queries;

public record GetCustomerByIdQuery(int CustomerId) : IRequest<CustomerDto>;
