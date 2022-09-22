using CustomerManagementEF.Contexts;
using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using CustomerManagementEF.Repositories;

namespace CustomerManagementEF.Services;

public class AddressService: IService<Address>
{    
    private readonly IRepository<Address> _addressRepository;

    private string _connectionString =
        "Server=localhost\\sqlexpress01;Database=CustomerLib_Levshinskii_EF;Trusted_Connection=true;";
    
    public AddressService()
    {
        var context = new CustomerDbContext(_connectionString);
        _addressRepository = new AddressRepository(context);
    }

    public AddressService(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public Address? Get(int entityId)
    {
        var address = _addressRepository.Read(entityId);

        return address;
    }

    public Address? Create(Address entity)
    {
        return _addressRepository.Create(entity);
    }

    public bool Update(Address entity)
    {
        return _addressRepository.Update(entity);
    }

    public bool Delete(int entityId)
    {
        return _addressRepository.Delete(entityId);
    }

    public List<Address> GetAll()
    {
        return _addressRepository.ReadAll();
    }
}