using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class SchoolInitializer : System.Data.Entity.CreateDatabaseIfNotExists<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var grades = new List<Grade> { new Grade { Name = "Level 1" }, new Grade { Name = "Level 2" } };

            grades.ForEach(s => context.Grades.Add(s));
            
            context.SaveChanges();

            var grade1 = context.Grades.Where(g => g.Name.Equals("Level 1")).First();
            var grade2 = context.Grades.Where(g => g.Name.Equals("Level 2")).First();

            var studentAddress = new StudentAddress
            {
                Address1 = "Princes st",
                Address2 = "Chineham",
                CityOrTown = "Basingstoke",
                County = "Hampshire"
            };

            var students = new List<Student>
            {
                new Student{FirstName="Tom", LastName="Jones", Age=14 , GradeId=grade1.GradeId, StudentAddress = studentAddress },
                new Student{FirstName="Mark", LastName="Jones",Age=12, GradeId=grade1.GradeId, StudentAddress = studentAddress},
                new Student{FirstName="Chris", LastName="Jones",Age=12, GradeId=grade1.GradeId, StudentAddress = studentAddress,},
                new Student{FirstName="Anthony", LastName="Smith",Age=11, GradeId=grade1.GradeId, StudentAddress = studentAddress,},
                new Student{FirstName="Jamie", LastName="Smith",Age=14, GradeId=grade2.GradeId,StudentAddress = studentAddress,},
                new Student{FirstName="Marcus", LastName="Wright",Age=13, GradeId=grade2.GradeId, StudentAddress = studentAddress,},
                new Student{FirstName="Ian", LastName="Markus",Age=14, GradeId=grade2.GradeId, StudentAddress = studentAddress,},
            };

            students.ForEach(s => context.Students.Add(s));


            var departments = new List<Department>
            {
                new Department{Administrator="Dr Jones",Title ="Engineering"},
                new Department{Administrator="Dr Jones",Title ="English"},
                new Department{Administrator="Dr Jones",Title ="Economics"}
            };

            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();


            var courses = new List<Course>
            {
                new Course{Name="Calculus",Duration=6, Location = "Main campus",DepartmentId =1},
                new Course{Name="Chemistry",Duration=6, Location = "Main campus", DepartmentId = 1},
                new Course{Name="Physics",Duration=6, Location = "Main campus", DepartmentId = 1},
                new Course{Name="Poetry",Duration=6, Location = "Main campus", DepartmentId = 2},
                new Course{Name="Literature",Duration=6, Location = "Main campus", DepartmentId = 2},
                new Course{Name="Macroeconomics",Duration=6, Location = "Main campus", DepartmentId = 3}, 
                new Course{Name="Microeconomics",Duration=6, Location = "Main campus", DepartmentId = 3},
            };

            courses.ForEach(s => context.Courses.Add(s));

            context.SaveChanges();

        }
    }
}

