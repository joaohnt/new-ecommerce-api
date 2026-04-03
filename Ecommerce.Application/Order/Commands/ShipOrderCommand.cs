using MediatR;

namespace Ecommerce.Application.Order.Commands;

public class ShipOrderCommand : IRequest<bool>
{
    public int OrderId { get; set; }
}