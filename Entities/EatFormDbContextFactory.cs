using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EatForm.Entities;

public class EatFormDbContextFactory : IDesignTimeDbContextFactory<EatFormDbContext>
    {
        public EatFormDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EatFormDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EatFormDb;Username=postgres;Password=Majtczakr.2001.;");

            return new EatFormDbContext(optionsBuilder.Options);
        }
    }
