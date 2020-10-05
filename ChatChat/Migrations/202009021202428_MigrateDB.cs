namespace ChatChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ImageRout", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ImageRout");
        }
    }
}
