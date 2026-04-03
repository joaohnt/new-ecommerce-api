using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Commands;

public record CreateOrderCommand(int CustomerId, List<OrderItemDto> OrderItems) : IRequest<OrderDto>;