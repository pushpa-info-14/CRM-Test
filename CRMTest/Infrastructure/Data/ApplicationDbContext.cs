using CRMTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMTest.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	public DbSet<Customer> Customers => Set<Customer>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>()
			.HasIndex(c => c.Email)
			.IsUnique();

		modelBuilder.Entity<Customer>()
			.Property(c => c.DateCreated)
			.HasDefaultValueSql("CURRENT_TIMESTAMP");
	}
}