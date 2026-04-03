using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities;

public class OrderItem : BaseEntity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    
    public int OrderId { get; private set; }
    [JsonIgnore]
    public Order Order { get; private set; } = null!;

    public OrderItem(string name, decimal price, int quantity)
    {
        Validate(name, price, quantity);
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    private static void Validate(string name, decimal price, int quantity)
    {
        if (quantity < 1)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        if (price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome não pode ser vazio.", nameof(name));
    }
    internal void Update(string name, decimal price, int quantity)
    {
        Validate(name, price, quantity);
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
