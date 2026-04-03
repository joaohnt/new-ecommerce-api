using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Domain.Pagination;
using MediatR;

namespace Ecommerce.Application.Customer.Queries;

public class GetAllCustomersQuery : IRequest<PagedList<CustomerDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
