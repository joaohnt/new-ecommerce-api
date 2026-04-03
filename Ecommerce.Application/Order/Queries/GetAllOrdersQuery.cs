using Ecommerce.Application.Order.DTOs;
using Ecommerce.Domain.Pagination;
using MediatR;

namespace Ecommerce.Application.Order.Queries;

public class GetAllOrdersQuery : IRequest<PagedList<OrderDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
