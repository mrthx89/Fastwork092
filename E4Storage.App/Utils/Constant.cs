using AutoMapper;
using E4Storage.App.Helper;
using E4Storage.App.Model;
using E4Storage.App.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Utils
{
    public class Constant
    {
        public static string NamaApplikasi = "E4 Storage";
        public static AppSetting appSetting = null;
        public static TUser UserLogin = null;
        public static LayoutsHelper layoutsHelper = new LayoutsHelper(Path.Combine(Environment.CurrentDirectory, "System", "Layouts"));
        public static IMapper mapper = new AutoMapperConfig().Configure(); // Buat instance mapper

        public enum TypeTransaction
        {
            stokIn = 1,
            stokPengembalian = 2,
            stokMasterData = 3,
            stokOut = 4
        }

        //ID Jenis Transaksi
        public static Guid stokInType = Guid.Parse("C889E2DF-D056-4DAD-B935-E47921035811");
        public static Guid stokPengembalianType = Guid.Parse("B536F89C-FA4E-4F7B-AFDB-5B323546D10E");
        public static Guid stokMasterDataType = Guid.Parse("991D2F92-C02D-4A2A-8A5F-F19E3DAD08C5");
        public static Guid stokOutType = Guid.Parse("6652E843-6C01-4CD0-9F9C-5111565D7844");
        public static Guid stokSaldoAwal = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220");
    }
}
