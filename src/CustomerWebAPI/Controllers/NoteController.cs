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
            try
            {
                var notes = _service.GetAll();
                if (notes.Any())
                    return Ok(notes);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            try
            {
                var createdNote = _service.Create(note);
                if (createdNote != null)
                    return Ok(createdNote);
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
                var note = _service.Get(id);
                if (note != null)
                    return Ok(note);
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
        public IActionResult Update(Note note)
        {
            try
            {
                if (_service.Update(note))
                    return Ok(note);
                return NotFound(note.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
