namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hebergeenzinmeerin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "PictureURL");
            DropColumn("dbo.Teachers", "PictureURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "PictureURL", c => c.String());
            AddColumn("dbo.Students", "PictureURL", c => c.String());
        }
    }
}
