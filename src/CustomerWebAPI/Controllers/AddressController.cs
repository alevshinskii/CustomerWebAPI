using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IService<Address> _service;

        public AddressController(IService<Address> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var addresses = _service.GetAll();
            if (addresses.Any())
                return Ok(addresses);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            var createdAddress = _service.Create(address);

            if (createdAddress != null)
                return Ok(createdAddress);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var address = _service.Get(id);

            if (address != null)
                return Ok(address);
            return NotFound(id);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
                return Ok(id);
            return NotFound(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Address address)
        {

            if (_service.Update(address))
                return Ok(address);
            return NotFound(address.AddressId);
        }
    }

}
