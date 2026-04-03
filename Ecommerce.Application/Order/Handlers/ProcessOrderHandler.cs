using Ecommerce.Application.Order.Commands;
using Ecommerce.Application.Order.DTOs;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Order.Handlers;

public class ProcessOrderHandler : IRequestHandler<ProcessOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public ProcessOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order == null)
            throw new ArgumentException($"O pedido {request.OrderId} não existe.");

        order.Process();

        await _orderRepository.SaveChangesAsync();
        return true;
    }
}