namespace EM4.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeltPICStockCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TStockCard", "Belt", c => c.String(maxLength: 100));
            AddColumn("dbo.TStockCard", "PIC", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TStockCard", "PIC");
            DropColumn("dbo.TStockCard", "Belt");
        }
    }
}
