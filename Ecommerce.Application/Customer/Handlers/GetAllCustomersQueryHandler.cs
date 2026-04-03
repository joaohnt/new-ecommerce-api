using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Application.Customer.Queries;
using Ecommerce.Domain.Pagination;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Customer.Handlers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedList<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<PagedList<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync(request.PageParams.PageNumber, request.PageParams.PageSize);
        
        var customerDtos =  customers.Select(customer => new CustomerDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            CreatedAt = customer.CreatedAt,
        }).ToList();

        return new PagedList<CustomerDto>(customerDtos, customers.TotalCount, customers.PageSize, customers.CurrentPage);
    }
}
