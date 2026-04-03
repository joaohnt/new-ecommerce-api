using Ecommerce.Application.Features.Customer.DTOs;
using MediatR;

namespace Ecommerce.Application.Features.Customer.Commands.CreateCustomer;

public record CreateCustomerCommand(string Name, string Email) : IRequest<CustomerDto>;
