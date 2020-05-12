namespace BingoCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "IsEnableLine", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Player", "AvatarID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Player", "AvatarID", c => c.Int(nullable: false));
            DropColumn("dbo.Player", "IsEnableLine");
        }
    }
}
