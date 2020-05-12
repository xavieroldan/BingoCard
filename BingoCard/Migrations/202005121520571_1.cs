namespace BingoCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("Room", "Color", "Message");
        }
        
        public override void Down()
        {
        }
    }
}
