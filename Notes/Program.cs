using Notes.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var notesDbRepository = new NotesDbRepository("Server=127.0.0.1;Port=5432;Database=notes;User Id=postgres;Password=0000;Include Error Detail=true");
await notesDbRepository.CreateTables();
builder.Services.AddTransient<INotesDbRepository>((provider) => notesDbRepository);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
