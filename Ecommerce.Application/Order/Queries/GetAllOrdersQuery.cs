using Ecommerce.Application.Order.DTOs;
using Ecommerce.Domain.Pagination;
using MediatR;

namespace Ecommerce.Application.Order.Queries;

public record GetAllOrdersQuery(PageParams PageParams) : IRequest<PagedList<OrderDto>>;
