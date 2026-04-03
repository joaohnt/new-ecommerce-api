using Ecommerce.Application.Features.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Features.Order.Queries;

public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto>;
