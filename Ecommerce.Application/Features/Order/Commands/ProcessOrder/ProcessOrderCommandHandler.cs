using Ecommerce.Application.Features.Order.Commands.ProcessOrder;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.ProcessOrder;

public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public ProcessOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);

        if (order == null)
            throw new ArgumentException($"O pedido {request.OrderId} não existe.");

        order.Process();

        await _orderRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
