using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIwithEFcore.DBModel
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public DateTime StudentDOB { get; set; }
        public string StudentGender { get; set; }
        public DateTime DateAdded { get; set; }

        //[ForeignKey("CourseId")]
        //public int CourseId {  get; set; }

        //NavigationProperty
        // a student can have only one course 1:1
        //public Course Course { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
