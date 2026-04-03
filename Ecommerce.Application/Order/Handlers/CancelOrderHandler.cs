using Ecommerce.Application.Order.Commands;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Order.Handlers;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    public CancelOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new ArgumentException("Não é possivel cancelar esse pedido.");
        order.CancelOrder();
        
        await _orderRepository.SaveChangesAsync();
        return true;
    }
}
