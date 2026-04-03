using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Pagination;

namespace Ecommerce.Domain.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task<PagedList<Customer?>> GetAllAsync(int  pageNumber, int pageSize);
    Task<Customer?> GetByIdAsync(int customerId);
    Task DeleteAsync(int customerId);
}