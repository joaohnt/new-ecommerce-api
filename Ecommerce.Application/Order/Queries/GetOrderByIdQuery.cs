using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Queries;

public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto>;
