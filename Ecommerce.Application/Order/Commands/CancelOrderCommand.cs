using MediatR;

namespace Ecommerce.Application.Order.Commands;

public class CancelOrderCommand : IRequest<bool>
{
    public int OrderId { get; set; }
}