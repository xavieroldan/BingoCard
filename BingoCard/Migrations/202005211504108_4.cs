namespace BingoCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "WinnerPlayer", c => c.Guid(nullable: false));
            AddColumn("dbo.Room", "LinePlayer", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "LinePlayer");
            DropColumn("dbo.Room", "WinnerPlayer");
        }
    }
}
