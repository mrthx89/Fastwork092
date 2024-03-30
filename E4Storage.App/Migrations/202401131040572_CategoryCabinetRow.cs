namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryCabinetRow : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TStockOut", new[] { "DocNo" });
            CreateTable(
                "dbo.TCategory",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Category = c.String(nullable: false, maxLength: 20),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.TStockOut", "IDCategory", c => c.Guid(nullable: false));
            AddColumn("dbo.TStockOut", "Cabinet", c => c.Int(nullable: false));
            AddColumn("dbo.TStockOut", "Row", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TInventor", "QtyMin", c => c.String());
            AddColumn("dbo.TInventor", "QtyMax", c => c.String());
            AddColumn("dbo.TStockCard", "IDCategory", c => c.Guid(nullable: false));
            AddColumn("dbo.TStockCard", "Cabinet", c => c.Int(nullable: false));
            AddColumn("dbo.TStockCard", "Row", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TStockOut", "DocNo", c => c.String(maxLength: 30));
            CreateIndex("dbo.TStockOut", "DocNo");
            CreateIndex("dbo.TStockOut", "IDCategory");
            AddForeignKey("dbo.TStockOut", "IDCategory", "dbo.TCategory", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TStockOut", "IDCategory", "dbo.TCategory");
            DropIndex("dbo.TStockOut", new[] { "IDCategory" });
            DropIndex("dbo.TStockOut", new[] { "DocNo" });
            AlterColumn("dbo.TStockOut", "DocNo", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.TStockCard", "Row");
            DropColumn("dbo.TStockCard", "Cabinet");
            DropColumn("dbo.TStockCard", "IDCategory");
            DropColumn("dbo.TInventor", "QtyMax");
            DropColumn("dbo.TInventor", "QtyMin");
            DropColumn("dbo.TStockOut", "Row");
            DropColumn("dbo.TStockOut", "Cabinet");
            DropColumn("dbo.TStockOut", "IDCategory");
            DropTable("dbo.TCategory");
            CreateIndex("dbo.TStockOut", "DocNo");
        }
    }
}
