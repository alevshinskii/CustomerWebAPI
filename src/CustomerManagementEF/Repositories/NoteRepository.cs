using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using System.Data.Entity;

namespace CustomerManagementEF.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Note>
    {
        public NoteRepository(CustomerDbContext context) : base(context) { }

        public NoteRepository() { }

        public Note? Create(Note entity)
        {
            var createdEntity = Context.Notes.Add(entity);
            Context.SaveChanges();
            return createdEntity;
        }

        public Note? Read(int entityId)
        {
            var entities = Context.Notes.Where(x => x.Id == entityId).ToList();
            if (entities.Count > 0)
            {
                return entities[0];
            }
            return null;
        }

        public List<Note> ReadAll()
        {
            return Context.Notes.ToList();
        }

        public List<Note> ReadAll(int entityId)
        {
            return Context.Notes.Where(x => x.CustomerId == entityId).ToList();
        }

        public bool Update(Note entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }

        public bool Delete(int entityId)
        {
            Context.Notes.Remove(Read(entityId));
            Context.SaveChanges();
            return true;
        }

        public bool DeleteAll()
        {
            var entitiesToDelete = Context.Notes.ToList();
            foreach (var customer in entitiesToDelete)
            {
                Context.Notes.Remove(customer);
            }

            Context.SaveChanges();
            return true;
        }
    }
}