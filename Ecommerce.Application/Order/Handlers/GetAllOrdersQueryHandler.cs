using Ecommerce.Application.Order.DTOs;
using Ecommerce.Application.Order.Queries;
using Ecommerce.Domain.Pagination;
using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Order.Handlers;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedList<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<PagedList<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync(request.PageParams.PageNumber, request.PageParams.PageSize);

        var orderDtos = orders.Select(order => new OrderDto
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
        }).ToList();
        return new PagedList<OrderDto>(orderDtos, orders.TotalCount, orders.PageSize, orders.CurrentPage);
    }
}
