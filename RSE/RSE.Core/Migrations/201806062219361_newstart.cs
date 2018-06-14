namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newstart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnsDescription = c.String(),
                        Exercise_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.Exercise_Id)
                .Index(t => t.Exercise_Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Description = c.String(),
                        Variant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Variants", t => t.Variant_Id)
                .Index(t => t.Variant_Id);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Exercise_Id", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "Variant_Id", "dbo.Variants");
            DropIndex("dbo.Exercises", new[] { "Variant_Id" });
            DropIndex("dbo.Answers", new[] { "Exercise_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Variants");
            DropTable("dbo.Exercises");
            DropTable("dbo.Answers");
        }
    }
}
