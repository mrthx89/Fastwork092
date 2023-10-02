namespace EM4.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StokPengembalian : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TStockOut", new[] { "DocNo" });
            CreateTable(
                "dbo.TStockPengembalian",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        DocNo = c.String(nullable: false, maxLength: 30),
                        IDInventor = c.Guid(nullable: false),
                        IDUOM = c.Guid(nullable: false),
                        Qty = c.Single(nullable: false),
                        Keterangan = c.String(maxLength: 255),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TInventor", t => t.IDInventor)
                .ForeignKey("dbo.TUOM", t => t.IDUOM)
                .Index(t => t.DocNo)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM);
            
            CreateIndex("dbo.TTypeTransaction", "NoUrut", unique: true);
            CreateIndex("dbo.TStockOut", "DocNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TStockPengembalian", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TStockPengembalian", "IDInventor", "dbo.TInventor");
            DropIndex("dbo.TStockPengembalian", new[] { "IDUOM" });
            DropIndex("dbo.TStockPengembalian", new[] { "IDInventor" });
            DropIndex("dbo.TStockPengembalian", new[] { "DocNo" });
            DropIndex("dbo.TStockOut", new[] { "DocNo" });
            DropIndex("dbo.TTypeTransaction", new[] { "NoUrut" });
            DropTable("dbo.TStockPengembalian");
            CreateIndex("dbo.TStockOut", "DocNo", unique: true);
        }
    }
}
