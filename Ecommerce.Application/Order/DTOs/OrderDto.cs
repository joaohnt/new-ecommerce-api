using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using MediatR;

namespace Ecommerce.Application.Order.DTOs;

public class OrderDto 
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public IEnumerable<OrderItemDto> OrderItems { get; set;  }
}