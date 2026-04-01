using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Entities;

public class Order : Entity
{
    public OrderStatus OrderStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;
    
    private readonly List<OrderItem> _orderItems = new(); 
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public Order()
    {
        OrderStatus = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
    }
    public void EnsureHasItems()
    {
        if (_orderItems.Count == 0)
            throw new ArgumentException("A lista de itens não pode ser vazia");
    }
    
    private void CheckItem(string name, decimal price, int quantity)
    {
        if(quantity < 1)
            throw new ArgumentOutOfRangeException(nameof(quantity), "A quantidade não pode ser inferior a 1");
        if(price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price), "O preço precisa ser superior a 0");
        if(string.IsNullOrEmpty(name)) 
            throw new ArgumentNullException(nameof(name), "O nome não pode ser vazio");
    }
    public void AddItem(OrderItem orderItem)
    {
        CheckItem(orderItem.Name, orderItem.Price, orderItem.Quantity);
        _orderItems.Add(orderItem);
    }
    
    public void CancelOrder()
    {
        if (OrderStatus == OrderStatus.Created ||  OrderStatus == OrderStatus.Processed)
        {
            OrderStatus =  OrderStatus.Canceled;
            UpdatedAt = DateTime.UtcNow;
        }
        else 
            throw new InvalidOperationException("Apenas pedidos iniciados ou processados podem ser cancelados.");
    }
    public void UpdateOrderStatusToProcessed()
    {
        OrderStatus = OrderStatus.Processed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ShipOrder()
    {
        if (OrderStatus == OrderStatus.Processed)
            OrderStatus = OrderStatus.Shipped;
        else
            throw new InvalidOperationException("Apenas pedidos processados podem ser enviados.");
    }
    
    public void UpdateItem(int itemId, string name, decimal price, int quantity)
    {
        if (OrderStatus != OrderStatus.Created)
            throw new InvalidOperationException("Apenas pedidos não processados podem ser alterados.");

        var item = _orderItems.FirstOrDefault(x => x.Id == itemId);

        if (item is null)
            throw new ArgumentException("Item não encontrado.", nameof(itemId));

        CheckItem(name, price, quantity);

        item.Update(name, price, quantity);

        UpdatedAt = DateTime.UtcNow;
    }
}
