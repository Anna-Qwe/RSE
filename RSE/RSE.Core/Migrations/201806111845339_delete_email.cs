namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_email : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
        }
    }
}
