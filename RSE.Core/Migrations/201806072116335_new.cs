namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "Variant_Id", "dbo.Variants");
            DropIndex("dbo.Exercises", new[] { "Variant_Id" });
            DropColumn("dbo.Exercises", "Variant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Variant_Id", c => c.Int());
            CreateIndex("dbo.Exercises", "Variant_Id");
            AddForeignKey("dbo.Exercises", "Variant_Id", "dbo.Variants", "Id");
        }
    }
}
