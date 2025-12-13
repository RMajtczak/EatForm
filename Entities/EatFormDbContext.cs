using Microsoft.EntityFrameworkCore;

namespace EatForm.Entities;

public class EatFormDbContext : DbContext
{
    public EatFormDbContext(DbContextOptions<EatFormDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<MealProduct> MealProducts { get; set; }
    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutRating> WorkoutRatings { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ForumPost> ForumPosts { get; set; }
    public DbSet<ForumThread> ForumThreads { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

         // Users <-> MealPlans
            modelBuilder.Entity<MealPlan>()
                .HasOne(mp => mp.User)
                .WithMany(u => u.MealPlans)
                .HasForeignKey(mp => mp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Meals <-> MealPlans
            modelBuilder.Entity<Meal>()
                .HasOne(m => m.MealPlan)
                .WithMany(mp => mp.Meals)
                .HasForeignKey(m => m.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // MealProducts <-> Meals
            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Meal)
                .WithMany(m => m.MealProducts)
                .HasForeignKey(mp => mp.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            // MealProducts <-> Products
            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Product)
                .WithMany(p => p.MealProducts)
                .HasForeignKey(mp => mp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Workouts <-> User
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Exercises <-> Workout
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            // WorkoutRatings <-> Workout
            modelBuilder.Entity<WorkoutRating>()
                .HasOne(wr => wr.Workout)
                .WithMany(w => w.Ratings)
                .HasForeignKey(wr => wr.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            // WorkoutRatings <-> User
            modelBuilder.Entity<WorkoutRating>()
                .HasOne(wr => wr.User)
                .WithMany(u => u.WorkoutRatings)
                .HasForeignKey(wr => wr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ForumThreads <-> User (Author)
            modelBuilder.Entity<ForumThread>()
                .HasOne(ft => ft.Author)
                .WithMany(u => u.ForumThreads)
                .HasForeignKey(ft => ft.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // ForumPosts <-> ForumThread
            modelBuilder.Entity<ForumPost>()
                .HasOne(fp => fp.Thread)
                .WithMany(ft => ft.Posts)
                .HasForeignKey(fp => fp.ThreadId)
                .OnDelete(DeleteBehavior.Cascade);

            // ForumPosts <-> User (Author)
            modelBuilder.Entity<ForumPost>()
                .HasOne(fp => fp.Author)
                .WithMany(u => u.ForumPosts)
                .HasForeignKey(fp => fp.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Products <-> User (Creator)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Creator)
                .WithMany()
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
    }
    
    
}