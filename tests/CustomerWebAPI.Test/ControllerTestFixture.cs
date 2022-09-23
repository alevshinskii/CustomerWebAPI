using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using CustomerManagementEF.Services;
using CustomerWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;

namespace CustomerWebAPI.Test;

public class ControllerTestFixture
{
    public IService<Customer> GetCustomerService()
    {
        return new CustomerService();
    }

    public IService<Address> GetAddressService()
    {
        return new AddressService();
    }

    public IService<Note> GetNoteService()
    {
        return new NoteService();
    }

    public CustomerController GetCustomerController()
    {
        return new CustomerController(GetCustomerService());
    }

    public NoteController GetNoteController()
    {
        return new NoteController(GetNoteService());
    }

    public AddressController GetAddressController()
    {
        return new AddressController(GetAddressService());
    }

    public CustomerController GetAltCustomerController()
    {
        return new CustomerController(GetAltCustomerServiceMock().Object);
    }

    public NoteController GetAltNoteController()
    {
        return new NoteController(GetAltNoteServiceMock().Object);
    }

    public AddressController GetAltAddressController()
    {
        return new AddressController(GetAltAddressServiceMock().Object);
    }

    public CustomerController GetBrokenCustomerController()
    {
        return new CustomerController(GetBrokenCustomerServiceMock().Object);
    }

    public NoteController GetBrokenNoteController()
    {
        return new NoteController(GetBrokenNoteServiceMock().Object);
    }

    public AddressController GetBrokenAddressController()
    {
        return new AddressController(GetBrokenAddressServiceMock().Object);
    }

    public Customer GetCustomer()
    {
        var addresses = new List<Address>()
        {
            GetAddress()
        };

        var notes = new List<Note>()
        {
            GetNote()
        };


        return new Customer()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Addresses = addresses,
            Email = "email@gmail.com",
            Notes = notes,
            PhoneNumber = "124325153123513",
            TotalPurchasesAmount = 1000
        };
    }

    public Note GetNote()
    {
        return new Note() { Id = 1, CustomerId = 1, Text = "new note" };
    }

    public Address GetAddress()
    {
        return new Address()
        {
            AddressId = 1,
            AddressLine = "AddressLine"
        };
    }

    public Customer CreateCustomer()
    {
        var controller = GetCustomerController();
        var result= controller.Create(GetCustomer());

        var createdCustomer = (result as OkObjectResult)!.Value as Customer;
        return createdCustomer!;
    }

    /*public Mock<IService<Customer>> GetCustomerServiceMock()
    {
        var customer = GetCustomer();

        var service = new Mock<IService<Customer>>();
        service.Setup(x => x.Get(customer.Id)).Returns(customer);
        service.Setup(x => x.GetAll()).Returns(new List<Customer>() { customer });
        service.Setup(x => x.Create(customer)).Returns(customer);
        service.Setup(x => x.Delete(customer.Id)).Returns(true);
        service.Setup(x => x.Update(customer)).Returns(true);

        return service;
    }

    public Mock<IService<Address>> GetAddressServiceMock()
    {
        var address = GetAddress();

        var service = new Mock<IService<Address>>();
        service.Setup(x => x.Get(address.AddressId)).Returns(address);
        service.Setup(x => x.GetAll()).Returns(new List<Address>() { address });
        service.Setup(x => x.Create(address)).Returns(address);
        service.Setup(x => x.Delete(address.AddressId)).Returns(true);
        service.Setup(x => x.Update(address)).Returns(true);

        return service;
    }

    public Mock<IService<Note>> GetNoteServiceMock()
    {
        var note = GetNote();

        var service = new Mock<IService<Note>>();
        service.Setup(x => x.Get(note.Id)).Returns(note);
        service.Setup(x => x.GetAll()).Returns(new List<Note>() { note });
        service.Setup(x => x.Create(note)).Returns(note);
        service.Setup(x => x.Delete(note.Id)).Returns(true);
        service.Setup(x => x.Update(note)).Returns(true);

        return service;
    }*/

    public Mock<IService<Customer>> GetAltCustomerServiceMock()
    {
        var customer = GetCustomer();

        var service = new Mock<IService<Customer>>();
        service.Setup(x => x.Get(customer.Id)).Returns((Customer?) null);
        service.Setup(x => x.GetAll()).Returns(new List<Customer>() { });
        service.Setup(x => x.Create(customer)).Returns((Customer?) null);
        service.Setup(x => x.Delete(customer.Id)).Returns(false);
        service.Setup(x => x.Update(customer)).Returns(false);

        return service;
    }

    public Mock<IService<Address>> GetAltAddressServiceMock()
    {
        var address = GetAddress();

        var service = new Mock<IService<Address>>();
        service.Setup(x => x.Get(address.AddressId)).Returns((Address?) null);
        service.Setup(x => x.GetAll()).Returns(new List<Address>() { });
        service.Setup(x => x.Create(address)).Returns((Address?) null);
        service.Setup(x => x.Delete(address.AddressId)).Returns(false);
        service.Setup(x => x.Update(address)).Returns(false);

        return service;
    }

    public Mock<IService<Note>> GetAltNoteServiceMock()
    {
        var note = GetNote();

        var service = new Mock<IService<Note>>();
        service.Setup(x => x.Get(note.Id)).Returns((Note?) null);
        service.Setup(x => x.GetAll()).Returns(new List<Note>() {  });
        service.Setup(x => x.Create(note)).Returns((Note?) null);
        service.Setup(x => x.Delete(note.Id)).Returns(false);
        service.Setup(x => x.Update(note)).Returns(false);

        return service;
    }

    public Mock<IService<Customer>> GetBrokenCustomerServiceMock()
    {
        var customer = GetCustomer();

        var service = new Mock<IService<Customer>>();
        service.Setup(x => x.Get(It.IsAny<int>())).Throws<Exception>();
        service.Setup(x => x.GetAll()).Throws<Exception>();
        service.Setup(x => x.Create(It.IsAny<Customer>())).Throws<Exception>();
        service.Setup(x => x.Delete(It.IsAny<int>())).Throws<Exception>();
        service.Setup(x => x.Update(It.IsAny<Customer>())).Throws<Exception>();

        return service;
    }

    public Mock<IService<Address>> GetBrokenAddressServiceMock()
    {
        var service = new Mock<IService<Address>>();
        service.Setup(x => x.Get(It.IsAny<int>())).Throws<Exception>();
        service.Setup(x => x.GetAll()).Throws<Exception>();
        service.Setup(x => x.Create(It.IsAny<Address>())).Throws<Exception>();
        service.Setup(x => x.Delete(It.IsAny<int>())).Throws<Exception>();
        service.Setup(x => x.Update(It.IsAny<Address>())).Throws<Exception>();

        return service;
    }

    public Mock<IService<Note>> GetBrokenNoteServiceMock()
    {
        var note = GetNote();

        var service = new Mock<IService<Note>>();
        service.Setup(x => x.Get(It.IsAny<int>())).Throws<Exception>();
        service.Setup(x => x.GetAll()).Throws<Exception>();
        service.Setup(x => x.Create(It.IsAny<Note>())).Throws<Exception>();
        service.Setup(x => x.Delete(It.IsAny<int>())).Throws<Exception>();
        service.Setup(x => x.Update(It.IsAny<Note>())).Throws<Exception>();

        return service;
    }
}