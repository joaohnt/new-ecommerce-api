using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.ShipOrder;

public record ShipOrderCommand(int OrderId) : IRequest<bool>;
