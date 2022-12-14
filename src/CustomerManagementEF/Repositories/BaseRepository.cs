using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;

namespace CustomerManagementEF.Repositories
{
    public abstract class BaseRepository
    {
        public CustomerDbContext Context;
        
        public BaseRepository(CustomerDbContext context)
        {
            Context = context;
        }

        protected BaseRepository()
        {
            Context = new CustomerDbContext(
                "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EF;Trusted_Connection=true;");
        }
    }
}

