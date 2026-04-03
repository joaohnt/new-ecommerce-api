using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Commands;

public record UpdateOrderCommand(int OrderId, int ItemId, string Name, decimal Price, int Quantity) : IRequest<OrderDto>;