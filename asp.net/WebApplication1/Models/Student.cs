using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string SchoolGroup { get; set; }

     //   public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}