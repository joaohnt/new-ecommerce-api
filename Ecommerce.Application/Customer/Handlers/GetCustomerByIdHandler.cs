using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Application.Customer.Queries;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Customer.Handlers;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    public GetCustomerByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

        return new CustomerDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };
    }
}
