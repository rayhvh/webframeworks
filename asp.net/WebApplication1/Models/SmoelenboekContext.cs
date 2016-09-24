using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Smoelenboek.Models
{
    public class SmoelenboekContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SmoelenboekContext() : base("name=SmoelenboekContext")
        {
        }

        public System.Data.Entity.DbSet<Smoelenboek.Models.SchoolGroup> SchoolGroups { get; set; }

        public System.Data.Entity.DbSet<Smoelenboek.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<Smoelenboek.Models.Teacher> Teachers { get; set; }
    }
}
