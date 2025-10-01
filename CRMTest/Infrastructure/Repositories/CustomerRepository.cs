using CRMTest.Domain.Entities;
using CRMTest.Domain.Repositories;
using CRMTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRMTest.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
	private readonly ApplicationDbContext _context;

	public CustomerRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Customer>> GetAllAsync() =>
		await _context.Customers.ToListAsync();

	public async Task<Customer?> GetByIdAsync(int id) =>
		await _context.Customers.FindAsync(id);

	public async Task<Customer> AddAsync(Customer customer)
	{
		_context.Customers.Add(customer);
		await _context.SaveChangesAsync();
		return customer;
	}

	public async Task UpdateAsync(Customer customer)
	{
		_context.Customers.Update(customer);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var customer = await _context.Customers.FindAsync(id);
		if (customer != null)
		{
			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();
		}
	}
}