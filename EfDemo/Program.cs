using SchoolEntities;
using System;
using System.Data.Entity;
using System.Linq;

namespace EfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = new Queries();
            var schoolContext = new SchoolEntities.SchoolContext();

            Database.SetInitializer<SchoolContext>(new SchoolInitializer());

            using (schoolContext)
            {
                var schools = schoolContext.Students.ToList();

                foreach (var item in schools)
                {
                    Console.WriteLine(item.FirstName, item.LastName);
                }
            }

            queries.LazyLoading();
            queries.GreedyRowQuery();
            queries.GreedyColumnQuery();
        }
    }
}
