using apicrud.Entities;
using apicrud.Persisten;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apicrud.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventController(DevEventsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEnvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvents = _context.DevEnvents.SingleOrDefault(d => d.Id == id);
            if(devEvents == null)
            {
                return NotFound();
            }
            return Ok(devEvents);
        }

        [HttpPost]
        public IActionResult Post(DevEnvent devEnvent)
        {
            _context.DevEnvents.Add(devEnvent);
            return CreatedAtAction(nameof(GetById), new {id = devEnvent.Id}, devEnvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEnvent input)
        {
            var devEvents = _context.DevEnvents.SingleOrDefault(d => d.Id == id);
            if (devEvents == null)
            {
                return NotFound();
            }

            devEvents.Update(input.Title, input.Description, input.EndDate, input.StartDate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvents = _context.DevEnvents.SingleOrDefault(d => d.Id == id);
            if (devEvents == null)
            {
                return NotFound();
            }

            devEvents.Delete();
            return NoContent();
        }
    }
}
