using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }


        public int SchoolGroupId { get; set; }

        [ForeignKey("SchoolGroupId")]
        public virtual SchoolGroup SchoolGroup { get; set; }

        public string Hobby { get; set; }
        public string PictureURL { get; set; }

    }
}