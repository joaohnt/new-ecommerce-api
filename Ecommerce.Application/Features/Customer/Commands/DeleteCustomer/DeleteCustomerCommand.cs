using MediatR;

namespace Ecommerce.Application.Features.Customer.Commands.DeleteCustomer;

public record DeleteCustomerCommand(int CustomerId) : IRequest<bool>;
