using E4Storage.App.Model.Entity;
using E4Storage.App.Utils;
using E4Storage.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E4Storage.App.Model.ViewModel;
using AutoMapper;
using System.Data.Entity;

namespace E4Storage.App.Repository
{
    public class StokKeluar
    {
        private static string Name = "Repository.StokKeluar";

        public static Tuple<bool, List<Model.ViewModel.StokKeluar>> getStokKeluars(DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.StokKeluar>> hasil = new Tuple<bool, List<Model.ViewModel.StokKeluar>>(false, new List<Model.ViewModel.StokKeluar>());
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var datas1 = from s in context.TStockOuts
                                 from i in context.TInventors.Where(o => s.IDInventor == o.ID).DefaultIfEmpty()
                                 where DbFunctions.TruncateTime(s.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(s.Tanggal) <= tglSampai.Date
                                 select new Model.ViewModel.StokKeluar
                                 {
                                     ID = s.ID,
                                     IDInventor = s.IDInventor,
                                     IDUOM = s.IDUOM,
                                     IDUserEdit = s.IDUserEdit,
                                     IDUserEntri = s.IDUserEntri,
                                     IDUserHapus = s.IDUserHapus,
                                     Keterangan = s.Keterangan,
                                     NamaBarang = i.Desc,
                                     DocNo = s.DocNo,
                                     IDBelt = s.IDBelt,
                                     PIC = s.PIC,
                                     Qty = s.Qty,
                                     Tanggal = s.Tanggal,
                                     TglEdit = s.TglEdit,
                                     TglEntri = s.TglEntri,
                                     TglHapus = s.TglHapus,
                                     IDType = Constant.stokOutType,
                                     IDCategory = s.IDCategory,
                                     Cabinet = s.Cabinet,
                                     Row = s.Row
                                 };

                    //var datas2 = from s in context.TStockPengembalians
                    //             from i in context.TInventors.Where(o => s.IDInventor == o.ID).DefaultIfEmpty()
                    //             where DbFunctions.TruncateTime(s.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(s.Tanggal) <= tglSampai.Date
                    //             select new Model.ViewModel.StokKeluar
                    //             {
                    //                 ID = s.ID,
                    //                 IDInventor = s.IDInventor,
                    //                 IDUOM = s.IDUOM,
                    //                 IDUserEdit = s.IDUserEdit,
                    //                 IDUserEntri = s.IDUserEntri,
                    //                 IDUserHapus = s.IDUserHapus,
                    //                 Keterangan = s.Keterangan,
                    //                 NamaBarang = i.Desc,
                    //                 DocNo = s.DocNo,
                    //                 IDBelt = Guid.Empty,
                    //                 PIC = "",
                    //                 Qty = s.Qty,
                    //                 Tanggal = s.Tanggal,
                    //                 TglEdit = s.TglEdit,
                    //                 TglEntri = s.TglEntri,
                    //                 TglHapus = s.TglHapus,
                    //                 IDType = stokPengembalianType
                    //             };

                    //var datas = datas1.Union(datas2);

                    var datas = datas1;
                    hasil = new Tuple<bool, List<Model.ViewModel.StokKeluar>>(true, datas.OrderBy(o => o.Tanggal).ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getStokKeluars", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, Model.ViewModel.StokKeluar> saveStokKeluar(Model.ViewModel.StokKeluar data)
        {
            Tuple<bool, Model.ViewModel.StokKeluar> hasil = new Tuple<bool, Model.ViewModel.StokKeluar>(false, null);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TStockOuts.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;

                        context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.StokKeluar, TStockOut>(data));
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        context.TStockOuts.Add(Constant.mapper.Map<Model.ViewModel.StokKeluar, TStockOut>(data));
                    }

                    //Post Kartu Stok
                    context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokOutType).ToList());

                    TStockCard stockCard = Constant.mapper.Map<Model.ViewModel.StokKeluar, TStockCard>(data);
                    stockCard.IDTransaksi = data.ID;
                    stockCard.IDTransaksiD = data.ID;
                    stockCard.IDType = Constant.stokOutType;
                    stockCard.DocNo = (string.IsNullOrEmpty(data.DocNo) || string.IsNullOrWhiteSpace(data.DocNo) ? "SO-" + stockCard.Tanggal.ToString("yyMMddHHmmss") : data.DocNo);
                    stockCard.QtyKeluar = data.Qty;
                    stockCard.IDBelt = data.IDBelt;
                    stockCard.IDCategory = data.IDCategory;
                    stockCard.Cabinet = data.Cabinet;
                    stockCard.Row = data.Row;
                    context.TStockCards.Add(stockCard);

                    context.SaveChanges();
                    hasil = new Tuple<bool, Model.ViewModel.StokKeluar>(true, data);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveStokKeluar", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, float> getSaldoStok(Guid IDInventor, DateTime Tanggal, Guid IDTransaksi, Constant.TypeTransaction TypeTransaction)
        {
            Tuple<bool, float> hasil = new Tuple<bool, float>(false, 0f);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TInventors.FirstOrDefault(o => o.ID == IDInventor);
                    if (dataExist != null)
                    {
                        Guid type = (TypeTransaction == Constant.TypeTransaction.stokOut ? Constant.stokOutType : Constant.stokPengembalianType);
                        var saldo = from stok in context.TStockCards
                                    where stok.IDInventor == IDInventor && stok.Tanggal <= Tanggal && !(stok.IDTransaksiD == IDTransaksi && stok.IDType == type)
                                    group stok by IDInventor into grp
                                    select new
                                    {
                                        IDInventor = grp.Key,
                                        Saldo = grp.Sum(stok => stok.QtyMasuk - stok.QtyKeluar)
                                    };
                        hasil = new Tuple<bool, float>(true, saldo.ToList().Sum(o => o.Saldo));
                    }
                    //else
                    //{
                    //    MsgBoxHelper.MsgWarn($"{Name}.getSaldoStok", "Item tidak ditemukan");
                    //}
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getSaldoStok", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, Model.ViewModel.StokKeluar> deleteStokKeluar(Model.ViewModel.StokKeluar data)
        {
            Tuple<bool, Model.ViewModel.StokKeluar> hasil = new Tuple<bool, Model.ViewModel.StokKeluar>(false, null);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TStockOuts.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        dataExist.IDUserHapus = Constant.UserLogin.ID;
                        dataExist.TglHapus = DateTime.Now;

                        //Post Kartu Stok
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokOutType).ToList());

                        context.Entry(dataExist).CurrentValues.SetValues(dataExist);

                        context.TStockOuts.Remove(dataExist);
                        context.SaveChanges();
                        hasil = new Tuple<bool, Model.ViewModel.StokKeluar>(true, Constant.mapper.Map<TStockOut, Model.ViewModel.StokKeluar>(dataExist));
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteStokKeluar", $"Data dengan No Form {data.DocNo} ini tidak ada didatabase!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.deleteStokKeluar", ex);
                }
            }
            return hasil;
        }
    }
}
