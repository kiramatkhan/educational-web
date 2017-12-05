namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropColumn("dbo.Classes", "TeacherId");
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FatherName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        CNIC = c.String(),
                        Email = c.String(),
                        ContactNumber = c.String(),
                        PresentAddress = c.String(),
                        PermenentAddress = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Classes", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "TeacherId");
            AddForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers", "id", cascadeDelete: true);
        }
    }
}
