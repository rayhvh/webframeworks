namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "VIP", c => c.Boolean(nullable: false));
            AddColumn("dbo.Teachers", "VIP", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "VIP");
            DropColumn("dbo.Students", "VIP");
        }
    }
}
