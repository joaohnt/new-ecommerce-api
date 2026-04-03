using Ecommerce.Application.Order.DTOs;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Order.Commands;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public int CustomerId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}