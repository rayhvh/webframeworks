using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class SchoolGroup
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public virtual List<Student> Student { get; set; } //virtual?
        public virtual List<Teacher> Teacher { get; set; }

    }
}