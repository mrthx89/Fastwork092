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
    public class StokMasuk
    {
        private static string Name = "Repository.StokMasuk";
        
        public static Tuple<bool, List<Model.ViewModel.StokMasuk>> getStokMasuks(DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.StokMasuk>> hasil = new Tuple<bool, List<Model.ViewModel.StokMasuk>>(false, new List<Model.ViewModel.StokMasuk>());
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var datas1 = from s in context.TStockIns
                                 from i in context.TInventors.Where(o => s.IDInventor == o.ID).DefaultIfEmpty()
                                 where DbFunctions.TruncateTime(s.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(s.Tanggal) <= tglSampai.Date
                                 select new Model.ViewModel.StokMasuk
                                 {
                                     ID = s.ID,
                                     IDInventor = s.IDInventor,
                                     IDUOM = s.IDUOM,
                                     IDUserEdit = s.IDUserEdit,
                                     IDUserEntri = s.IDUserEntri,
                                     IDUserHapus = s.IDUserHapus,
                                     Keterangan = s.Keterangan,
                                     NamaBarang = i.Desc,
                                     DocNo = s.NoPO,
                                     NoSJ = s.NoSJ,
                                     Qty = s.Qty,
                                     Supplier = s.Supplier,
                                     Tanggal = s.Tanggal,
                                     TglEdit = s.TglEdit,
                                     TglEntri = s.TglEntri,
                                     TglHapus = s.TglHapus,
                                     IDType = Constant.stokInType,
                                     Cabinet = s.Cabinet,
                                     IDBelt = s.IDBelt,
                                     IDCategory = s.IDCategory,
                                     PIC = s.PIC,
                                     Row = s.Row
                                 };

                    var datas2 = from s in context.TStockPengembalians
                                 from i in context.TInventors.Where(o => s.IDInventor == o.ID).DefaultIfEmpty()
                                 where DbFunctions.TruncateTime(s.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(s.Tanggal) <= tglSampai.Date
                                 select new Model.ViewModel.StokMasuk
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
                                     NoSJ = "",
                                     Qty = s.Qty,
                                     Tanggal = s.Tanggal,
                                     TglEdit = s.TglEdit,
                                     TglEntri = s.TglEntri,
                                     TglHapus = s.TglHapus,
                                     IDType = Constant.stokPengembalianType,
                                     Cabinet = s.Cabinet,
                                     IDBelt = s.IDBelt,
                                     IDCategory = s.IDCategory,
                                     PIC = s.PIC,
                                     Row = s.Row
                                 };

                    var datas3 = from s in context.TStockMasterDatas
                                 from i in context.TInventors.Where(o => s.IDInventor == o.ID).DefaultIfEmpty()
                                 where DbFunctions.TruncateTime(s.Tanggal) >= tglDari.Date && DbFunctions.TruncateTime(s.Tanggal) <= tglSampai.Date
                                 select new Model.ViewModel.StokMasuk
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
                                     NoSJ = "",
                                     Qty = s.Qty,
                                     Tanggal = s.Tanggal,
                                     TglEdit = s.TglEdit,
                                     TglEntri = s.TglEntri,
                                     TglHapus = s.TglHapus,
                                     IDType = Constant.stokMasterDataType,
                                     Cabinet = s.Cabinet,
                                     IDBelt = s.IDBelt,
                                     IDCategory = s.IDCategory,
                                     PIC = s.PIC,
                                     Row = s.Row
                                 };

                    List<Model.ViewModel.StokMasuk> datas = datas1.ToList();
                    datas.AddRange(datas2.ToList());
                    datas.AddRange(datas3.ToList());
                    hasil = new Tuple<bool, List<Model.ViewModel.StokMasuk>>(true, datas.OrderBy(o => o.Tanggal).ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getStokMasuks", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, Model.ViewModel.StokMasuk> saveStokMasuk(Model.ViewModel.StokMasuk data)
        {
            Tuple<bool, Model.ViewModel.StokMasuk> hasil = new Tuple<bool, Model.ViewModel.StokMasuk>(false, null);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TStockIns.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;

                        TStockIn stockIn = Constant.mapper.Map<Model.ViewModel.StokMasuk, TStockIn>(data);
                        stockIn.NoPO = data.DocNo;

                        context.Entry(dataExist).CurrentValues.SetValues(stockIn);
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        TStockIn stockIn = Constant.mapper.Map<Model.ViewModel.StokMasuk, TStockIn>(data);
                        stockIn.NoPO = data.DocNo;

                        context.TStockIns.Add(stockIn);
                    }

                    //Post Kartu Stok
                    context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokInType).ToList());

                    TStockCard stockCard = Constant.mapper.Map<Model.ViewModel.StokMasuk, TStockCard>(data);
                    stockCard.IDTransaksi = data.ID;
                    stockCard.IDTransaksiD = data.ID;
                    stockCard.IDType = Constant.stokInType;
                    stockCard.DocNo = (string.IsNullOrEmpty(data.NoSJ) || string.IsNullOrWhiteSpace(data.NoSJ) ? "SI-" + stockCard.Tanggal.ToString("yyMMddHHmmss") : data.NoSJ);
                    stockCard.QtyMasuk = data.Qty;
                    stockCard.PIC = data.PIC;
                    stockCard.IDBelt = data.IDBelt;
                    stockCard.IDCategory = data.IDCategory;
                    stockCard.Cabinet = data.Cabinet;
                    stockCard.Row = data.Row;
                    context.TStockCards.Add(stockCard);

                    context.SaveChanges();
                    hasil = new Tuple<bool, Model.ViewModel.StokMasuk>(true, data);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveStokMasuk", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, Model.ViewModel.StokMasuk> deleteStokMasuk(Model.ViewModel.StokMasuk data)
        {
            Tuple<bool, Model.ViewModel.StokMasuk> hasil = new Tuple<bool, Model.ViewModel.StokMasuk>(false, null);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TStockIns.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        dataExist.IDUserHapus = Constant.UserLogin.ID;
                        dataExist.TglHapus = DateTime.Now;

                        //Post Kartu Stok
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokInType).ToList());

                        context.Entry(dataExist).CurrentValues.SetValues(dataExist);

                        context.TStockIns.Remove(dataExist);
                        context.SaveChanges();
                        hasil = new Tuple<bool, Model.ViewModel.StokMasuk>(true, Constant.mapper.Map<TStockIn, Model.ViewModel.StokMasuk>(dataExist));
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteStokMasuk", $"Data dengan No SJ {data.NoSJ} ini tidak ada didatabase!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.deleteStokMasuk", ex);
                }
            }
            return hasil;
        }
    }
}
