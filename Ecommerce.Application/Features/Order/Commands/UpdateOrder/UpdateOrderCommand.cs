using Ecommerce.Application.Features.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.UpdateOrder;

public record UpdateOrderCommand(int OrderId, int ItemId, string Name, decimal Price, int Quantity) : IRequest<OrderDto>;