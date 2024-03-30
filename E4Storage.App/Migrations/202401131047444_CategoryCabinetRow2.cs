namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryCabinetRow2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TStockOut", "Cabinet", c => c.Int());
            AlterColumn("dbo.TStockOut", "Row", c => c.String(maxLength: 255));
            AlterColumn("dbo.TStockCard", "IDCategory", c => c.Guid());
            AlterColumn("dbo.TStockCard", "Cabinet", c => c.Int());
            AlterColumn("dbo.TStockCard", "Row", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TStockCard", "Row", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TStockCard", "Cabinet", c => c.Int(nullable: false));
            AlterColumn("dbo.TStockCard", "IDCategory", c => c.Guid(nullable: false));
            AlterColumn("dbo.TStockOut", "Row", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TStockOut", "Cabinet", c => c.Int(nullable: false));
        }
    }
}
