namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "FirstMidName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FirstMidName", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
        }
    }
}
