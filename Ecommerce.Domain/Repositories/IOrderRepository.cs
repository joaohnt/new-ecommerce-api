using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Pagination;

namespace Ecommerce.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<PagedList<Order>> GetAllAsync(int PageNumber, int PageSize);
    Task<Order?> GetByIdAsync(int orderId);
    Task SaveChangesAsync();
    Task<Order?> GetByIdForCancelAsync(int orderId);

}