using MediatR;

namespace Ecommerce.Application.Customer.Commands;

public class DeleteCustomerRequest : IRequest<bool>
{
    public int CustomerId { get; }
}
