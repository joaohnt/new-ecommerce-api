using Ecommerce.Application.Features.Order.Commands.CancelOrder;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.CancelOrder;

public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    public CancelOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdForCancelAsync(request.OrderId, cancellationToken);
        if (order == null)
            throw new ArgumentException("Não é possivel cancelar esse pedido.");
        order.CancelOrder();
        
        await _orderRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
