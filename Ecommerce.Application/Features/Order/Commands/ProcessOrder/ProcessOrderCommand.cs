using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.ProcessOrder;

public record ProcessOrderCommand(int OrderId) : IRequest<bool>;
