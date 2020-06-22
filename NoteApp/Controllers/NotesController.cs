namespace NoteApp.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Domain.Models;
    using Domain.Interfaces;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotes(long id)
        {
            var notes = await noteService.GetNotes(id);
            return Ok(notes);
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(long id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            note.LastUdpateDateTime = DateTime.Now;
            note = await noteService.UpdateNote(note);

            if (note == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Notes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            note.CreationDateTime = DateTime.Now;
            note.LastUdpateDateTime = DateTime.Now;
            note = await noteService.AddNote(note);

            return Ok(note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> DeleteNote(long id)
        {
            var note = await noteService.DeleteNote(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }
    }
}
