namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "ImageURL");
        }
    }
}
