namespace E4Storage.App.Migrations
{
    using E4Storage.App.Model.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E4Storage.App.Data.E4StorageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // Atur ke false untuk menghindari kehilangan data
        }

        protected override void Seed(E4Storage.App.Data.E4StorageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            TUser sysAdmin = new TUser {
                ID = Guid.Parse("EC82D19B-14AD-41E6-90BE-ED2B17855BF3"),
                IDUserEntri = Guid.Parse("EC82D19B-14AD-41E6-90BE-ED2B17855BF3"),
                IDUserEdit = Guid.Empty,
                IDUserHapus = Guid.Empty,
                IsAdmin = true,
                Nama = "Admin",
                Password = Repository.Utils.GetHash("SysAdmin".ToUpper()),
                TglEntri = DateTime.Now,
                UserID = "SysAdmin"
            };
            if (context.TUsers.FirstOrDefault(o => o.ID.Equals(sysAdmin.ID)) == null)
            {
                context.TUsers.Add(sysAdmin);
            }

            TTypeTransaction typeTransaction = new TTypeTransaction
            {
                ID = Utils.Constant.stokInType,
                Transaksi = "Stok Masuk",
                NoUrut = 1,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction);
            }

            TTypeTransaction typeTransaction2 = new TTypeTransaction
            {
                ID = Utils.Constant.stokOutType,
                Transaksi = "Stok Keluar",
                NoUrut = 4,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction2.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction2);
            }

            TTypeTransaction typeTransaction3 = new TTypeTransaction
            {
                ID = Utils.Constant.stokPengembalianType,
                Transaksi = "Stok Pengembalian",
                NoUrut = 3,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction3.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction3);
            }
            
            TTypeTransaction typeTransaction4 = new TTypeTransaction
            {
                ID = Utils.Constant.stokSaldoAwal,
                Transaksi = "Saldo Awal",
                NoUrut = -1,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction4.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction4);
            }

            TTypeTransaction typeTransaction5 = new TTypeTransaction
            {
                ID = Utils.Constant.stokMasterDataType,
                Transaksi = "Master Data",
                NoUrut = 2,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction5.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction5);
            }

            context.SaveChanges();
        }
    }
}
