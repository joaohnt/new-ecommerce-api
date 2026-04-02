using Ecommerce.Domain.Entities;

namespace Ecommerce.Tests.Entities;

public class OrderTests
{
    [Fact]
    public void CreateOrder_WithValidParams_ShouldSucceed()
    {
        var items = new List<OrderItem>
        {
            new("Mouse", 100, 2)
        };
        
        var order = new Order(3, items);
        
        Assert.NotNull(order);
        Assert.Null(order.UpdatedAt);
        Assert.Equal(3, order.CustomerId);
        Assert.Single(order.OrderItems);
    }

    [Fact]
    public void CreateOrder_WithInvalidCustomerId_ShouldThrowException()
    {
        var items = new List<OrderItem>
        {
            new("Mouse", 100m, 2)
        };
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new Order(-2, items));
    }
    
    [Fact]
    public void CreateOrder_WithNoItems_ShouldThrowException()
    {
        var items = new List<OrderItem>();
        
        Assert.Throws<ArgumentException>(() => new Order(2, items));
    }
    
}