using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using CustomerManagementEF.Repositories;
using System.Net;
using CustomerManagementEF.Contexts;

namespace CustomerManagementEF.Services;

public class CustomerService : IService<Customer>
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IRepository<Address> _addressRepository;
    private readonly IRepository<Note> _noteRepository;

    private string _connectionString =
        "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EF;Trusted_Connection=true;";
    
    public CustomerService()
    {
        var context = new CustomerDbContext(_connectionString);
        _customerRepository = new CustomerRepository(context);
        _addressRepository = new AddressRepository(context);
        _noteRepository = new NoteRepository(context);
    }

    public CustomerService(IRepository<Customer> customerRepository, IRepository<Address>? addressRepository = null, IRepository<Note>? noteRepository = null)
    {
        _customerRepository = customerRepository;
        _addressRepository = addressRepository ?? new AddressRepository();
        _noteRepository = noteRepository ?? new NoteRepository();
    }
    
    public Customer? Get(int entityId)
    {
        var customer = _customerRepository.Read(entityId);

        if (customer == null)
        {
            return null;
        }

        customer.Addresses = _addressRepository.ReadAll(entityId);
        customer.Notes = _noteRepository.ReadAll(entityId);
        return customer;
    }

    public Customer? Create(Customer entity)
    {
        return _customerRepository.Create(entity);
    }

    public bool Update(Customer customer)
    {
        bool isUpdated = true;

        foreach (var address in customer.Addresses)
        {
            if (!_addressRepository.Update(address))
                isUpdated = false;
        }

        foreach (var note in customer.Notes)
        {
            if (!_noteRepository.Update(note))
                isUpdated = false;
        }

        if (!_customerRepository.Update(customer))
            isUpdated = false;

        return isUpdated;
    }

    public bool Delete(int entityId)
    {
        return _customerRepository.Delete(entityId);
    }

    public List<Customer> GetAll()
    {
        var allCustomers = _customerRepository.ReadAll();

        foreach (var customer in allCustomers)
        {
            customer.Addresses = _addressRepository.ReadAll(customer.Id);
            customer.Notes = _noteRepository.ReadAll(customer.Id);
        }

        return allCustomers;
    }
}