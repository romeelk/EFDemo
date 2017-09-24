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
          
            Database.SetInitializer<SchoolContext>(new SchoolInitializer());

            //queries.EntityLifeCycle();
            //queries.FirstLevelCache);
            //queries.NPlus1Problem();          
            //queries.SlowBulkInserts();
            queries.FastBulkInserts();
            //queries.GreedyRowQuery();
            //queries.GreedyColumnQuery();
            //queries.StoredProcedure();

            Console.WriteLine();
        }
    }
}
