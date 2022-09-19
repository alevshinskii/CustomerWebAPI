using System.Data.Entity;
using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;

namespace CustomerManagementEF.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public Address? Create(Address entity)
        {
            var createdEntity=Context.Addresses.Add(entity);

            Context.SaveChanges();

            return createdEntity;
        }

        public Address? Read(int entityId)
        {
            var entities=Context.Addresses.Where(x => x.AddressId == entityId).ToList();

            if (entities.Count>0)
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
            return Context.Addresses.Where(x=>x.CustomerId==entityId).ToList();
        }

        public bool Update(Address entity)
        {
            if (Read(entity.AddressId) != null)
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int entityId)
        {
            var entityToDelete = Context.Addresses.FirstOrDefault(x => x.AddressId == entityId);
            if (entityToDelete != null)
            {
                Context.Addresses.Remove(entityToDelete);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAll()
        {
            var entitiesToDelete = Context.Addresses.ToList();
            foreach (var address in entitiesToDelete)
            {
                Context.Addresses.Remove(address);
            }
            Context.SaveChanges();
            return true;
        }
    }
}
