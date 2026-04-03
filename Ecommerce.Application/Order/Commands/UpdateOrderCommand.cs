using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Commands;

public class UpdateOrderCommand : IRequest<OrderDto>
{
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}