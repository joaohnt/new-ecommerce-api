using Ecommerce.Application.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Customer.Commands;

public record CreateCustomerCommand(string Name, string Email) : IRequest<CustomerDto>;
