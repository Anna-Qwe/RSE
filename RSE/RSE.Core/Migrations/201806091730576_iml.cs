namespace RSE.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iml : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "ImgURL", c => c.String());
            DropColumn("dbo.Exercises", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "ImageURL", c => c.String());
            DropColumn("dbo.Exercises", "ImgURL");
        }
    }
}
