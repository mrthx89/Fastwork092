namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockPengembalian : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TStockMasterData", "IDBelt", c => c.Guid());
            AddColumn("dbo.TStockMasterData", "PIC", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.TStockMasterData", "IDCategory", c => c.Guid());
            AddColumn("dbo.TStockMasterData", "Cabinet", c => c.Int());
            AddColumn("dbo.TStockMasterData", "Row", c => c.String(maxLength: 255));
            AddColumn("dbo.TStockPengembalian", "IDBelt", c => c.Guid());
            AddColumn("dbo.TStockPengembalian", "PIC", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.TStockPengembalian", "IDCategory", c => c.Guid());
            AddColumn("dbo.TStockPengembalian", "Cabinet", c => c.Int());
            AddColumn("dbo.TStockPengembalian", "Row", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TStockPengembalian", "Row");
            DropColumn("dbo.TStockPengembalian", "Cabinet");
            DropColumn("dbo.TStockPengembalian", "IDCategory");
            DropColumn("dbo.TStockPengembalian", "PIC");
            DropColumn("dbo.TStockPengembalian", "IDBelt");
            DropColumn("dbo.TStockMasterData", "Row");
            DropColumn("dbo.TStockMasterData", "Cabinet");
            DropColumn("dbo.TStockMasterData", "IDCategory");
            DropColumn("dbo.TStockMasterData", "PIC");
            DropColumn("dbo.TStockMasterData", "IDBelt");
        }
    }
}
