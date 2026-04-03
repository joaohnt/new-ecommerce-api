using MediatR;

namespace Ecommerce.Application.Order.Commands;

public record ShipOrderCommand(int OrderId) : IRequest<bool>;