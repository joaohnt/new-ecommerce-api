using Ecommerce.Application.Features.Order.DTOs;
using Ecommerce.Domain.Pagination;
using MediatR;

namespace Ecommerce.Application.Features.Order.Queries;

public record GetAllOrdersQuery(PageParams PageParams) : IRequest<PagedList<OrderDto>>;
