using MediatR;

namespace Ecommerce.Application.Order.Commands;

public record CancelOrderCommand(int OrderId) : IRequest<bool>;