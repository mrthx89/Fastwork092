namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TInventor",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PLU = c.String(nullable: false, maxLength: 50),
                        Desc = c.String(nullable: false, maxLength: 150),
                        IDUOM = c.Guid(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TUOM", t => t.IDUOM)
                .Index(t => t.PLU, unique: true)
                .Index(t => t.IDUOM);
            
            CreateTable(
                "dbo.TStockCard",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        DocNo = c.String(nullable: false, maxLength: 30),
                        IDInventor = c.Guid(nullable: false),
                        IDUOM = c.Guid(nullable: false),
                        IDTransaksi = c.Guid(nullable: false),
                        IDTransaksiD = c.Guid(nullable: false),
                        IDType = c.Guid(nullable: false),
                        QtyMasuk = c.Single(nullable: false),
                        QtyKeluar = c.Single(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TInventor", t => t.IDInventor)
                .ForeignKey("dbo.TTypeTransaction", t => t.IDType)
                .ForeignKey("dbo.TUOM", t => t.IDUOM)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM)
                .Index(t => new { t.IDTransaksiD, t.IDType }, unique: true);
            
            CreateTable(
                "dbo.TTypeTransaction",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Transaksi = c.String(nullable: false, maxLength: 100),
                        NoUrut = c.Int(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Transaksi, unique: true);
            
            CreateTable(
                "dbo.TUOM",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Satuan = c.String(nullable: false, maxLength: 20),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Satuan, unique: true);
            
            CreateTable(
                "dbo.TStockIn",
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
                .Index(t => t.DocNo, unique: true)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM);
            
            CreateTable(
                "dbo.TStockOut",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Tanggal = c.DateTime(nullable: false),
                        DocNo = c.String(nullable: false, maxLength: 30),
                        IDInventor = c.Guid(nullable: false),
                        IDUOM = c.Guid(nullable: false),
                        Qty = c.Single(nullable: false),
                        Belt = c.String(nullable: false, maxLength: 100),
                        PIC = c.String(nullable: false, maxLength: 150),
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
                .Index(t => t.DocNo, unique: true)
                .Index(t => t.IDInventor)
                .Index(t => t.IDUOM);
            
            CreateTable(
                "dbo.TUser",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 100),
                        Nama = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 100),
                        IsAdmin = c.Boolean(nullable: false),
                        IDUserEntri = c.Guid(nullable: false),
                        TglEntri = c.DateTime(),
                        IDUserEdit = c.Guid(nullable: false),
                        TglEdit = c.DateTime(),
                        IDUserHapus = c.Guid(nullable: false),
                        TglHapus = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserID, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TInventor", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TStockCard", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TStockOut", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TStockOut", "IDInventor", "dbo.TInventor");
            DropForeignKey("dbo.TStockIn", "IDUOM", "dbo.TUOM");
            DropForeignKey("dbo.TStockIn", "IDInventor", "dbo.TInventor");
            DropForeignKey("dbo.TStockCard", "IDType", "dbo.TTypeTransaction");
            DropForeignKey("dbo.TStockCard", "IDInventor", "dbo.TInventor");
            DropIndex("dbo.TUser", new[] { "UserID" });
            DropIndex("dbo.TStockOut", new[] { "IDUOM" });
            DropIndex("dbo.TStockOut", new[] { "IDInventor" });
            DropIndex("dbo.TStockOut", new[] { "DocNo" });
            DropIndex("dbo.TStockIn", new[] { "IDUOM" });
            DropIndex("dbo.TStockIn", new[] { "IDInventor" });
            DropIndex("dbo.TStockIn", new[] { "DocNo" });
            DropIndex("dbo.TUOM", new[] { "Satuan" });
            DropIndex("dbo.TTypeTransaction", new[] { "Transaksi" });
            DropIndex("dbo.TStockCard", new[] { "IDTransaksiD", "IDType" });
            DropIndex("dbo.TStockCard", new[] { "IDUOM" });
            DropIndex("dbo.TStockCard", new[] { "IDInventor" });
            DropIndex("dbo.TInventor", new[] { "IDUOM" });
            DropIndex("dbo.TInventor", new[] { "PLU" });
            DropTable("dbo.TUser");
            DropTable("dbo.TStockOut");
            DropTable("dbo.TStockIn");
            DropTable("dbo.TUOM");
            DropTable("dbo.TTypeTransaction");
            DropTable("dbo.TStockCard");
            DropTable("dbo.TInventor");
        }
    }
}
