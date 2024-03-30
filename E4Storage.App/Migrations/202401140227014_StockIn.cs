namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockIn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TStockOut", "IDBelt", "dbo.TBelt");
            DropForeignKey("dbo.TStockOut", "IDCategory", "dbo.TCategory");
            DropIndex("dbo.TStockOut", new[] { "IDBelt" });
            DropIndex("dbo.TStockOut", new[] { "IDCategory" });
            AddColumn("dbo.TStockOut", "TBelt_ID", c => c.Guid());
            AddColumn("dbo.TStockOut", "TCategory_ID", c => c.Guid());
            AddColumn("dbo.TStockIn", "IDBelt", c => c.Guid());
            AddColumn("dbo.TStockIn", "PIC", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.TStockIn", "IDCategory", c => c.Guid());
            AddColumn("dbo.TStockIn", "Cabinet", c => c.Int());
            AddColumn("dbo.TStockIn", "Row", c => c.String(maxLength: 255));
            AlterColumn("dbo.TStockOut", "IDBelt", c => c.Guid());
            AlterColumn("dbo.TStockOut", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockCard", "IDBelt", c => c.Guid());
            CreateIndex("dbo.TBelt", "Belt", unique: true);
            CreateIndex("dbo.TStockOut", "TBelt_ID");
            CreateIndex("dbo.TStockOut", "TCategory_ID");
            CreateIndex("dbo.TCategory", "Category", unique: true);
            AddForeignKey("dbo.TStockOut", "TBelt_ID", "dbo.TBelt", "ID");
            AddForeignKey("dbo.TStockOut", "TCategory_ID", "dbo.TCategory", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TStockOut", "TCategory_ID", "dbo.TCategory");
            DropForeignKey("dbo.TStockOut", "TBelt_ID", "dbo.TBelt");
            DropIndex("dbo.TCategory", new[] { "Category" });
            DropIndex("dbo.TStockOut", new[] { "TCategory_ID" });
            DropIndex("dbo.TStockOut", new[] { "TBelt_ID" });
            DropIndex("dbo.TBelt", new[] { "Belt" });
            AlterColumn("dbo.TStockCard", "IDBelt", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockOut", "IDCategory", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockOut", "IDBelt", c => c.Guid(nullable: false));
            DropColumn("dbo.TStockIn", "Row");
            DropColumn("dbo.TStockIn", "Cabinet");
            DropColumn("dbo.TStockIn", "IDCategory");
            DropColumn("dbo.TStockIn", "PIC");
            DropColumn("dbo.TStockIn", "IDBelt");
            DropColumn("dbo.TStockOut", "TCategory_ID");
            DropColumn("dbo.TStockOut", "TBelt_ID");
            CreateIndex("dbo.TStockOut", "IDCategory");
            CreateIndex("dbo.TStockOut", "IDBelt");
            AddForeignKey("dbo.TStockOut", "IDCategory", "dbo.TCategory", "ID");
            AddForeignKey("dbo.TStockOut", "IDBelt", "dbo.TBelt", "ID");
        }
    }
}
