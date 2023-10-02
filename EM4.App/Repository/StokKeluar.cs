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

namespace EM4.App.Repository
{
    public class StokKeluar
    {
        private static string Name = "Repository.StokKeluar";
        private static Guid stokInType = Guid.Parse("6652E843-6C01-4CD0-9F9C-5111565D7844");

        public static Tuple<bool, Model.ViewModel.StokKeluar> saveStokKeluar(Model.ViewModel.StokKeluar data)
        {
            Tuple<bool, Model.ViewModel.StokKeluar> hasil = new Tuple<bool, Model.ViewModel.StokKeluar>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
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
                    context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == stokInType).ToList());

                    TStockCard stockCard = Constant.mapper.Map<Model.ViewModel.StokKeluar, TStockCard>(data);
                    stockCard.IDTransaksi = data.ID;
                    stockCard.IDTransaksiD = data.ID;
                    stockCard.IDType = stokInType;
                    stockCard.DocNo = data.DocNo;
                    stockCard.QtyKeluar = data.Qty;
                    context.TStockCards.Add(stockCard);

                    hasil = new Tuple<bool, Model.ViewModel.StokKeluar>(true, data);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveStokKeluar", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, float> getSaldoStok(Guid IDInventor, DateTime Tanggal)
        {
            Tuple<bool, float> hasil = new Tuple<bool, float>(false, 0f);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var dataExist = context.TInventors.FirstOrDefault(o => o.ID == IDInventor);
                    if (dataExist != null)
                    {
                        var saldo = from stok in context.TStockCards
                                    where stok.IDInventor == IDInventor && stok.Tanggal <= Tanggal
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
                    MsgBoxHelper.MsgError($"{Name}.saveStokKeluar", ex);
                }
            }
            return hasil;
        }
    }
}
