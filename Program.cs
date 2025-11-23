
using EatForm;
using EatForm.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja DbContext z PostgreSQL
builder.Services.AddDbContext<EatFormDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Rejestracja kontrolerów
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();
// Seedowanie danych
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    seeder.Seed();
}
// Middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Mapowanie kontrolerów
app.MapControllers();

app.Run();