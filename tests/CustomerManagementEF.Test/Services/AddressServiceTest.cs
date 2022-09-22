using CustomerManagementEF.Entities;
using Moq;

namespace CustomerManagementEF.Test.Services;

public class AddressServiceTest
{
    private readonly ServiceTestFixture _fixture = new();

    [Fact]
    public void ShouldBeAbleToCreateService()
    {
        var service = new CustomerManagementEF.Services.AddressService();
        Assert.NotNull(service);
    }

    [Fact]
    public void ShouldBeAbleToGetAddress()
    {
        var address= _fixture.GetAddress();

        var service = _fixture.GetAddressService();

        var createdAddress = service.Get(address.AddressId);

        Assert.NotNull(createdAddress);
    }

    [Fact]
    public void ShouldBeAbleToCreateAddress()
    {
        var address= _fixture.GetAddress();

        var service = _fixture.GetAddressService();

        var createdAddress = service.Create(address);

        Assert.NotNull(createdAddress);
    }

    [Fact]
    public void ShouldBeAbleToUpdateAddress()
    {
        var address = _fixture.GetAddress();
        var service = _fixture.GetAddressService();

        Assert.True(service.Update(address));
    }

    [Fact]
    public void ShouldBeAbleToDeleteAddress()
    {
        var address = _fixture.GetAddress();
        var service = _fixture.GetAddressService();

        Assert.True(service.Delete(address.AddressId));
    }

    [Fact]
    public void ShouldBeAbleToGetAllAddresses()
    {
        var address = _fixture.GetAddress();
        var service = _fixture.GetAddressService();

        Assert.Single(service.GetAll());
    }

    [Fact]
    public void ShouldGetActionReturnNullIfCanNotFindAddressInRepo()
    {
        var customerRepoMock = _fixture.GetCustomerRepositoryMock();
        Customer? customerNull = null;
        customerRepoMock.Setup(x => x.Read(It.IsAny<int>())).Returns(customerNull);

        var service = _fixture.GetCustomerService(customerRepoMock.Object);

        Assert.Null(service.Get(1));
    }
}