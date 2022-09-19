using System.Data.Entity;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;

namespace CustomerManagementEF.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Note>
    {
        public Note? Create(Note entity)
        {
            var createdEntity=Context.Notes.Add(entity);

            Context.SaveChanges();

            return createdEntity;
        }

        public Note? Read(int entityId)
        {
            var entities=Context.Notes.Where(x => x.Id == entityId).ToList();

            if (entities.Count>0)
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
            return Context.Notes.Where(x=>x.CustomerId==entityId).ToList();
        }

        public bool Update(Note entity)
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
            var entityToDelete = Context.Notes.FirstOrDefault(x => x.Id == entityId);
            if (entityToDelete != null)
            {
                Context.Notes.Remove(entityToDelete);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAll()
        {
            var entitiesToDelete = Context.Notes.ToList();
            foreach (var note in entitiesToDelete)
            {
                Context.Notes.Remove(note);
            }
            Context.SaveChanges();
            return true;
        }
    }
}