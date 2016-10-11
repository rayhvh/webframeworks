using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class SchoolGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
      //  [Required]
        public  ICollection<Student> Students { get; set; } //virtual uitzetten voor eager loading ipv lazy loading.
       // [Required]
        public   ICollection<Teacher> Teachers { get; set; }

    }
}