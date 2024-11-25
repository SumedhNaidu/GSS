using System;
using System.Collections.Generic;
using System.Linq;
//using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LearningEF
{
    public class LINQ
    {
        public static void Main(string[] args)
        {
            //Linq

            //DataSource
            string[] names = { "Sumedh", "SaiRam", "Ravi", "Ganesh" };

            //Person name contains 's' & 'a'
            var res = from name in names where name.Contains('s') && name.Contains('a') select name;

            foreach (var name in res)
            {
                Console.WriteLine(name);
            }

            //Data Source
            List<Student> student = new List<Student>{
                new Student{studentId = 1, studentName = "Sumedh", Age = 22},
                new Student{studentId = 2, studentName = "SaiRam", Age = 23},
                new Student{studentId = 3, studentName = "Ravi", Age = 24},
                new Student{studentId = 4, studentName = "Ganesh", Age = 20},
                new Student{studentId = 5, studentName = "Ravi" , Age = 18}
            };

            foreach (var s in student)
            {
                if (s.Age > 20 && s.Age < 23)
                {
                    Console.WriteLine(s.studentName);
                }
            }

            //LINQ Query Syntax
            var queryRes = from s in student where s.Age > 20 && s.Age < 23 select s;
            foreach (var v in queryRes)
            {
                Console.WriteLine(v.studentName);
            }

            //LINQ Method Syntax
            var result = student.Where(s => s.Age > 20 && s.Age < 23);
            foreach (var r in result)
            {
                Console.WriteLine(r.studentName);
            }

            //Sort
            var asc = student.OrderBy(s => s.studentName);
            var desc = student.OrderByDescending(s => s.studentName);
            //Console.WriteLine("Id\t Name\t Age\t");
            foreach (var v1 in asc)
            {
                Console.WriteLine(v1.studentId + "\t" + v1.studentName + "\t" + v1.Age);
            }

            //Distinct 
            var dis = student.Select(s => s.studentName).Distinct();
            Console.WriteLine("Id\t Name\t Age\t");
            foreach (var d2 in dis)
            {
                Console.WriteLine(d2);
            }

            //Projection
            var proj = student.Select(s => new { Name = s.studentName, Age = s.Age });
            foreach (var p in proj)
            {
                Console.WriteLine(p.Name + "\t" + p.Age);
            }

        }
    }
    public class Student
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public int Age { get; set; }
    }
}