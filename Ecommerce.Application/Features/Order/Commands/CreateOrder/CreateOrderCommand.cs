using Ecommerce.Application.Features.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.CreateOrder;

public record CreateOrderCommand(int CustomerId, List<OrderItemDto> OrderItems) : IRequest<OrderDto>;