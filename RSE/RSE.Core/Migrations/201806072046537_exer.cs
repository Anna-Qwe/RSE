namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Answer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "Answer");
        }
    }
}
