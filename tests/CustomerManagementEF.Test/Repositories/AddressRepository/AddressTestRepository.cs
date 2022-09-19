using CustomerManagementEF.Contexts;

namespace CustomerManagementEF.Test.Repositories.AddressRepository;

public class AddressTestRepository : CustomerManagementEF.Repositories.AddressRepository
{
    public AddressTestRepository()
    {
        Context = new CustomerDbContext(
            "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EFTest;Trusted_Connection=true;");
    }
}