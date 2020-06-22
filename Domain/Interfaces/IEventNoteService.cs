namespace Domain.Interfaces
{
    using Domain.Models;
    using System.Threading.Tasks;

    public interface IEventNoteService
    {
        Task<EventNote> AddEventNote(EventNote eventNote);
        Task<EventNote> DeleteEventNote(long id);
        Task<EventNote> UpdateEventNote(EventNote eventNote);
        Task<EventNote[]> GetEventNotes(long id);
    }
}