using CustomerManagementEF.Entities;
using CustomerManagementEF.Test.Repositories.AddressRepository;
using CustomerManagementEF.Test.Repositories.NoteRepository;

namespace CustomerManagementEF.Test.Repositories.CustomerRepository
{
    
    public class CustomerRepositoryFixture
    {
        public void ClearDb()
        {
            new AddressRepositoryFixture().GetAddressRepository().DeleteAll();
            new NoteRepositoryFixture().GetNoteRepository().DeleteAll();
            GetCustomerRepository().DeleteAll();
        }
        public Customer GetCustomer()
        {
            return new Customer()
            {
                Id = 1,
                LastName = "LastName",
                FirstName = "FirstName",
                PhoneNumber = "42738947298347",
                Email = "email@email.com",
                TotalPurchasesAmount = 1000
            };
        }

        public CustomerTestRepository GetCustomerRepository()
        {
            return new CustomerTestRepository();
        }
    }
}
