namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Exercise_Id", "dbo.Exercises");
            DropIndex("dbo.Answers", new[] { "Exercise_Id" });
            AddColumn("dbo.Exercises", "Variant_Id", c => c.Int());
            CreateIndex("dbo.Exercises", "Variant_Id");
            AddForeignKey("dbo.Exercises", "Variant_Id", "dbo.Variants", "Id");
            DropTable("dbo.Answers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnsDescription = c.String(),
                        Exercise_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Exercises", "Variant_Id", "dbo.Variants");
            DropIndex("dbo.Exercises", new[] { "Variant_Id" });
            DropColumn("dbo.Exercises", "Variant_Id");
            CreateIndex("dbo.Answers", "Exercise_Id");
            AddForeignKey("dbo.Answers", "Exercise_Id", "dbo.Exercises", "Id");
        }
    }
}
