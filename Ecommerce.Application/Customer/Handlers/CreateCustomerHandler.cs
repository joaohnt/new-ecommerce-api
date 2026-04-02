using Ecommerce.Application.Customer.Commands;
using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Customer.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<CustomerDto> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customer(request.Name,request.Email);
        await _customerRepository.AddAsync(customer);
        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };
    }
}
