using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class SchoolGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Student> Students { get; set; } //virtual?
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}