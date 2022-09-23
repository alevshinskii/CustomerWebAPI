using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IService<Customer> _service;

        public CustomerController(IService<Customer> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var customers = _service.GetAll();
                if (customers.Any())
                    return Ok(customers);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                var createdCustomer = _service.Create(customer);
                if (createdCustomer != null)
                    return Ok(createdCustomer);
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
                var customer = _service.Get(id);
                if (customer != null)
                    return Ok(customer);
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
        public IActionResult Update(Customer customer)
        {
            try
            {
                if (_service.Update(customer))
                    return Ok(customer);
                return NotFound(customer.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}