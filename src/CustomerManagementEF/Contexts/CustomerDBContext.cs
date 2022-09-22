using System.Data.Entity;
using CustomerManagementEF.Entities;

namespace CustomerManagementEF.Contexts;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Note> Notes { get; set; }
}