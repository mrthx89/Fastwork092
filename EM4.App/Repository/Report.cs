using EM4.App.Model.Entity;
using EM4.App.Utils;
using EM4.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM4.App.Model.ViewModel;
using AutoMapper;
using System.Data.Entity;

namespace EM4.App.Repository
{
    public class Report
    {
        private static string Name = "Repository.Report";
        private static Guid stokOutType = Guid.Parse("6652E843-6C01-4CD0-9F9C-5111565D7844");
        private static Guid stokPengembalianType = Guid.Parse("B536F89C-FA4E-4F7B-AFDB-5B323546D10E");

        public static Tuple<bool, List<Model.ViewModel.MutasiStok>> getMutasiStoks(DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.MutasiStok>> hasil = new Tuple<bool, List<Model.ViewModel.MutasiStok>>(false, new List<Model.ViewModel.MutasiStok>());
            using (Data.EM4Context context = new Data.EM4Context(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataSaldo = from k in context.TStockCards
                                    where DbFunctions.TruncateTime(k.Tanggal) < tglDari.Date
                                    group k by new { k.IDInventor } into grp
                                    select new { grp.Key.IDInventor, SaldoAwal = grp.Sum(o => o.QtyMasuk - o.QtyKeluar) };

                    var dataMutasi = from k in context.TStockCards
                                     where DbFunctions.TruncateTime(k.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(k.Tanggal) <= tglSampai.Date
                                     group k by new { k.IDInventor } into grp
                                     select new
                                     {
                                         grp.Key.IDInventor,
                                         QtyMasuk = grp.Sum(o => o.QtyMasuk),
                                         QtyKeluar = grp.Sum(o => o.QtyKeluar)
                                     };

                    var datas = from i in context.TInventors
                                from s in dataSaldo.Where(o => o.IDInventor == i.ID).DefaultIfEmpty()
                                from m in dataMutasi.Where(o => o.IDInventor == i.ID).DefaultIfEmpty()
                                select new Model.ViewModel.MutasiStok
                                {
                                    IDInventor = i.ID,
                                    IDUOM = i.IDUOM,
                                    NamaBarang = i.Desc,
                                    SaldoAwal = (s != null ? s.SaldoAwal : 0),
                                    QtyMasuk = (m != null ? m.QtyMasuk : 0),
                                    QtyKeluar = (m != null ? m.QtyKeluar : 0)
                                };

                    hasil = new Tuple<bool, List<Model.ViewModel.MutasiStok>>(true, datas.OrderBy(o => o.NamaBarang).ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getMutasiStoks", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<Model.ViewModel.KartuStok>> getKartuStoks(Guid IDInventor, DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.KartuStok>> hasil = new Tuple<bool, List<Model.ViewModel.KartuStok>>(false, new List<Model.ViewModel.KartuStok>());
            using (Data.EM4Context context = new Data.EM4Context(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataSaldo = from k in context.TStockCards
                                    from i in context.TInventors.Where(o => o.ID == k.IDInventor).DefaultIfEmpty()
                                    where k.IDInventor == IDInventor && DbFunctions.TruncateTime(k.Tanggal) < tglDari.Date
                                    group k by new { k.IDInventor, i.IDUOM, i.Desc } into grp
                                    select new
                                    {
                                        grp.Key.IDInventor,
                                        grp.Key.IDUOM,
                                        grp.Key.Desc,
                                        SaldoAwal = grp.Sum(o => o.QtyMasuk - o.QtyKeluar)
                                    };

                    List<Model.ViewModel.KartuStok> dataKartu = (from k in context.TStockCards
                                                                 from i in context.TInventors.Where(o => o.ID == k.IDInventor).DefaultIfEmpty()
                                                                 from t in context.TTypeTransactions.Where(o => o.ID == k.IDType).DefaultIfEmpty()
                                                                 where k.IDInventor == IDInventor && DbFunctions.TruncateTime(k.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(k.Tanggal) <= tglSampai.Date
                                                                 orderby k.Tanggal, t.NoUrut
                                                                 select new Model.ViewModel.KartuStok
                                                                 {
                                                                     ID = k.ID,
                                                                     DocNo = k.DocNo,
                                                                     IDBelt = k.IDBelt,
                                                                     IDInventor = k.IDInventor,
                                                                     IDTransaksi = k.IDTransaksi,
                                                                     IDTransaksiD = k.IDTransaksiD,
                                                                     IDType = k.IDType,
                                                                     IDUOM = k.IDUOM,
                                                                     IDUserEdit = k.IDUserEdit,
                                                                     IDUserEntri = k.IDUserEntri,
                                                                     IDUserHapus = k.IDUserHapus,
                                                                     NamaBarang = i.Desc,
                                                                     PIC = k.PIC,
                                                                     QtyKeluar = k.QtyKeluar,
                                                                     QtyMasuk = k.QtyMasuk,
                                                                     SaldoAwal = 0f,
                                                                     Tanggal = k.Tanggal,
                                                                     TglEdit = k.TglEdit,
                                                                     TglEntri = k.TglEntri,
                                                                     TglHapus = k.TglHapus,
                                                                     NoUrut = t.NoUrut
                                                                 }).ToList();

                    if (dataSaldo != null && dataSaldo.Count() >= 1)
                    {
                        var saldos = from s in dataSaldo.ToList()
                                     group s by new { s.IDInventor, s.IDUOM, s.Desc } into grp
                                     select new Model.ViewModel.KartuStok
                                     {
                                         ID = Guid.NewGuid(),
                                         DocNo = "Saldo Awal",
                                         IDBelt = Guid.Empty,
                                         IDInventor = grp.Key.IDInventor,
                                         IDTransaksi = Guid.Empty,
                                         IDTransaksiD = Guid.Empty,
                                         IDType = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220"),
                                         IDUOM = grp.Key.IDUOM,
                                         IDUserEdit = Guid.Empty,
                                         IDUserEntri = Guid.Empty,
                                         IDUserHapus = Guid.Empty,
                                         NamaBarang = grp.Key.Desc,
                                         PIC = "",
                                         QtyKeluar = 0f,
                                         QtyMasuk = 0f,
                                         SaldoAwal = grp.Sum(s => s.SaldoAwal),
                                         Tanggal = tglDari.Date.AddDays(-1),
                                         TglEdit = DateTime.Parse("1900-01-01"),
                                         TglEntri = DateTime.Parse("1900-01-01"),
                                         TglHapus = DateTime.Parse("1900-01-01"),
                                         NoUrut = -1
                                     };
                        dataKartu.AddRange(saldos.ToList());
                    }
                    else
                    {
                        dataKartu.AddRange(from i in context.TInventors.Where(i => i.ID == IDInventor).ToList()
                                           select new Model.ViewModel.KartuStok
                                           {
                                               ID = Guid.NewGuid(),
                                               DocNo = "Saldo Awal",
                                               IDBelt = Guid.Empty,
                                               IDInventor = i.ID,
                                               IDTransaksi = Guid.Empty,
                                               IDTransaksiD = Guid.Empty,
                                               IDType = Guid.Parse("D6022513-AFD4-4A67-9F47-594E43D5F220"),
                                               IDUOM = i.IDUOM,
                                               IDUserEdit = Guid.Empty,
                                               IDUserEntri = Guid.Empty,
                                               IDUserHapus = Guid.Empty,
                                               NamaBarang = i.Desc,
                                               PIC = "",
                                               QtyKeluar = 0f,
                                               QtyMasuk = 0f,
                                               SaldoAwal = 0f,
                                               Tanggal = tglDari.Date.AddDays(-1),
                                               TglEdit = DateTime.Parse("1900-01-01"),
                                               TglEntri = DateTime.Parse("1900-01-01"),
                                               TglHapus = DateTime.Parse("1900-01-01"),
                                               NoUrut = -1
                                           });
                    }

                    float Saldo = 0f;
                    foreach (var item in dataKartu.OrderBy(o => o.Tanggal).ThenBy(o => o.NoUrut).ToList())
                    {
                        if (item.NoUrut != -1)
                        {
                            item.SaldoAwal = Saldo;
                        }
                        Saldo = item.SaldoAkhir;
                    }

                    hasil = new Tuple<bool, List<Model.ViewModel.KartuStok>>(true, dataKartu.OrderBy(o => o.Tanggal).ThenBy(o => o.NoUrut).ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getKartuStoks", ex);
                }
            }
            return hasil;
        }
    }
}
