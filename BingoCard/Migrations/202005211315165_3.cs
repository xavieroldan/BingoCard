namespace BingoCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "RoomId", c => c.Guid(nullable: false));
            DropColumn("dbo.Player", "RoomName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "RoomName", c => c.String());
            DropColumn("dbo.Player", "RoomId");
        }
    }
}
