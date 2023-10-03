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
            using (Data.EM4Context context = new Data.EM4Context())
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
                                     select new { 
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
    }
}
