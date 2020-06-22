namespace Domain.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class EventNoteService : DataService, IEventNoteService
    {
        public EventNoteService(KeepNotesDbContext keepNoteDbContext, ILogger<EventNoteService> logger) :
            base(keepNoteDbContext, logger)
        {

        }

        public async Task<EventNote> AddEventNote(EventNote eventNote)
        {
            try
            {
                keepNoteDbContext.EventNotes.Add(eventNote);

                await keepNoteDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError("Unable to add a new event note " + ex.Message);
            }

            return eventNote;
        }

        public async Task<EventNote> UpdateEventNote(EventNote eventNote)
        {

            keepNoteDbContext.Entry(eventNote).State = EntityState.Modified;

            try
            {
                await keepNoteDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError("Unable to add a new event note " + ex.Message);
            }

            return eventNote;
        }

        public async Task<EventNote> DeleteEventNote(long id)
        {

            var eventNote = await keepNoteDbContext.EventNotes.FindAsync(id);

            if (eventNote == null)
            {
                return null;
            }

            keepNoteDbContext.EventNotes.Remove(eventNote);
            await keepNoteDbContext.SaveChangesAsync();

            return eventNote;
        }

        public async Task<EventNote[]> GetEventNotes(long id)
        {
            var eventNotes = await keepNoteDbContext.EventNotes
                    .Where(eventNote => eventNote.PageId == id)
                    .ToArrayAsync();

            return eventNotes;
        }
    }
}
