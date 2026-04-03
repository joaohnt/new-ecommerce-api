using Ecommerce.Application.Features.Order.Commands.CreateOrder;
using Ecommerce.Application.Features.Order.DTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var items = request.OrderItems.Select(i => new OrderItem(i.Name, i.Price, i.Quantity)).ToList();
        var order = new Domain.Entities.Order(request.CustomerId, items);
        await _orderRepository.AddAsync(order);

        return new OrderDto()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderStatus = order.OrderStatus,
            CreatedAt = order.CreatedAt,
            OrderItems = order.OrderItems.Select(item => new OrderItemDto
            {
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            })
        };
    }
}
