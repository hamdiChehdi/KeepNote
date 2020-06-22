namespace Domain.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class NoteService : DataService, INoteService
    {
        public NoteService(KeepNotesDbContext keepNoteDbContext, ILogger<NoteService> logger): 
            base(keepNoteDbContext, logger)
        {
            
        }

        public async Task<Note> AddNote(Note Note)
        {
            try
            {
                keepNoteDbContext.Notes.Add(Note);

                await keepNoteDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError("Unable to add a new Note " + ex.Message);
            }

            return Note;
        }

        public async Task<Note> UpdateNote(Note Note)
        {

            keepNoteDbContext.Entry(Note).State = EntityState.Modified;

            try
            {
                await keepNoteDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError("Unable to add a new Note " + ex.Message);
            }

            return Note;
        }

        public async Task<Note> DeleteNote(long id)
        {
            var note = await keepNoteDbContext.Notes.FindAsync(id);

            if (note == null)
            {
                return null;
            }

            keepNoteDbContext.Notes.Remove(note);
            await keepNoteDbContext.SaveChangesAsync();

            return note;
        }

        public async Task<Note[]> GetNotes(long id)
        {
            var notes = await keepNoteDbContext.Notes
                    .Where(note => note.PageId == id)
                    .ToArrayAsync();

            return notes;
        }
    }
}
