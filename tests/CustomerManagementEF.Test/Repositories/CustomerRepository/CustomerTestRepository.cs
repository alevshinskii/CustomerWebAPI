using CustomerManagementEF.Contexts;

namespace CustomerManagementEF.Test.Repositories.CustomerRepository;

public class CustomerTestRepository:CustomerManagementEF.Repositories.CustomerRepository
{
    public CustomerTestRepository()
    {
        Context = new CustomerDbContext(
            "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EFTest;Trusted_Connection=true;");
    }
}