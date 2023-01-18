using Microsoft.AspNetCore.Mvc;
using Notes.Database;
using Notes.Models;

namespace Notes.Controllers
{
    [Route("[controller]")]
    public class NotesController: Controller
    {
        private readonly INotesDbRepository _repository;
        public NotesController(INotesDbRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task AddNote([FromBody]Note note)
        {
            await _repository.AddNote(note);
        }

        [HttpDelete("{id}")]
        public async Task DeleteNote(int id)
        {
            await _repository.DeleteNote(id);
        }

        [HttpPut]
        public async Task EditNote([FromBody]Note note)
        {
            await _repository.EditNote(note);
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _repository.GetNotes();
        }
    }
}
