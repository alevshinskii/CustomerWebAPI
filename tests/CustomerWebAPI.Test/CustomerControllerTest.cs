using System.Data.Entity.Validation;
using Castle.Core.Resource;
using CustomerManagementEF.Entities;
using CustomerWebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Test
{
    public class CustomerControllerTest
    {
        private readonly ControllerTestFixture _fixture = new ();

        [Fact]
        public void ShouldBeAbleToCreateCustomerController()
        {
            var controller = new CustomerController(_fixture.GetCustomerService());

            controller.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToGetAllCustomers()
        {
            var controller = _fixture.GetCustomerController();

            var result = controller.GetAll();

            var response = result as OkObjectResult;

            response.Should().NotBeNull();
            response!.Value.Should().BeOfType<List<Customer>>();
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var controller = _fixture.GetCustomerController();
            var result = controller.Create(_fixture.GetCustomer());

            var response = result as OkObjectResult;
            response.Should().NotBeNull();
            response!.Value.Should().BeOfType<Customer>();
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var controller = _fixture.GetCustomerController();
            var customer = _fixture.GetCustomer();

            var creationResult=controller.Create(customer) as OkObjectResult;
            var createdCustomer = creationResult.Value as Customer;
            controller.Get(createdCustomer.Id).Should().BeAssignableTo<OkObjectResult>();

            controller.Delete(createdCustomer.Id);
            controller.Get(createdCustomer.Id).Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var controller = _fixture.GetCustomerController();
            var customer = _fixture.GetCustomer();

            var creationResult=controller.Create(customer) as OkObjectResult;
            var createdCustomer = creationResult.Value as Customer;
            controller.Get(createdCustomer.Id).Should().BeAssignableTo<OkObjectResult>();

            createdCustomer.LastName = "New Name";

            controller.Update(createdCustomer).Should().BeAssignableTo<OkObjectResult>();
            
            var updateResult = controller.Get(createdCustomer.Id) as OkObjectResult;
            var updatedCustomer = updateResult.Value as Customer;
            updatedCustomer.LastName.Should().BeEquivalentTo("New Name");
        }

        [Fact]
        public void ShouldCreateCustomerReturnNoContentIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetBrokenCustomerController();

            var result = controller.Create(customer);

            result.Should().BeAssignableTo<NoContentResult>();
        }

    
        [Fact]
        public void ShouldGetCustomerReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetBrokenCustomerController();

            var result = controller.Get(customer.Id);

            result.Should().BeAssignableTo<NotFoundObjectResult>();

        }

        [Fact]
        public void ShouldGetAllCustomersReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetBrokenCustomerController();

            var result = controller.GetAll();

            result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public void ShouldDeleteCustomerReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetBrokenCustomerController();

            var result = controller.Delete(customer.Id);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void ShouldUpdateCustomerReturnNotFoundIfServiceError()
        {
            var customer=_fixture.CreateCustomer();
            var controller = _fixture.GetBrokenCustomerController();

            var result = controller.Update(customer);

            result.Should().BeAssignableTo<NotFoundObjectResult>();
        }
    }
}