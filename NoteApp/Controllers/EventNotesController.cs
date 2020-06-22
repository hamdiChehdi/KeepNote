namespace NoteApp.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Domain.Models;
    using Domain.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class EventNotesController : ControllerBase
    {
        private readonly IEventNoteService eventNoteService;

        public EventNotesController(IEventNoteService eventNoteService)
        {
            this.eventNoteService = eventNoteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventNotes(long id)
        {
            var eventNotes = await eventNoteService.GetEventNotes(id);
            return Ok(eventNotes);
        }

        // PUT: api/EventNotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventNote(long id, EventNote eventNote)
        {
            if (id != eventNote.Id)
            {
                return BadRequest();
            }

            eventNote = await eventNoteService.UpdateEventNote(eventNote);

            if (eventNote == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/EventNotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventNote>> PostEventNote(EventNote eventNote)
        {
            eventNote = await eventNoteService.AddEventNote(eventNote);

            return Ok(eventNote);
        }

        // DELETE: api/EventNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventNote>> DeleteEventNote(long id)
        {
            var eventNote = await eventNoteService.DeleteEventNote(id);

            if (eventNote == null)
            {
                return NotFound();
            }

            return eventNote;
        }
    }
}
