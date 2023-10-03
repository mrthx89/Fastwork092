namespace EM4.App.Migrations
{
    using EM4.App.Model.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EM4.App.Data.EM4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // Atur ke false untuk menghindari kehilangan data
        }

        protected override void Seed(EM4.App.Data.EM4Context context)
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
                ID = Guid.Parse("C889E2DF-D056-4DAD-B935-E47921035811"),
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
                ID = Guid.Parse("6652E843-6C01-4CD0-9F9C-5111565D7844"),
                Transaksi = "Stok Keluar",
                NoUrut = 2,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction2.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction2);
            }

            TTypeTransaction typeTransaction3 = new TTypeTransaction
            {
                ID = Guid.Parse("B536F89C-FA4E-4F7B-AFDB-5B323546D10E"),
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
                ID = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220"),
                Transaksi = "Saldo Awal",
                NoUrut = -1,
                IDUserEntri = sysAdmin.ID,
                TglEntri = DateTime.Now
            };
            if (context.TTypeTransactions.FirstOrDefault(o => o.ID.Equals(typeTransaction4.ID)) == null)
            {
                context.TTypeTransactions.Add(typeTransaction4);
            }

            context.SaveChanges();
        }
    }
}
