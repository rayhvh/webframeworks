using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public virtual List<SchoolGroup> SchoolGroups { get; set; } //meervoud als je er meer hebt?
        public string Hobby { get; set; }
        public string PictureURL { get; set; }
    }
}