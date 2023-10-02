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
    public class StokPengembalian
    {
        private static string Name = "Repository.StokPengembalian";
        private static Guid stokPengembalianType = Guid.Parse("B536F89C-FA4E-4F7B-AFDB-5B323546D10E");

        public static Tuple<bool, Model.ViewModel.StokPengembalian> saveStokPengembalian(Model.ViewModel.StokPengembalian data)
        {
            Tuple<bool, Model.ViewModel.StokPengembalian> hasil = new Tuple<bool, Model.ViewModel.StokPengembalian>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var dataExist = context.TStockPengembalians.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;

                        context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<Model.ViewModel.StokPengembalian, TStockPengembalian>(data));
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        context.TStockPengembalians.Add(Constant.mapper.Map<Model.ViewModel.StokPengembalian, TStockPengembalian>(data));
                    }

                    //Post Kartu Stok
                    context.TStockCards.RemoveRange(context.TStockCards.Where(o => o.IDTransaksi == data.ID && o.IDType == stokPengembalianType).ToList());

                    TStockCard stockCard = Constant.mapper.Map<Model.ViewModel.StokPengembalian, TStockCard>(data);
                    stockCard.IDTransaksi = data.ID;
                    stockCard.IDTransaksiD = data.ID;
                    stockCard.IDType = stokPengembalianType;
                    stockCard.DocNo = data.DocNo;
                    stockCard.QtyKeluar = data.Qty;
                    context.TStockCards.Add(stockCard);

                    hasil = new Tuple<bool, Model.ViewModel.StokPengembalian>(true, data);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveStokPengembalian", ex);
                }
            }
            return hasil;
        }
    }
}
