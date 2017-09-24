using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
