namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        Hobby = c.String(),
                        PictureURL = c.String(),
                        SchoolGroup_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SchoolGroups", t => t.SchoolGroup_ID)
                .Index(t => t.SchoolGroup_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        Hobby = c.String(),
                        PictureURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherSchoolGroups",
                c => new
                    {
                        Teacher_ID = c.Int(nullable: false),
                        SchoolGroup_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.SchoolGroup_ID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .ForeignKey("dbo.SchoolGroups", t => t.SchoolGroup_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID)
                .Index(t => t.SchoolGroup_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSchoolGroups", "SchoolGroup_ID", "dbo.SchoolGroups");
            DropForeignKey("dbo.TeacherSchoolGroups", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Students", "SchoolGroup_ID", "dbo.SchoolGroups");
            DropIndex("dbo.TeacherSchoolGroups", new[] { "SchoolGroup_ID" });
            DropIndex("dbo.TeacherSchoolGroups", new[] { "Teacher_ID" });
            DropIndex("dbo.Students", new[] { "SchoolGroup_ID" });
            DropTable("dbo.TeacherSchoolGroups");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.SchoolGroups");
        }
    }
}
