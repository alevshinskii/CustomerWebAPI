using CustomerManagementEF.Entities;
using CustomerManagementEF.Test.Repositories.CustomerRepository;

namespace CustomerManagementEF.Test.Repositories.AddressRepository
{
    public class AddressRepositoryFixture
    {
        private readonly CustomerRepositoryFixture _customerFixture = new CustomerRepositoryFixture();

        public void ClearDb()
        {
            _customerFixture.ClearDb();
        }

        public Address GetAddress()
        {
            var customerRepository = _customerFixture.GetCustomerRepository();
            var customer = customerRepository.Create(_customerFixture.GetCustomer());

            return new Address()
            {
                AddressId = 1,
                AddressLine = "AddressLine",
                AddressLine2 = "AddressLine2",
                AddressType = "Shipping",
                City = "New York",
                Country = "United States",
                CustomerId = customer.Id,
                PostalCode = "123456",
                State = "New York"
            };
        }

        public AddressTestRepository GetAddressRepository()
        {
            return new AddressTestRepository();
        }
    }
}

