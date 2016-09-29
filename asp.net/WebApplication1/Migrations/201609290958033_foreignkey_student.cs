namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey_student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "SchoolGroup_Id", "dbo.SchoolGroups");
            DropIndex("dbo.Students", new[] { "SchoolGroup_Id" });
            RenameColumn(table: "dbo.Students", name: "SchoolGroup_Id", newName: "SchoolGroupId");
            AlterColumn("dbo.Students", "SchoolGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "SchoolGroupId");
            AddForeignKey("dbo.Students", "SchoolGroupId", "dbo.SchoolGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SchoolGroupId", "dbo.SchoolGroups");
            DropIndex("dbo.Students", new[] { "SchoolGroupId" });
            AlterColumn("dbo.Students", "SchoolGroupId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "SchoolGroupId", newName: "SchoolGroup_Id");
            CreateIndex("dbo.Students", "SchoolGroup_Id");
            AddForeignKey("dbo.Students", "SchoolGroup_Id", "dbo.SchoolGroups", "Id");
        }
    }
}
