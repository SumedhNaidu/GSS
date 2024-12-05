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
            //modelBuilder.Entity<Student>()
            //    .HasOne<Course>(s => s.Course)
            //    .WithMany(c => c.Students)
            //    .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                //.UsingEntity<StudentCourse>(
                //    j => j
                //            .HasOne(pt => pt.Course)
                //            .WithMany(t => t.Students)
                //            .HasForeignKey(pt => pt.CourseId),
                //    j => j
                //             .HasOne(pt => pt.Student)
                //             .WithMany(p => p.Courses)
                //             .HasForeignKey(pt => pt.StudentId),
                //    j =>
                //    {
                //        j.HasKey(t => new { t.StudentId, t.CourseId });
                //    });
                .UsingEntity(j => j.ToTable("StudentCourse"));

            modelBuilder.Entity<StudentCourse>().HasKey(StudentCourse => new { StudentCourse.StudentId, StudentCourse.CourseId });

            //configure many to many relationship of student and course
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new {sc.StudentId, sc.CourseId});

            // configure default values for the student
            modelBuilder.Entity<Student>()
                .Property(s => s.DateAdded)
                .HasDefaultValueSql("GETDATE()");

            //seed data
            modelBuilder.Entity<Course>().HasData(
                    new Course { Id = 1, Name="Math",Description = "Mathematics"},
                    new Course { Id = 2, Name="Science",Description = "Science"},
                    new Course { Id = 3, Name="Hstory",Description="History"}
             );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "John Doe",
                    StudentAddress = "123 Main St",
                    StudentEmail = "John@test.com",
                    StudentDOB = new DateTime(2000, 1, 1),
                    StudentGender = "M",
                    StudentPhone = "123-456-7890"
                },
                new Student
                {
                    StudentId = 2,
                    StudentName = "Student2",
                    StudentAddress = "123 Main St",
                    StudentEmail = "student2@test.com",
                    StudentDOB = new DateTime(2000, 1, 1),
                    StudentGender = "F",
                    StudentPhone = "123-456-7890"
                }
                );
                // seed student courses
                modelBuilder.Entity<StudentCourse>().HasData(
                    new StudentCourse { StudentId = 1, CourseId = 1},
                    new StudentCourse { StudentId = 1, CourseId = 2},
                    new StudentCourse { StudentId = 2, CourseId = 3},
                    new StudentCourse { StudentId = 2, CourseId = 1}
                );
        }
    }
}
