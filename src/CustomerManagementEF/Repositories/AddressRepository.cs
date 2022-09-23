using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using System.Data.Entity;

namespace CustomerManagementEF.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public AddressRepository() { }
        public AddressRepository(CustomerDbContext context) : base(context) { }

        public Address? Create(Address entity)
        {
            var createdEntity = Context.Addresses.Add(entity);
            Context.SaveChanges();
            return createdEntity;
        }

        public Address? Read(int entityId)
        {
            var entities = Context.Addresses.Where(x => x.AddressId == entityId).ToList();
            if (entities.Count > 0)
            {
                return entities[0];
            }
            return null;
        }

        public List<Address> ReadAll()
        {
            return Context.Addresses.ToList();
        }

        public List<Address> ReadAll(int entityId)
        {
            return Context.Addresses.Where(x => x.CustomerId == entityId).ToList();
        }

        public bool Update(Address entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }

        public bool Delete(int entityId)
        {
            Context.Addresses.Remove(Read(entityId) ?? throw new InvalidOperationException());
            Context.SaveChanges();
            return true;
        }

        public bool DeleteAll()
        {
            var entitiesToDelete = Context.Addresses.ToList();
            foreach (var customer in entitiesToDelete)
            {
                Context.Addresses.Remove(customer);
            }
            Context.SaveChanges();
            return true;
        }
    }
}
