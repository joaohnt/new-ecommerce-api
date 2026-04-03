using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Pagination;

namespace Ecommerce.Domain.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    Task<PagedList<Customer?>> GetAllAsync(int  pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task<Customer?> GetByIdAsync(int customerId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int customerId, CancellationToken cancellationToken = default);
}
