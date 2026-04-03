using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Order.Command;

public class CreateOrderCommand
{
    public int CustomerId { get; }
    public List<OrderItem> OrderItems { get;}

}