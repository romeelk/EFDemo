﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class Grade
    {

        public int GradeId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
