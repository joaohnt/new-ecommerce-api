using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Entities;

public class Order : Entity
{
    public OrderStatus OrderStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int CustomerId { get; private set; }
    private readonly List<OrderItem> _orderItems = new(); 
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public Order(int customerId, IEnumerable<OrderItem> items)
    {
        if (customerId <= 0)
            throw new ArgumentOutOfRangeException(nameof(customerId));

        var itemList = items.ToList();

        if (itemList.Count == 0)
            throw new ArgumentException("O pedido deve ter pelo menos um item.", nameof(items));

        OrderStatus = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
        CustomerId = customerId;

        foreach (var item in itemList)
        {
            if (item is null)
                throw new ArgumentException("O pedido não pode conter itens nulos.", nameof(items));

            _orderItems.Add(item);
        }
    }
    
    private void EnsureOrderCanBeChanged()
    {
        if (OrderStatus != OrderStatus.Created)
            throw new InvalidOperationException("Apenas pedidos não processados podem ser alterados.");
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
    public void Process()
    {
        if (OrderStatus != OrderStatus.Created)
            throw new InvalidOperationException("Apenas pedidos criados podem ser processados.");
        
        OrderStatus = OrderStatus.Processed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Ship()
    {
        if (OrderStatus == OrderStatus.Processed)
        {
            OrderStatus = OrderStatus.Shipped;
            UpdatedAt = DateTime.UtcNow;
        }       
        else
            throw new InvalidOperationException("Apenas pedidos processados podem ser enviados.");
    }
    
    public void UpdateItem(int itemId, string name, decimal price, int quantity)
    {
        EnsureOrderCanBeChanged();

        var item = _orderItems.FirstOrDefault(x => x.Id == itemId);

        if (item is null)
            throw new ArgumentException("Item não encontrado.", nameof(itemId));

        item.Update(name, price, quantity);

        UpdatedAt = DateTime.UtcNow;
    }
}
