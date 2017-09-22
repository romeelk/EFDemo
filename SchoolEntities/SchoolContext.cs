using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class SchoolContext : DbContext
    {

        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
       
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
              .HasOptional(s => s.StudentAddress) // Mark Address property optional in Student entity
              .WithRequired(ad => ad.Student); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            modelBuilder.Entity<StudentAddress>().HasKey(t => t.StudentId);

            modelBuilder.Entity<Student>()
                .HasRequired<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey<int>(s => s.GradeId);

        }
    }
    
}
