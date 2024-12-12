using Microsoft.EntityFrameworkCore;

namespace UsersTask.Models
{
    public class UsersDbContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Email = "admin@example.com",
                    Password = "admin123",
                    Role = "Admin"
                },
                new User
                {
                    UserId = 2,
                    UserName = "user1",
                    Email = "user1@example.com",
                    Password = "password123",
                    Role = "User"
                },
                new User
                {
                    UserId = 3,
                    UserName = "user2",
                    Email = "user2@example.com",
                    Password = "password456",
                    Role = "User"
                }
            );
        }
    }
}
