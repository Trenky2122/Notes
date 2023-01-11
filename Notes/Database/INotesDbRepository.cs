using Notes.Models;

namespace Notes.Database
{
    public interface INotesDbRepository
    {
        Task AddNote(Note note);
        Task DeleteNote(int id);
        Task EditNote(Note note);
        Task<IEnumerable<Note>> GetNotes();
    }
}
