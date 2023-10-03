﻿using EM4.App.Model.Entity;
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
    public class StokMasuk
    {
        private static string Name = "Repository.StokMasuk";
        private static Guid stokInType = Guid.Parse("C889E2DF-D056-4DAD-B935-E47921035811");

        public static Tuple<bool, List<Model.ViewModel.StokMasuk>> getStokMasuks(DateTime tglDari, DateTime tglSampai)
        {
            Tuple<bool, List<Model.ViewModel.StokMasuk>> hasil = new Tuple<bool, List<Model.ViewModel.StokMasuk>>(false, new List<Model.ViewModel.StokMasuk>());
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var datas = from s in context.TStockIns
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
                                    NoPO = s.NoPO,
                                    NoSJ = s.NoSJ,
                                    Qty = s.Qty,
                                    Supplier = s.Supplier,
                                    Tanggal = s.Tanggal,
                                    TglEdit = s.TglEdit,
                                    TglEntri = s.TglEntri,
                                    TglHapus = s.TglHapus
                                };
                    hasil = new Tuple<bool, List<Model.ViewModel.StokMasuk>>(true, datas.ToList());
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
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var dataExist = context.TStockIns.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;

                        context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.StokMasuk, TStockIn>(data));
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        context.TStockIns.Add(Constant.mapper.Map<Model.ViewModel.StokMasuk, TStockIn>(data));
                    }

                    //Post Kartu Stok
                    context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == stokInType).ToList());

                    TStockCard stockCard = Constant.mapper.Map<Model.ViewModel.StokMasuk, TStockCard>(data);
                    stockCard.IDTransaksi = data.ID;
                    stockCard.IDTransaksiD = data.ID;
                    stockCard.IDType = stokInType;
                    stockCard.DocNo = data.NoSJ;
                    stockCard.QtyMasuk = data.Qty;
                    stockCard.PIC = "";
                    stockCard.IDBelt = Guid.Empty;
                    context.TStockCards.Add(stockCard);

                    hasil = new Tuple<bool, Model.ViewModel.StokMasuk>(true, data);
                    context.SaveChanges();
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
            using (Data.EM4Context context = new Data.EM4Context())
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
                        context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == stokInType).ToList());

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
