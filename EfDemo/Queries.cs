using SchoolEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo
{
    class Queries
    {
        public void LazyLoading()
        {
            var context = new SchoolContext();

            context.Configuration.LazyLoadingEnabled = false;

            //Eager
            //var student = context.Students.Include("StudentAddress").Where(t => t.StudentId.Equals(1)).First();
            //Lazy
            var student = context.Students.Where(t => t.StudentId.Equals(1)).First();

            var studentAddress = student.StudentAddress;

            var address = student.StudentAddress;

        }

        public void GreedyRowQuery()
        {
            var context = new SchoolContext();

            context.Configuration.LazyLoadingEnabled = false;
          
            var student = context.Students.ToList();

            var studentAddress = student.Where(t => t.StudentId.Equals(1));
        }

        public void GreedyColumnQuery()
        {
            var context = new SchoolContext();

            //bad
            var students = context.Students.ToList();

            //better for indexing
            var student = context.Students.Where(t => t.StudentId.Equals(1)).Select(t => new { t.Age, t.FirstName }).FirstOrDefault();

        }
    }
}
