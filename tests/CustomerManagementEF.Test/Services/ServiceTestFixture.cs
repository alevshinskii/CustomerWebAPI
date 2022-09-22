using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using Moq;

namespace CustomerManagementEF.Test.Services;

public class ServiceTestFixture
{
    public Customer GetCustomer()
    {
        return new Customer()
        {
            Id = 1,
            LastName = "NewCustomer",
            Notes = new List<Note>()
            {
                GetNote()
            },
            Addresses = new List<Address>()
            {
                GetAddress()
            }
        };
    }

    public Address GetAddress()
    {
        return new Address()
        {
            AddressId = 1,
            AddressLine = "AddressLine",
            CustomerId = 1
        };
    }

    public Note GetNote()
    {
        return new Note()
        {
            Id = 1,
            Text = "Text",
            CustomerId = 1
        };
    }

    public CustomerManagementEF.Services.CustomerService GetCustomerService(IRepository<Customer>? customerRepository = null,
        IRepository<Address>? addressRepository = null, IRepository<Note>? noteRepository = null)
    {

        if (customerRepository == null)
        {
            customerRepository = GetCustomerRepositoryMock().Object;
        }

        if (addressRepository == null)
        {
            addressRepository = GetAddressRepositoryMock().Object;
        }

        if (noteRepository == null)
        {
            noteRepository = GetNoteRepositoryMock().Object;
        }


        return new CustomerManagementEF.Services.CustomerService(customerRepository, addressRepository, noteRepository);
    }

    public CustomerManagementEF.Services.AddressService GetAddressService(IRepository<Address>? addressRepository = null)
    {
        if (addressRepository == null)
        {
            addressRepository = GetAddressRepositoryMock().Object;
        }

        return new CustomerManagementEF.Services.AddressService(addressRepository);
    }

    public CustomerManagementEF.Services.NoteService GetNoteService(IRepository<Note>? noteRepository = null)
    {
        if (noteRepository == null)
        {
            noteRepository = GetNoteRepositoryMock().Object;
        }

        return new CustomerManagementEF.Services.NoteService(noteRepository);
    }

    public Mock<IRepository<Customer>> GetCustomerRepositoryMock()
    {
        var customer = GetCustomer();
        var customerRepositoryMock = new Mock<IRepository<Customer>>();
        customerRepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(customer);
        customerRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        customerRepositoryMock.Setup(x => x.Update(It.IsAny<Customer>())).Returns(true);
        customerRepositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns(customer);
        customerRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Customer>() { customer });

        return customerRepositoryMock;
    }

    public Mock<IRepository<Address>> GetAddressRepositoryMock()
    {
        var address = GetAddress();
        var addressRepositoryMock = new Mock<IRepository<Address>>();
        addressRepositoryMock.Setup(x => x.Create(It.IsAny<Address>())).Returns(address);
        addressRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        addressRepositoryMock.Setup(x => x.Update(It.IsAny<Address>())).Returns(true);
        addressRepositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns(address);
        addressRepositoryMock.Setup(x => x.ReadAll(It.IsAny<int>())).Returns(new List<Address>() { address });
        addressRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Address>() { address });

        return addressRepositoryMock;
    }

    public Mock<IRepository<Note>> GetNoteRepositoryMock()
    {
        var note = GetNote();
        var noteRepositoryMock = new Mock<IRepository<Note>>();
        noteRepositoryMock.Setup(x => x.Create(It.IsAny<Note>())).Returns(note);
        noteRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
        noteRepositoryMock.Setup(x => x.Update(It.IsAny<Note>())).Returns(true);
        noteRepositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns(note);
        noteRepositoryMock.Setup(x => x.ReadAll(It.IsAny<int>())).Returns(new List<Note>() { note });
        noteRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Note>() { note });

        return noteRepositoryMock;
    }
}