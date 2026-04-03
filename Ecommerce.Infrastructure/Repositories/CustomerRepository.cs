using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Pagination;
using Ecommerce.Infrastructure.Database.Context;
using Ecommerce.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly EcommerceDbContext _context;

    public CustomerRepository(EcommerceDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedList<Customer?>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Customers.AsNoTracking().Where(c => c.DeletedAt == null).OrderBy(c => c.Id);
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Customer?> GetByIdAsync(int customerId)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == customerId);

        return customer;
    }

    public async Task DeleteAsync(int customerId)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == customerId);

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}