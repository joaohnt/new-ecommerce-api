using Ecommerce.Application.Customer.Commands;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Customer.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;
    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteAsync(command.CustomerId);
        return true;
    }
}
