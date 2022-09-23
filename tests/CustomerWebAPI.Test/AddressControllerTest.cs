using CustomerManagementEF.Entities;
using CustomerWebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Test;

public class AddressControllerTest
{
    private ControllerTestFixture _fixture = new();
    
    [Fact]
    public void ShouldBeAbleToCreateAddressController()
    {
        var controller = new AddressController(_fixture.GetAddressService());

        controller.Should().NotBeNull();
    }

    [Fact]
    public void ShouldBeAbleToCreateAddress()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        address.CustomerId = customer.Id;

        var controller = _fixture.GetAddressController();

        var result = controller.Create(address);

        result.Should().BeAssignableTo<OkObjectResult>();

        var createdAddress = (result as OkObjectResult)!.Value as Address;

        createdAddress.Should().NotBeNull();
    }

    [Fact]
    public void ShouldBeAbleToGetAllAddresses()
    {
        var customer=_fixture.CreateCustomer();
        var controller = _fixture.GetAddressController();
        var result = controller.GetAll();

        result.Should().BeAssignableTo<OkObjectResult>();

        var addresses = (result as OkObjectResult)!.Value as List<Address>;

        addresses.Should().NotBeNull();
    }

    [Fact]
    public void ShouldBeAbleToGetAddress()
    {
        var customer=_fixture.CreateCustomer();
        var address = customer.Addresses[0];
        var controller = _fixture.GetAddressController();
        var result = controller.Get(address.AddressId);

        result.Should().BeAssignableTo<OkObjectResult>();

        var fetchedAddress = (result as OkObjectResult)!.Value as Address;

        fetchedAddress.Should().NotBeNull();
    }

    [Fact]
    public void ShouldBeAbleToDeleteAddress()
    {
        var customer=_fixture.CreateCustomer();
        var address = customer.Addresses[0];
        var controller = _fixture.GetAddressController();

        var result = controller.Delete(address.AddressId);

        result.Should().BeAssignableTo<OkObjectResult>();

        var deleteResult = (int)(result as OkObjectResult)!.Value!;

        deleteResult.Should().Be(address.AddressId);
    }

    [Fact]
    public void ShouldBeAbleToUpdateAddress()
    {
        var customer=_fixture.CreateCustomer();
        var address = customer.Addresses[0];
        var controller = _fixture.GetAddressController();

        address.AddressLine2 = "NewAddressLine2";
        var result = controller.Update(address);

        result.Should().BeAssignableTo<OkObjectResult>();

        var updatedAddress = (result as OkObjectResult)!.Value as Address;

        updatedAddress!.AddressLine2.Should().Be(address.AddressLine2);
    }

    [Fact]
    public void ShouldCreateAddressReturnNoContentIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetAltAddressController();

        var result = controller.Create(address);

        result.Should().BeAssignableTo<NoContentResult>();
    }

    
    [Fact]
    public void ShouldGetAddressReturnNotFoundIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetAltAddressController();

        var result = controller.Get(address.AddressId);

        result.Should().BeAssignableTo<NotFoundObjectResult>();

    }

    [Fact]
    public void ShouldGetAllAddressesReturnNotFoundIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetAltAddressController();

        var result = controller.GetAll();

        result.Should().BeAssignableTo<NotFoundResult>();
    }

    [Fact]
    public void ShouldDeleteAddressReturnNotFoundIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetAltAddressController();

        var result = controller.Delete(address.AddressId);

        result.Should().BeAssignableTo<NotFoundObjectResult>();
    }

    [Fact]
    public void ShouldUpdateAddressReturnNotFoundIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetAltAddressController();

        var result = controller.Update(address);

        result.Should().BeAssignableTo<NotFoundObjectResult>();
    }

    [Fact]
    public void ShouldGetAddressReturnBadRequestIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetAltAddressController();

        var result = controller.Get(address.AddressId);

        result.Should().BeAssignableTo<NotFoundObjectResult>();
    }

    [Fact]
    public void ShouldGetAddressActionReturnBadRequestIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetBrokenAddressController();

        var result = controller.Get(address.AddressId);

        result.Should().BeAssignableTo<BadRequestObjectResult>();
    }

    [Fact]
    public void ShouldCreateAddressActionReturnBadRequestIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetBrokenAddressController();

        var result = controller.Create(address);

        result.Should().BeAssignableTo<BadRequestObjectResult>();
    }

    [Fact]
    public void ShouldGetAllAddressesActionReturnBadRequestIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetBrokenAddressController();

        var result = controller.GetAll();

        result.Should().BeAssignableTo<BadRequestObjectResult>();
    }

    [Fact]
    public void ShouldUpdateAddressActionReturnBadRequestIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetBrokenAddressController();

        var result = controller.Update(address);

        result.Should().BeAssignableTo<BadRequestObjectResult>();
    }

    [Fact]
    public void ShouldDeleteAddressActionReturnBadRequestIfServiceError()
    {
        var customer=_fixture.CreateCustomer();
        var address = _fixture.GetAddress();
        var controller = _fixture.GetBrokenAddressController();

        var result = controller.Delete(address.AddressId);

        result.Should().BeAssignableTo<BadRequestObjectResult>();
    }

}