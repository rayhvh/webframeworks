namespace Smoelenboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "SchoolGroup_ID" });
            DropIndex("dbo.TeacherSchoolGroups", new[] { "Teacher_ID" });
            DropIndex("dbo.TeacherSchoolGroups", new[] { "SchoolGroup_ID" });
            CreateIndex("dbo.Students", "SchoolGroup_Id");
            CreateIndex("dbo.TeacherSchoolGroups", "Teacher_Id");
            CreateIndex("dbo.TeacherSchoolGroups", "SchoolGroup_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TeacherSchoolGroups", new[] { "SchoolGroup_Id" });
            DropIndex("dbo.TeacherSchoolGroups", new[] { "Teacher_Id" });
            DropIndex("dbo.Students", new[] { "SchoolGroup_Id" });
            CreateIndex("dbo.TeacherSchoolGroups", "SchoolGroup_ID");
            CreateIndex("dbo.TeacherSchoolGroups", "Teacher_ID");
            CreateIndex("dbo.Students", "SchoolGroup_ID");
        }
    }
}
