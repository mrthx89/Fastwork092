using E4Storage.App.Model.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations;
using System.Linq;

namespace E4Storage.App.Data
{
    public partial class E4StorageContext : DbContext
    {
        public E4StorageContext()
            : base("name=E4Storage")
        {

        }

        public E4StorageContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<TTypeTransaction> TTypeTransactions { get; set; }
        public DbSet<TUOM> TUOMs { get; set; }
        public DbSet<TUser> TUsers { get; set; }
        public DbSet<TBelt> TBelts { get; set; }
        public DbSet<TInventor> TInventors { get; set; }
        public DbSet<TStockIn> TStockIns { get; set; }
        public DbSet<TStockOut> TStockOuts { get; set; }
        public DbSet<TStockCard> TStockCards { get; set; }
        public DbSet<TStockPengembalian> TStockPengembalians { get; set; }
        public DbSet<TStockMasterData> TStockMasterDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TTypeTransaction>()
                .Property(p => p.NoUrut)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NoUrut") { IsUnique = true }));

            modelBuilder.Entity<TTypeTransaction>()
                .Property(p => p.Transaksi)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Transaksi") { IsUnique = true }));

            modelBuilder.Entity<TUser>()
                .Property(p => p.UserID)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UserID") { IsUnique = true }));

            modelBuilder.Entity<TUOM>()
                .Property(p => p.Satuan)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Satuan") { IsUnique = true }));

            modelBuilder.Entity<TInventor>()
                .Property(p => p.PLU)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PLU") { IsUnique = true }));

            modelBuilder.Entity<TStockIn>()
                .Property(p => p.NoPO)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NoPO")));

            modelBuilder.Entity<TStockIn>()
                .Property(p => p.NoSJ)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NoSJ")));

            modelBuilder.Entity<TStockOut>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo")));

            modelBuilder.Entity<TStockPengembalian>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo")));

            modelBuilder.Entity<TStockMasterData>()
                .Property(p => p.DocNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DocNo")));


            modelBuilder.Entity<TStockCard>()
                .HasIndex(p => new { p.IDTransaksiD, p.IDType })
                .IsUnique();

            modelBuilder.Entity<TInventor>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.Inventors)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.TypeTransaction)
                .WithMany(a => a.StockCards)
                .HasForeignKey(b => b.IDType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.Inventor) 
                .WithMany(a => a.StockCards) 
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.Inventor)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDInventor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockCard>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockCards)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockIn>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockIns)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockPengembalian>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockPengembalians)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockOut>()
                .HasRequired(b => b.Belt)
                .WithMany(a => a.StockOuts)
                .HasForeignKey(b => b.IDBelt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TStockMasterData>()
                .HasRequired(b => b.UOM)
                .WithMany(a => a.StockMasterDatas)
                .HasForeignKey(b => b.IDUOM)
                .WillCascadeOnDelete(false);
        }
    }
}
