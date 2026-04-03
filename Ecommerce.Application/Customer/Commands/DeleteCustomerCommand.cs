using MediatR;

namespace Ecommerce.Application.Customer.Commands;

public record DeleteCustomerCommand(int CustomerId) : IRequest<bool>;
