using MediatR;

namespace Ecommerce.Application.Order.Commands;

public record ProcessOrderCommand(int OrderId) : IRequest<bool>;