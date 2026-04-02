using System.Reflection.Metadata.Ecma335;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;

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
    
    [Theory]
    [InlineData(OrderStatus.Created)]
    [InlineData(OrderStatus.Processed)]    
    public void CancelOrder_WithStatus_ShouldSucceed(OrderStatus status)
    {
        var items = new List<OrderItem>
        {
            new("Mouse", 100, 2)
        };
        
        var order = new Order(3, items);
        if (status == OrderStatus.Processed)
            order.Process();
        
        order.CancelOrder();
        
        Assert.NotNull(order.UpdatedAt);
        Assert.Equal(OrderStatus.Canceled, order.OrderStatus);    
    }
    
    [Theory]
    [InlineData(OrderStatus.Canceled)]
    [InlineData(OrderStatus.Shipped)]    
    public void CancelOrder_WithInvalidStatus_ShouldThrowException(OrderStatus status)
    {
        var items = new List<OrderItem>
        {
            new("Mouse", 100, 2)
        };
        
        var order = new Order(3, items);
        switch (status)
        {
            case OrderStatus.Canceled:
                order.CancelOrder();
                break;

            case OrderStatus.Shipped:
                order.Process();  
                order.Ship();
                break;
        }
        Assert.Throws<InvalidOperationException>(() => order.CancelOrder());
    }
    
    [Fact]
    public void UpdateOrder_WithValidStatus_ShouldSucceed()
    {
        var items = new List<OrderItem>
        {
            new("Mouse", 100, 2)
        };
        
        var order = new Order(3, items);
        
        order.UpdateItem(0,"Teclado", 25, 1);
        var item = order.OrderItems.First();
        
        Assert.NotNull(order.UpdatedAt);
        Assert.Equal("Teclado", item.Name);
        Assert.Equal(25, item.Price);
        Assert.Equal(1, item.Quantity);
    }
    
    [Theory]
    [InlineData(OrderStatus.Processed)]
    [InlineData(OrderStatus.Shipped)]    
    [InlineData(OrderStatus.Canceled)]    
    public void UpdateOrder_WithInvalidStatus_ShouldThrowException(OrderStatus status)
    {
        var items = new List<OrderItem>
        {
            new("Mouse", 100, 2)
        };
        
        var order = new Order(3, items);
        switch (status)
        {
            case OrderStatus.Canceled:
                order.CancelOrder();
                break;

            case OrderStatus.Processed:
                order.Process();   
                break;
            case OrderStatus.Shipped:
                order.Process();   
                order.Ship();
                break;
        }
        Assert.Throws<InvalidOperationException>(() => order.UpdateItem(0,"Teclado", 25, 1));
    }
}