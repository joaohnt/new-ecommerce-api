using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int orderId);
    Task SaveChangesAsync();
}