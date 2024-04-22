namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TStockInRev1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TStockIn", new[] { "NoSJ" });
            AlterColumn("dbo.TStockIn", "NoSJ", c => c.String(maxLength: 30));
            AlterColumn("dbo.TStockIn", "Supplier", c => c.String(maxLength: 150));
            AlterColumn("dbo.TStockIn", "PIC", c => c.String(maxLength: 150));
            CreateIndex("dbo.TStockIn", "NoSJ");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TStockIn", new[] { "NoSJ" });
            AlterColumn("dbo.TStockIn", "PIC", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.TStockIn", "Supplier", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.TStockIn", "NoSJ", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.TStockIn", "NoSJ");
        }
    }
}
