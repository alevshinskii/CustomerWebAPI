using CustomerManagementEF.Entities;
using CustomerManagementEF.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IService<Note> _service;

        public NoteController(IService<Note> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var notes = _service.GetAll();
            if (notes.Any())
                return Ok(notes);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            var createdNote = _service.Create(note);

            if (createdNote != null)
                return Ok(createdNote);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var note = _service.Get(id);

            if (note != null)
                return Ok(note);
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
        public IActionResult Update(Note note)
        {
            if (_service.Update(note))
                return Ok(note);
            return NotFound("Can't find entity in database");
        }
    }
}
