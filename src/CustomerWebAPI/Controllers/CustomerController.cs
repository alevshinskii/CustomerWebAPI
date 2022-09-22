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
            var customers = _service.GetAll();
            if (customers.Any())
                return Ok(customers);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var createdCustomer = _service.Create(customer);

            if (createdCustomer != null)
                return Ok(createdCustomer);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var customer = _service.Get(id);

            if (customer != null)
                return Ok(customer);
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
        public IActionResult Update(Customer customer)
        {

            if (_service.Update(customer))
                return Ok(customer);
            return NotFound("Can't find entity in database");

        }
    }
}