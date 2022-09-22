using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using System.Data.Entity;
using Console = System.Console;

namespace CustomerManagementEF.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Note>
    {
        public NoteRepository(CustomerDbContext context) : base(context) { }

        public NoteRepository() { }

        public Note? Create(Note entity)
        {
            try
            {
                var createdEntity = Context.Notes.Add(entity);
                Context.SaveChanges();
                return createdEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Note? Read(int entityId)
        {
            try
            {
                var entities = Context.Notes.Where(x => x.Id == entityId).ToList();
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

        public List<Note> ReadAll()
        {
            try
            {
                return Context.Notes.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Note>();
            }
        }

        public List<Note> ReadAll(int entityId)
        {
            try
            {
                return Context.Notes.Where(x => x.CustomerId == entityId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Note>();
            }
        }

        public bool Update(Note entity)
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
                Context.Notes.Remove(Read(entityId));
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
                var entitiesToDelete = Context.Notes.ToList();
                foreach (var customer in entitiesToDelete)
                {
                    Context.Notes.Remove(customer);
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