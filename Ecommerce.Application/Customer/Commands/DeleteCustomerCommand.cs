using MediatR;

namespace Ecommerce.Application.Customer.Commands;

public class DeleteCustomerCommand : IRequest<bool>
{
    public int CustomerId { get; set; }
}
