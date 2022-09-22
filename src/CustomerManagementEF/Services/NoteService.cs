using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using CustomerManagementEF.Repositories;

namespace CustomerManagementEF.Services;

public class NoteService : IService<Note>
{
    private readonly IRepository<Note> _noteRepository;

    private string _connectionString =
        "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EF;Trusted_Connection=true;";

    public NoteService()
    {
        var context = new CustomerDbContext(_connectionString);
        _noteRepository = new NoteRepository(context);
    }

    public NoteService(IRepository<Note> noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public Note? Get(int entityId)
    {
        var note = _noteRepository.Read(entityId);

        return note;
    }

    public Note? Create(Note entity)
    {
        return _noteRepository.Create(entity);
    }

    public bool Update(Note entity)
    {
        return _noteRepository.Update(entity);
    }

    public bool Delete(int entityId)
    {
        return _noteRepository.Delete(entityId);
    }

    public List<Note> GetAll()
    {
        return _noteRepository.ReadAll();
    }
}