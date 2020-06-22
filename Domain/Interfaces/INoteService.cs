namespace Domain.Interfaces
{
    using Domain.Models;
    using System.Threading.Tasks;

    public interface INoteService
    {
        Task<Note> AddNote(Note eventNote);
        Task<Note> DeleteNote(long id);
        Task<Note> UpdateNote(Note eventNote);
        Task<Note[]> GetNotes(long id);
    }
}
