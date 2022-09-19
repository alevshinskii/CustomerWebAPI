using System.Data.Entity;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;

namespace CustomerManagementEF.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public Customer? Create(Customer entity)
        {
            var createdEntity = Context.Customers.Add(entity);

            Context.SaveChanges();

            return createdEntity;
        }

        public Customer? Read(int entityId)
        {
            var entities=Context.Customers.Where(x => x.Id == entityId).ToList();

            if (entities.Count>0)
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
            if (Read(entity.Id) != null)
            {
                Context.Entry(entity).State = EntityState.Modified;

                Context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool Delete(int entityId)
        {
            var entity = Read(entityId);
            if (entity != null)
            {
                Context.Customers.Remove(entity);
                Context.SaveChanges();
                return true;
            }
            return false;
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

