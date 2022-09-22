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
            try
            {
                var createdEntity = Context.Addresses.Add(entity);
                Context.SaveChanges();
                return createdEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Address? Read(int entityId)
        {
            try
            {
                var entities = Context.Addresses.Where(x => x.AddressId == entityId).ToList();
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

        public List<Address> ReadAll()
        {
            try
            {
                return Context.Addresses.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Address>();
            }
        }

        public List<Address> ReadAll(int entityId)
        {
            try
            {
                return Context.Addresses.Where(x => x.CustomerId == entityId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Address>();
            }
        }

        public bool Update(Address entity)
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
                Context.Addresses.Remove(Read(entityId) ?? throw new InvalidOperationException());
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
                var entitiesToDelete = Context.Addresses.ToList();
                foreach (var customer in entitiesToDelete)
                {
                    Context.Addresses.Remove(customer);
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
