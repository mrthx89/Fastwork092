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
    public class StokMasterData
    {
        private static string Name = "Repository.StokMasterData";

        public static Tuple<bool, List<Model.ViewModel.StokMasterData>> getStokMasterDatas(DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.StokMasterData>> hasil = new Tuple<bool, List<Model.ViewModel.StokMasterData>>(false, new List<Model.ViewModel.StokMasterData>());
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var datas = from s in context.TStockMasterDatas
                                from i in context.TInventors.Where(o => s.IDInventor == o.ID).DefaultIfEmpty()
                                where DbFunctions.TruncateTime(s.Tanggal) >= DbFunctions.TruncateTime(tglDari) && DbFunctions.TruncateTime(s.Tanggal) <= DbFunctions.TruncateTime(tglSampai)
                                select new Model.ViewModel.StokMasterData
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
                                    Qty = s.Qty,
                                    Tanggal = s.Tanggal,
                                    TglEdit = s.TglEdit,
                                    TglEntri = s.TglEntri,
                                    TglHapus = s.TglHapus,
                                    Cabinet = s.Cabinet,
                                    IDBelt = s.IDBelt,
                                    IDCategory = s.IDCategory,
                                    PIC = s.PIC,
                                    Row = s.Row
                                };
                    hasil = new Tuple<bool, List<Model.ViewModel.StokMasterData>>(true, datas.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getStokMasterDatas", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, Model.ViewModel.StokMasterData> saveStokMasterData(Model.ViewModel.StokMasterData data)
        {
            Tuple<bool, Model.ViewModel.StokMasterData> hasil = new Tuple<bool, Model.ViewModel.StokMasterData>(false, null);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TStockMasterDatas.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;

                        context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.StokMasterData, TStockMasterData>(data));
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        context.TStockMasterDatas.Add(Constant.mapper.Map<Model.ViewModel.StokMasterData, TStockMasterData>(data));
                    }

                    //Post Kartu Stok
                    context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokMasterDataType).ToList());

                    TStockCard stockCard = Constant.mapper.Map<Model.ViewModel.StokMasterData, TStockCard>(data);
                    stockCard.IDTransaksi = data.ID;
                    stockCard.IDTransaksiD = data.ID;
                    stockCard.IDType = Constant.stokMasterDataType;
                    stockCard.DocNo = (string.IsNullOrEmpty(data.DocNo) || string.IsNullOrWhiteSpace(data.DocNo) ? "SM-" + stockCard.Tanggal.ToString("yyMMddHHmmss") : data.DocNo);
                    stockCard.QtyMasuk = data.Qty;
                    stockCard.PIC = data.PIC;
                    stockCard.IDBelt = data.IDBelt;
                    stockCard.IDCategory = data.IDCategory;
                    stockCard.Cabinet = data.Cabinet;
                    stockCard.Row = data.Row;
                    context.TStockCards.Add(stockCard);

                    context.SaveChanges();
                    hasil = new Tuple<bool, Model.ViewModel.StokMasterData>(true, data);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveStokMasterData", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, Model.ViewModel.StokMasterData> deleteStokMasterData(Model.ViewModel.StokMasterData data)
        {
            Tuple<bool, Model.ViewModel.StokMasterData> hasil = new Tuple<bool, Model.ViewModel.StokMasterData>(false, null);
            using (Data.E4StorageContext context = new Data.E4StorageContext(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var dataExist = context.TStockMasterDatas.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        dataExist.IDUserHapus = Constant.UserLogin.ID;
                        dataExist.TglHapus = DateTime.Now;

                        //Post Kartu Stok
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == Constant.stokMasterDataType).ToList());

                        context.Entry(dataExist).CurrentValues.SetValues(dataExist);

                        context.TStockMasterDatas.Remove(dataExist);
                        context.SaveChanges();
                        hasil = new Tuple<bool, Model.ViewModel.StokMasterData>(true, Constant.mapper.Map<TStockMasterData, Model.ViewModel.StokMasterData>(dataExist));
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteStokMasterData", $"Data dengan No Form {data.DocNo} ini tidak ada didatabase!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.deleteStokMasterData", ex);
                }
            }
            return hasil;
        }
    }
}
