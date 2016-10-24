using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<SchoolGroup> SchoolGroups { get; set; } //meervoud als je er meer hebt?
        public string Hobby { get; set; }
      
    }
}