using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class StudentAddress
    {
        //[ForeignKey("Student")]
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string CityOrTown { get; set; }

        public string County { get; set; }
        public virtual Student Student { get; set; }
    }
}
