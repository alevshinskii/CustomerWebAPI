using System.Data.Entity;
using CustomerManagementEF.Entities;

namespace CustomerManagementEF.Contexts;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

    public IDbSet<Customer> Customers { get; set; }
    public IDbSet<Address> Addresses { get; set; }
    public IDbSet<Note> Notes { get; set; }
}