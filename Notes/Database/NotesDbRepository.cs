using Dapper;
using Notes.Models;
using Npgsql;

namespace Notes.Database
{
    public class NotesDbRepository: INotesDbRepository
    {
        private readonly string _connectionString;

        public NotesDbRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task CreateTables()
        {
            var connection = CreateConnection();
            string sql = "CREATE TABLE IF NOT EXISTS Notes (Id serial PRIMARY KEY, Category varchar(20), Title varchar(50), Text text);";
        }

        public Task AddNote(Note note)
        {
            string sql = "INSERT INTO Notes (Category, Title, Text) VALUES (@Category, @Title, @Text);";
            var connection = CreateConnection();
            return connection.ExecuteAsync(sql, note);
        }

        public Task DeleteNote(int id)
        {
            string sql = "DELETE FROM Notes WHERE Id=@id;";
            var connection = CreateConnection();
            return connection.ExecuteAsync(sql, new { id });
        }

        public Task EditNote(Note note)
        {
            string sql = "UPDATE Notes SET Category=@Category, Title=@Title, Text=@Text WHERE Id=@Id";
            var connection = CreateConnection();
            return connection.ExecuteAsync(sql, note);
        }

        public Task<IEnumerable<Note>> GetNotes()
        {
            string sql = "SELECT * FROM Notes";
            var connection = CreateConnection();
            return connection.QueryAsync<Note>(sql);
        }
    }
}
