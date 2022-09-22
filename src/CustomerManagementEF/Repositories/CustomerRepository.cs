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
            try
            {
                var createdEntity = Context.Customers.Add(entity);
                Context.SaveChanges();
                return createdEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Customer? Read(int entityId)
        {
            try
            {
                var entities = Context.Customers.Where(x => x.Id == entityId).ToList();
                if (entities.Count > 0)
                {
                    return entities[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<Customer> ReadAll()
        {
            try
            {
                return Context.Customers.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Customer>();
            }
        }

        public List<Customer> ReadAll(int entityId)
        {
            throw new InvalidOperationException("Can't read all customers by id");
        }

        public bool Update(Customer entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Delete(int entityId)
        {
            try
            {
                Context.Customers.Remove(Read(entityId));
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool DeleteAll()
        {
            try
            {
                var entitiesToDelete = Context.Customers.ToList();
                foreach (var customer in entitiesToDelete)
                {
                    Context.Customers.Remove(customer);
                }

                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }

}

