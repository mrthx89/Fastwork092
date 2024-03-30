namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockIn2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TStockIn", new[] { "NoPO" });
            AlterColumn("dbo.TStockIn", "NoPO", c => c.String(maxLength: 30));
            CreateIndex("dbo.TStockIn", "NoPO");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TStockIn", new[] { "NoPO" });
            AlterColumn("dbo.TStockIn", "NoPO", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.TStockIn", "NoPO");
        }
    }
}
