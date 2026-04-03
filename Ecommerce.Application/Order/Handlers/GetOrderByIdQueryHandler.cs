using Ecommerce.Application.Order.DTOs;
using Ecommerce.Application.Order.Queries;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Order.Handlers;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        
        if(order == null)
            throw new ArgumentException($"O pedido {request.OrderId} não existe");
       
        return new OrderDto()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderStatus = order.OrderStatus,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt,
            DeletedAt = order.DeletedAt,
            OrderItems = order.OrderItems.Select(item => new OrderItemDto
            {
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            })
        };
    }
}