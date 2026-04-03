using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;
    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteAsync(command.CustomerId, cancellationToken);
        return true;
    }
}
