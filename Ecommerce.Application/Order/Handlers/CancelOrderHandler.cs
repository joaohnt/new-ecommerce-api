using MediatR;

namespace Ecommerce.Application.Order.Handlers;

public class CancelOrderCommand : IRequestHandler<Command.CancelOrderCommand, bool>
{
    
}