using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Administrator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
