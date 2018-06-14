namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Phone", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Email");
        }
    }
}
