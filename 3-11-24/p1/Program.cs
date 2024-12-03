using LearningEF2;
using LearningEF2.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class Program
{
    public static void Main(string[] args)
    {
        using(var context = new SchoolContext())
        {
            //var student = new Student
            //{
            //    StudentName = "John Doe",
            //    StudentAddress = "123 El St",
            //    StudentEmail = "john@test.com",
            //    StudentDOB = new DateTime(2005,7,1),
            //    StudentGender = "Male",
            //    StudentPhone = "555-555-5555"
            //};
            //context.Teachers.Add(new Teacher
            //{
            //    Name = "Jane Doe",
            //    Email = "jane@test.com",
            //    Phone = "555-555-5556"
            //});
            //Student s = new Student();
            //Console.WriteLine("Enter Student Name");
            //s.StudentName = Console.ReadLine();
            //Console.WriteLine("Enter Student Address");
            //s.StudentAddress = Console.ReadLine();
            //Console.WriteLine("Enter Student Email");
            //s.StudentEmail = Console.ReadLine();
            //Console.WriteLine("Enter Student Date of Birth");
            //s.StudentDOB = Convert.ToDateTime(Console.ReadLine());
            //Console.WriteLine("Enter Student Gender");
            //s.StudentGender = Console.ReadLine();
            //Console.WriteLine("Enter Student Phone");
            //s.StudentPhone = Console.ReadLine();

            //Console.WriteLine("Student Added Successfully");

            //Teacher t = new Teacher();
            //Console.WriteLine("Enter Teacher Name");
            //t.Name = Console.ReadLine();
            //Console.WriteLine("Enter Teacher Email");
            //t.Email = Console.ReadLine();
            //Console.WriteLine("Enter Teacher Phone");
            //t.Phone = Console.ReadLine();
            //Console.WriteLine("Student Added Successfully");


            //Console.WriteLine("Teacher Added Successfully");

            //Course c = new Course();
            //Console.WriteLine("Enter Course Name");
            //c.Name = Console.ReadLine();
            //Console.WriteLine("Enter Course Description");
            //c.Description = Console.ReadLine();

            //Console.WriteLine("Course Added Successfully");

            //context.Students.Add(s);
            //context.Teachers.Add(t);
            //context.Courses.Add(c);
            //context.Students.Add(student);
            //context.SaveChanges();
            var student = context.Students.FirstOrDefault();
            DisplayState(context.ChangeTracker.Entries());

            var student1 = new Student
            {
                StudentName = "Jane Doe",
                StudentAddress = "123 Elm St",
                StudentEmail = "",
                StudentDOB = new DateTime(2005, 7, 1),
                StudentGender = "Male",
                StudentPhone = "555-555-5559"
            };
            context.Students.Add(student1);
            Console.WriteLine("DB Status after adding data ...");
            DisplayState(context.ChangeTracker.Entries());
            context.Students.Remove(student1);
            Console.WriteLine("DB Status after removing data ...");
            DisplayState(context.ChangeTracker.Entries());
            context.SaveChanges();
        }
    }
    public static void DisplayState(IEnumerable<EntityEntry> entities)
    {
        foreach (var entity in entities)
        {
            Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State: {entity.State}");
        }
    }
}