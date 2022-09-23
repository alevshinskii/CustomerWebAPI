using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using System.Data.Entity;

namespace CustomerManagementEF.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public CustomerRepository(CustomerDbContext context) : base(context) { }

        protected CustomerRepository() { }

        public Customer? Create(Customer entity)
        {
            var createdEntity = Context.Customers.Add(entity);
            Context.SaveChanges();
            return createdEntity;
        }

        public Customer? Read(int entityId)
        {
            var entities = Context.Customers.Where(x => x.Id == entityId).ToList();
            if (entities.Count > 0)
            {
                return entities[0];
            }
            return null;
        }

        public List<Customer> ReadAll()
        {
            return Context.Customers.ToList();
        }

        public List<Customer> ReadAll(int entityId)
        {
            throw new InvalidOperationException("Can't read all customers by id");
        }

        public bool Update(Customer entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }

        public bool Delete(int entityId)
        {
            Context.Customers.Remove(Read(entityId));
            Context.SaveChanges();
            return true;
        }

        public bool DeleteAll()
        {
            var entitiesToDelete = Context.Customers.ToList();
            foreach (var customer in entitiesToDelete)
            {
                Context.Customers.Remove(customer);
            }

            Context.SaveChanges();
            return true;
        }
    }

}

