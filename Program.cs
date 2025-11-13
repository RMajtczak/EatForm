
using EatForm.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja DbContext z PostgreSQL
builder.Services.AddDbContext<EatFormDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Rejestracja kontrolerów
builder.Services.AddControllers();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Mapowanie kontrolerów
app.MapControllers();

app.Run();