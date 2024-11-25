using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExample.Models
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

    }
}
