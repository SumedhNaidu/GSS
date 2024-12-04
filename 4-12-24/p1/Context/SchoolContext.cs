using APIwithEFcore.DBModel;
using Microsoft.EntityFrameworkCore;

namespace APIwithEFcore.Context
{
    public class SchoolContext : DbContext
    {
        IConfiguration Configuration { get; }

        public DbSet<Student> Students {  get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public SchoolContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            // configure the relationship between Student and Course
            modelBuilder.Entity<Student>()
                .HasOne<Course>(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId);

            // configure default values for the student
            modelBuilder.Entity<Student>()
                .Property(s => s.DateAdded)
                .HasDefaultValue("getdate()");
        }
    }
}
