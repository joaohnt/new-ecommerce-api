using Ecommerce.Domain.Entities;

namespace Ecommerce.Tests.Entities;

public class OrderItemTests
{
    [Fact]
    public void CreateOrderItem_WithValidData_ShouldSucceed()
    {
        var item = new OrderItem("Mouse", 100m, 2);

        Assert.Equal("Mouse", item.Name);
        Assert.Equal(100m, item.Price);
        Assert.Equal(2, item.Quantity);
    }
    [Fact]
    public void UpdateOrderItem_WithValidData_ShouldSucceed()
    {
        var item = new OrderItem("Mouse", 100m, 2);

        item.Update("Teclado", 250m, 1);

        Assert.Equal("Teclado", item.Name);
        Assert.Equal(250m, item.Price);
        Assert.Equal(1, item.Quantity);
    }
    [Fact]
    public void CreateOrderItem_WithInvalidName_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new OrderItem("", 10m, 1));
    }

    [Fact]
    public void CreateOrderItem_WithInvalidPrice_ShouldThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem("Mouse", 0m, 1));
    }

    [Fact]
    public void CreateOrderItem_WithInvalidQuantity_ShouldThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem("Mouse", 10m, 0));
    }
}