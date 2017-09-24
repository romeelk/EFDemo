using SchoolEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo
{
    class Queries
    {
        public void SlowBulkInserts()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var dbContext = new SchoolContext();

            for (int i = 0; i < 2000; i++)
            {
                var student = GetNewStudent(i);
                dbContext.Students.Add(student);
            }
            dbContext.SaveChanges();
            watch.Stop();
            Console.WriteLine($"Slow insert took {watch.Elapsed.Seconds} seconds");

        }

        public void FastBulkInserts()
        {
            Stopwatch watch = new Stopwatch();
            
            var dbContext = new SchoolContext();
            dbContext.Configuration.AutoDetectChangesEnabled = true;
            dbContext.Configuration.ValidateOnSaveEnabled = true;
         
            var students = new List<Student>();

            for (int i = 0; i < 2000; i++)
            {
                var student = GetNewStudent(i);
                students.Add(student);
            }
            watch.Start();

            dbContext.Students.AddRange(students);

            dbContext.SaveChanges();
            watch.Stop();
            Console.WriteLine($"Fast insert took {watch.Elapsed.Seconds} seconds");
        }

        private Student GetNewStudent(int count)
        {
            return new Student {FirstName = "Tom"+count,LastName="Smith",GradeId=1,Age = 12};
        }

        public void EntityLifeCycle()
        {
            var context = new SchoolContext();

            using (context)
            {
                var student = new Student { FirstName = "John", LastName = "Jones", Age = 15 ,GradeId = 1};

                Console.WriteLine(context.Entry(student).State);

                context.Students.Add(student);
             
                Console.WriteLine(context.Entry(student).State);

                context.SaveChanges();

                student.FirstName = "Neil";

                Console.WriteLine(context.Entry(student).State);

            }
        }
        public void FirstLevelCache()
        {
            var context = new SchoolContext();

            using(context)
            {
                var course = context.Courses.Find(1);

                var secondCall = context.Courses.Find(1);
            }
        }
        public void LazyLoading()
        {
            var context = new SchoolContext();

            using (context)
            {
                context.Configuration.LazyLoadingEnabled = false;

                //Eager
                var student = context.Students.Where(t => t.StudentId.Equals(1)).First();

                //Eager without StudentAddress
                //var student = context.Students.Include("StudentAddress").Where(t => t.StudentId.Equals(1)).First();
                //Lazy
                //var student = context.Students.Where(t => t.StudentId.Equals(1)).First();

                var studentAddress = student.StudentAddress;

                var address = student.StudentAddress;
            }
        }

        internal void NPlus1Problem()
        {
            var context = new SchoolContext();

            using (context)
            {
                foreach(var department in context.Departments)
                {
                    foreach (var course in department.Courses)
                    {
                        Console.WriteLine("{0}: {1}", department.Title, course.Name);
                    }
                }
            }
        }

        public void GreedyRowQuery()
        {
            var context = new SchoolContext();

            using (context)
            {
                context.Configuration.LazyLoadingEnabled = false;

                var student = context.Students.ToList();

                var studentAddress = student.Where(t => t.StudentId.Equals(1));
            }
        }

        public void GreedyColumnQuery()
        {         
            var context = new SchoolContext();
            using (context)
            {
                //bad
                var students = context.Students.ToList();

                //better for indexing
                var student = context.Students.Where(t => t.StudentId.Equals(1)).Select(t => new { t.Age, t.FirstName }).FirstOrDefault();
            }
        }

        public void StoredProcedure()
        {
            var context = new SchoolContext();
            using (context)
            {
                var students = context.Database.SqlQuery<Student>("GetStudents");
            }
        }


    }
}
