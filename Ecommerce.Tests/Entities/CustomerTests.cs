using Ecommerce.Domain.Entities;

namespace Ecommerce.Tests.Entities;

public class CustomerTests
{
    [Fact]
    public void CreateCustomer_WithValidData_ShouldSucceed()
    {
        var customer = new Customer("Joao", "joao@email.com");

        Assert.Equal("Joao", customer.Name);
        Assert.Equal("joao@email.com", customer.Email);
    }

    [Fact]
    public void CreateCustomer_WithInvalidName_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Customer("", "joao@email.com"));
    }

    [Fact]
    public void CreateCustomer_WithInvalidEmail_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Customer("Joao", "emailinvalido"));
    }
}