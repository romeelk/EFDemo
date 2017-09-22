using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class Student
    {

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Grade Grade { get; set; }
        
        //Use in Fluent mapping
        public int GradeId { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
    }
}
