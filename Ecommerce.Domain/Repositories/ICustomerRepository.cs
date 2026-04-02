using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int customerId);
    Task DeleteAsync(int customerId);
}