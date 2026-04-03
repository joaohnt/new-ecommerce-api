using Ecommerce.Application.Features.Customer.DTOs;
using Ecommerce.Domain.Pagination;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Customer.Queries;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedList<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<PagedList<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync(request.PageParams.PageNumber, request.PageParams.PageSize, cancellationToken);
        
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
