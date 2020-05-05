namespace BingoCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsLine = c.Boolean(nullable: false),
                        IsBingo = c.Boolean(nullable: false),
                        Player_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        BingoCount = c.Int(nullable: false),
                        LineCount = c.Int(nullable: false),
                        AvatarID = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        RoomName = c.String()
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Square",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CardId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        IsMarked = c.Boolean(nullable: false),
                        Column = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        IsBlank = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Card", "Player_Id", "dbo.Player");
            DropIndex("dbo.Card", new[] { "Player_Id" });
            DropTable("dbo.Square");
            DropTable("dbo.Room");
            DropTable("dbo.Player");
            DropTable("dbo.Card");
        }
    }
}
