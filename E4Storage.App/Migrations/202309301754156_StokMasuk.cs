namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StokMasuk : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TStockIn", new[] { "DocNo" });
            AddColumn("dbo.TStockIn", "NoPO", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.TStockIn", "NoSJ", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.TStockIn", "Supplier", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.TStockIn", "NoPO");
            CreateIndex("dbo.TStockIn", "NoSJ");
            DropColumn("dbo.TStockIn", "DocNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TStockIn", "DocNo", c => c.String(nullable: false, maxLength: 30));
            DropIndex("dbo.TStockIn", new[] { "NoSJ" });
            DropIndex("dbo.TStockIn", new[] { "NoPO" });
            DropColumn("dbo.TStockIn", "Supplier");
            DropColumn("dbo.TStockIn", "NoSJ");
            DropColumn("dbo.TStockIn", "NoPO");
            CreateIndex("dbo.TStockIn", "DocNo", unique: true);
        }
    }
}
