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
            try
            {
                var addresses = _service.GetAll();
                if (addresses.Any())
                    return Ok(addresses);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            try
            {
                var createdAddress = _service.Create(address);
                if (createdAddress != null)
                    return Ok(createdAddress);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var address = _service.Get(id);

                if (address != null)
                    return Ok(address);
                return NotFound(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_service.Delete(id))
                    return Ok(id);
                return NotFound(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(Address address)
        {
            try
            {
                if (_service.Update(address))
                    return Ok(address);
                return NotFound(address.AddressId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}
