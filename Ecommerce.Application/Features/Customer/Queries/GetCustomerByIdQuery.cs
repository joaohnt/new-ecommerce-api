using Ecommerce.Application.Features.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Features.Customer.Queries;

public record GetCustomerByIdQuery(int CustomerId) : IRequest<CustomerDto>;
