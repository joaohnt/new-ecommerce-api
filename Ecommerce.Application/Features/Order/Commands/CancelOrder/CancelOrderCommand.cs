using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.CancelOrder;

public record CancelOrderCommand(int OrderId) : IRequest<bool>;
