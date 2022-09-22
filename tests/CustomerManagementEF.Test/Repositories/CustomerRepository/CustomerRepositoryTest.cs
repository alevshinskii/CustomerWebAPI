using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;

namespace CustomerManagementEF.Test.Repositories.CustomerRepository
{
    public class CustomerRepositoryTest
    {
        private readonly CustomerRepositoryFixture _fixture = new();

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepo()
        {
            var repository = new CustomerManagementEF.Repositories.CustomerRepository(new CustomerDbContext(_fixture.GetConnectionString()));
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetCustomerRepository();


            Customer customer = _fixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            Assert.NotNull(createdCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetCustomerRepository();
            Customer customer = _fixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            var readedCustomer = repository.Read(createdCustomer.Id);

            Assert.Equal(createdCustomer.Id, readedCustomer.Id);
            Assert.Equal(createdCustomer.FirstName, readedCustomer.FirstName);
            Assert.Equal(createdCustomer.LastName, readedCustomer.LastName);
            Assert.Equal(createdCustomer.Email, readedCustomer.Email);
            Assert.Equal(createdCustomer.PhoneNumber, readedCustomer.PhoneNumber);
            Assert.Equal(createdCustomer.TotalPurchasesAmount, readedCustomer.TotalPurchasesAmount);

        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            _fixture.ClearDb();

            CustomerManagementEF.Repositories.CustomerRepository repository = _fixture.GetCustomerRepository();
            Customer customer = _fixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            var oldEmail = customer.Email;
            var newEmail = "newemail@email.com";

            createdCustomer!.Email = newEmail;

            repository.Update(createdCustomer);

            var updatedCustomer = repository.Read(createdCustomer.Id);

            Assert.NotEqual(oldEmail, updatedCustomer?.Email);
            Assert.Equal(newEmail, updatedCustomer?.Email);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetCustomerRepository();
            Customer customer = _fixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            repository.Delete(createdCustomer!.Id);

            var readedCustomer = repository.Read(createdCustomer.Id);

            Assert.Null(readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadAllCustomers()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetCustomerRepository();

            repository.Create(_fixture.GetCustomer());
            repository.Create(_fixture.GetCustomer());

            var customers = repository.ReadAll();

            Assert.NotEmpty(customers);
            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void ShouldNotBeAbleToReadAllCustomersById()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetCustomerRepository();

            repository.Create(_fixture.GetCustomer());
            repository.Create(_fixture.GetCustomer());

            Assert.Throws<InvalidOperationException>(() => repository.ReadAll(1));
        }

        [Fact]
        public void ShouldDeleteReturnsFalseIfNoLinesAffected()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetCustomerRepository();

            var customer = _fixture.GetCustomer();

            Assert.False(repository.Delete(customer.Id));
        }

        [Fact]
        public void ShouldCreateActionReturnNullIfExceptionThrown()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetBrokenCustomerRepository();
            var customer = _fixture.GetCustomer();

            Assert.Null(repository.Create(customer));
        }

        [Fact]
        public void ShouldReadActionReturnNullIfExceptionThrown()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetBrokenCustomerRepository();
            var customer = _fixture.GetCustomer();

            Assert.Null(repository.Read(customer.Id));
        }

        [Fact]
        public void ShouldReadAllActionReturnEmptyIfExceptionThrown()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetBrokenCustomerRepository();
            var customer = _fixture.GetCustomer();

            Assert.Empty(repository.ReadAll());
        }

        [Fact]
        public void ShouldUpdateActionReturnFalseIfExceptionThrown()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetBrokenCustomerRepository();
            var customer = _fixture.GetCustomer();

            Assert.False(repository.Update(customer));
        }

        [Fact]
        public void ShouldDeleteActionReturnFalseIfExceptionThrown()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetBrokenCustomerRepository();
            var customer = _fixture.GetCustomer();

            Assert.False(repository.Delete(customer.Id));
        }

        [Fact]
        public void ShouldDeleteAllActionReturnFalseIfExceptionThrown()
        {
            _fixture.ClearDb();

            var repository = _fixture.GetBrokenCustomerRepository();

            Assert.False(repository.DeleteAll());
        }
    }
}