using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Entities;

public class Order : Entity
{
    public Status Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;
    
    private readonly List<OrderItem> _orderItems = new(); 
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    private Order()
    {
    }
    
}
