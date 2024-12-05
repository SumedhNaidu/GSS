namespace APIwithEFcore.DBModel
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // NavigationProperty
        // a course can have many student 1:M
        public virtual ICollection<Student> Students { get; set; }
    }
}
