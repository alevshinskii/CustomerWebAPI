using CustomerManagementEF.Entities;
using Moq;

namespace CustomerManagementEF.Test.Services;

public class CustomerServiceTest
{
    private readonly ServiceTestFixture _fixture = new();

    [Fact]
    public void ShouldBeAbleToCreateService()
    {
        var service = new CustomerManagementEF.Services.CustomerService();
        Assert.NotNull(service);
    }

    [Fact]
    public void ShouldBeAbleToGetCustomer()
    {
        var customer = _fixture.GetCustomer();

        var service = _fixture.GetCustomerService();

        var createdCustomer = service.Get(customer.Id);

        Assert.NotNull(createdCustomer);
    }

    [Fact]
    public void ShouldBeAbleToCreateCustomer()
    {
        var customer = _fixture.GetCustomer();

        var service = _fixture.GetCustomerService();

        var createdCustomer = service.Create(customer);

        Assert.NotNull(createdCustomer);
    }

    [Fact]
    public void ShouldBeAbleToUpdateCustomer()
    {
        var customer = _fixture.GetCustomer();

        var service = _fixture.GetCustomerService();

        Assert.True(service.Update(customer));
    }

    [Fact]
    public void ShouldBeAbleToDeleteCustomer()
    {
        var customer = _fixture.GetCustomer();

        var service = _fixture.GetCustomerService();

        Assert.True(service.Delete(customer.Id));
    }

    [Fact]
    public void ShouldBeAbleToGetAllCustomers()
    {
        var customer = _fixture.GetCustomer();

        var service = _fixture.GetCustomerService();

        var customers = service.GetAll();

        Assert.NotEmpty(customers);
    }

    [Fact]
    public void ShouldGetActionReturnNullIfCanNotFindCustomerInRepo()
    {
        var customerRepoMock = _fixture.GetCustomerRepositoryMock();
        Customer? customerNull = null;
        customerRepoMock.Setup(x => x.Read(It.IsAny<int>())).Returns(customerNull);

        var service = _fixture.GetCustomerService(customerRepoMock.Object);

        Assert.Null(service.Get(1));
    }

    [Fact]
    public void ShouldUpdateActionReturnFalseIfCustomerRepoUpdateErrors()
    {
        var customer = _fixture.GetCustomer();
        var customerRepoMock = _fixture.GetCustomerRepositoryMock();
        customerRepoMock.Setup(x => x.Update(customer)).Returns(false);

        var service = _fixture.GetCustomerService(customerRepoMock.Object);

        Assert.False(service.Update(customer));
    }

    [Fact]
    public void ShouldUpdateActionReturnFalseIfAddressRepoUpdateErrors()
    {
        var customer = _fixture.GetCustomer();
        var address = customer.Addresses.First();
        var addressRepositoryMock = _fixture.GetAddressRepositoryMock();
        addressRepositoryMock.Setup(x => x.Update(address)).Returns(false);

        var service = _fixture.GetCustomerService(null, addressRepositoryMock.Object);

        Assert.False(service.Update(customer));
    }

    [Fact]
    public void ShouldUpdateActionReturnFalseIfNoteRepoUpdateErrors()
    {
        var customer = _fixture.GetCustomer();
        var note = customer.Notes.First();
        var noteRepositoryMock = _fixture.GetNoteRepositoryMock();
        noteRepositoryMock.Setup(x => x.Update(note)).Returns(false);

        var service = _fixture.GetCustomerService(null, null,noteRepositoryMock.Object);

        Assert.False(service.Update(customer));
    }
}
