using Ecommerce.Domain.Enums;
namespace Ecommerce.Application.Features.Order.DTOs;

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
