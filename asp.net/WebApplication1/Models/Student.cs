using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }

        public string Password { get; set; }

        public int SchoolGroupId { get; set; }
     //   [Required]
        [ForeignKey("SchoolGroupId")]
        public virtual SchoolGroup SchoolGroup { get; set; }

        public string Hobby { get; set; }
        public string PictureURL { get; set; }

    }
}