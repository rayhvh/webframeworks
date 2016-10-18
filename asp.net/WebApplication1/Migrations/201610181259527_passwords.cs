namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Password", c => c.String());
            AddColumn("dbo.Teachers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Password");
            DropColumn("dbo.Students", "Password");
        }
    }
}
