using CustomerManagementEF.Contexts;
using CustomerManagementEF.Repositories;
namespace CustomerManagementEF.Test.Repositories.NoteRepository;

public class NoteTestRepository:CustomerManagementEF.Repositories.NoteRepository
{
    public NoteTestRepository()
    {
        Context = new CustomerDbContext(
            "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EFTest;Trusted_Connection=true;");
    }
} 