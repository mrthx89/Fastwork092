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
    public class Item
    {
        private static string Name = "Repository.Item";

        public static Tuple<bool, List<TUOM>> getUOMs()
        {
            Tuple<bool, List<TUOM>> hasil = new Tuple<bool, List<TUOM>>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    hasil = new Tuple<bool, List<TUOM>>(true, context.TUOMs.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getUOMs", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<TUOM>> saveUOMs(List<TUOM> uoms)
        {
            Tuple<bool, List<TUOM>> hasil = new Tuple<bool, List<TUOM>>(false, null);
            using (Data.EM4Context dbContext = new Data.EM4Context(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var userExists = dbContext.TUOMs.ToList();
                    foreach (var item in userExists)
                    {
                        if (uoms.FirstOrDefault(o => o.ID == item.ID) == null)
                        {
                            dbContext.TUOMs.Remove(item);
                        }
                    }

                    foreach (var item in uoms)
                    {
                        var existingItem = dbContext.TUOMs.FirstOrDefault(i => i.ID == item.ID);
                        if (existingItem != null)
                        {
                            item.IDUserEdit = Constant.UserLogin.ID;
                            item.TglEdit = DateTime.Now;
                            dbContext.Entry(existingItem).CurrentValues.SetValues(item);
                        }
                        else
                        {
                            item.IDUserEntri = Constant.UserLogin.ID;
                            item.TglEntri = DateTime.Now;
                            item.IDUserEdit = Guid.Empty;
                            item.TglEdit = null;
                            dbContext.TUOMs.Add(item);
                        }
                    }

                    dbContext.SaveChanges();

                    hasil = new Tuple<bool, List<TUOM>>(true, dbContext.TUOMs.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveUOMs", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<TBelt>> getBelts()
        {
            Tuple<bool, List<TBelt>> hasil = new Tuple<bool, List<TBelt>>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    hasil = new Tuple<bool, List<TBelt>>(true, context.TBelts.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getBelts", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<TTypeTransaction>> getTypes()
        {
            Tuple<bool, List<TTypeTransaction>> hasil = new Tuple<bool, List<TTypeTransaction>>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    hasil = new Tuple<bool, List<TTypeTransaction>>(true, context.TTypeTransactions.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getTypes", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<TBelt>> saveBelts(List<TBelt> belts)
        {
            Tuple<bool, List<TBelt>> hasil = new Tuple<bool, List<TBelt>>(false, null);
            using (Data.EM4Context dbContext = new Data.EM4Context(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var userExists = dbContext.TBelts.ToList();
                    foreach (var item in userExists)
                    {
                        if (belts.FirstOrDefault(o => o.ID == item.ID) == null)
                        {
                            dbContext.TBelts.Remove(item);
                        }
                    }

                    foreach (var item in belts)
                    {
                        var existingItem = dbContext.TBelts.FirstOrDefault(i => i.ID == item.ID);
                        if (existingItem != null)
                        {
                            item.IDUserEdit = Constant.UserLogin.ID;
                            item.TglEdit = DateTime.Now;
                            dbContext.Entry(existingItem).CurrentValues.SetValues(item);
                        }
                        else
                        {
                            item.IDUserEntri = Constant.UserLogin.ID;
                            item.TglEntri = DateTime.Now;
                            item.IDUserEdit = Guid.Empty;
                            item.TglEdit = null;
                            dbContext.TBelts.Add(item);
                        }
                    }

                    dbContext.SaveChanges();

                    hasil = new Tuple<bool, List<TBelt>>(true, dbContext.TBelts.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.saveBelts", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<ItemMaster>> getInventors(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<ItemMaster>> hasil = new Tuple<bool, List<ItemMaster>>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var data = context.TInventors.AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var item in filter)
                        {
                            if (item.Key.Equals("PLU"))
                            {
                                string a = (string)item.Value;
                                data = data.Where(o => o.PLU.Contains(a));
                            }
                            else if (item.Key.Equals("DESC"))
                            {
                                string a = (string)item.Value;
                                data = data.Where(o => o.Desc.Contains(a));
                            }
                        }
                    }
                    var saldoQuery = from stockCard in context.TStockCards
                                     join item in data on stockCard.IDInventor equals item.ID
                                     group stockCard by stockCard.IDInventor into grouped
                                     select new
                                     {
                                         IDInventor = grouped.Key,
                                         Saldo = grouped.Sum(t => t.QtyMasuk - t.QtyKeluar)
                                     };
                    var items = (from item in data
                                 from saldo in saldoQuery.Where(o => o.IDInventor == item.ID).DefaultIfEmpty()
                                 select new ItemMaster
                                 {
                                     ID = item.ID,
                                     Desc = item.Desc,
                                     IDUOM = item.IDUOM,
                                     IDUserEdit = item.IDUserEdit,
                                     IDUserEntri = item.IDUserEntri,
                                     IDUserHapus = item.IDUserHapus,
                                     PLU = item.PLU,
                                     Saldo = (saldo != null ? saldo.Saldo : 0),
                                     TglEdit = item.TglEdit,
                                     TglEntri = item.TglEntri,
                                     TglHapus = item.TglHapus
                                 }).ToList();
                    hasil = new Tuple<bool, List<ItemMaster>>(true, items);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMasters", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<ItemLookUp>> getLookUpInventors(DateTime Tanggal, Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<ItemLookUp>> hasil = new Tuple<bool, List<ItemLookUp>>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var data = context.TInventors.AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var item in filter)
                        {
                            if (item.Key.Equals("PLU"))
                            {
                                string a = (string)item.Value;
                                data = data.Where(o => o.PLU.Contains(a));
                            }
                            else if (item.Key.Equals("DESC"))
                            {
                                string a = (string)item.Value;
                                data = data.Where(o => o.Desc.Contains(a));
                            }
                        }
                    }
                    var saldoQuery = from stockCard in context.TStockCards.Where(o => o.Tanggal <= Tanggal)
                                     join item in data on stockCard.IDInventor equals item.ID
                                     group stockCard by stockCard.IDInventor into grouped
                                     select new
                                     {
                                         IDInventor = grouped.Key,
                                         Saldo = grouped.Sum(t => t.QtyMasuk - t.QtyKeluar)
                                     };
                    var items = (from item in data
                                 from saldo in saldoQuery.Where(o => o.IDInventor == item.ID).DefaultIfEmpty()
                                 from satuan in context.TUOMs.Where(o => o.ID == item.IDUOM).DefaultIfEmpty()
                                 select new ItemLookUp
                                 {
                                     ID = item.ID,
                                     PLU = item.PLU,
                                     Desc = item.Desc,
                                     IDUOM = item.IDUOM,
                                     Satuan = (satuan != null ? satuan.Satuan : ""),
                                     Saldo = (saldo != null ? saldo.Saldo : 0)
                                 }).ToList();
                    hasil = new Tuple<bool, List<ItemLookUp>>(true, items);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.getLookUpInventors", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, ItemMaster> getInventor(Guid ID)
        {
            Tuple<bool, ItemMaster> hasil = new Tuple<bool, ItemMaster>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var data = context.TInventors.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {
                        var saldoQuery = from stockCard in context.TStockCards.Where(o => o.IDInventor == data.ID)
                                         group stockCard by stockCard.IDInventor into grouped
                                         select new
                                         {
                                             IDInventor = grouped.Key,
                                             Saldo = grouped.Sum(t => t.QtyMasuk - t.QtyKeluar)
                                         };
                        var item = Constant.mapper.Map<ItemMaster>(data);
                        item.Saldo = (saldoQuery != null ? saldoQuery.FirstOrDefault().Saldo : 0);

                        hasil = new Tuple<bool, ItemMaster>(true, item);
                    }
                    else
                    {
                        hasil = new Tuple<bool, ItemMaster>(false, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, List<ItemMaster>> getInventor(Dictionary<string, dynamic> filter)
        {
            Tuple<bool, List<ItemMaster>> hasil = new Tuple<bool, List<ItemMaster>>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var datas = context.TInventors.AsQueryable();
                    if (filter != null && filter.Count >= 1)
                    {
                        foreach (var item in filter)
                        {
                            if (item.Key.Equals("PLU"))
                            {
                                string a = (string)item.Value;
                                datas = datas.Where(o => o.PLU.Equals(a));
                            }
                            else if (item.Key.Equals("DESC"))
                            {
                                string a = (string)item.Value;
                                datas = datas.Where(o => o.Desc.Equals(a));
                            }
                        }
                    }
                    var saldoQuery = from stockCard in context.TStockCards
                                     join item in datas on stockCard.IDInventor equals item.ID
                                     group stockCard by stockCard.IDInventor into grouped
                                     select new
                                     {
                                         IDInventor = grouped.Key,
                                         Saldo = grouped.Sum(t => t.QtyMasuk - t.QtyKeluar)
                                     };
                    var items = (from item in datas
                                 from saldo in saldoQuery.Where(o => o.IDInventor == item.ID).DefaultIfEmpty()
                                 select new ItemMaster
                                 {
                                     ID = item.ID,
                                     Desc = item.Desc,
                                     IDUOM = item.IDUOM,
                                     IDUserEdit = item.IDUserEdit,
                                     IDUserEntri = item.IDUserEntri,
                                     IDUserHapus = item.IDUserHapus,
                                     PLU = item.PLU,
                                     Saldo = (saldo != null ? saldo.Saldo : 0),
                                     TglEdit = item.TglEdit,
                                     TglEntri = item.TglEntri,
                                     TglHapus = item.TglHapus
                                 }).ToList();
                    hasil = new Tuple<bool, List<ItemMaster>>(true, items);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, ItemMaster> deleteInventor(Guid ID)
        {
            Tuple<bool, ItemMaster> hasil = new Tuple<bool, ItemMaster>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var data = context.TInventors.FirstOrDefault(o => o.ID == ID);
                    if (data != null)
                    {
                        context.TInventors.Remove(data);
                        hasil = new Tuple<bool, ItemMaster>(true, null);
                        context.SaveChanges();
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{Name}.deleteInventor", "Data intentor tidak ditemukan!");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, ItemMaster> saveInventor(ItemMaster data)
        {
            Tuple<bool, ItemMaster> hasil = new Tuple<bool, ItemMaster>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var dataExist = context.TInventors.FirstOrDefault(o => o.ID == data.ID);
                    if (dataExist != null)
                    {
                        //Edit
                        data.IDUserEdit = Constant.UserLogin.ID;
                        data.TglEdit = DateTime.Now;

                        context.Entry(dataExist).CurrentValues.SetValues(Constant.mapper.Map<ItemMaster, TInventor>(data));
                    }
                    else
                    {
                        //Baru
                        data.IDUserEntri = Constant.UserLogin.ID;
                        data.TglEntri = DateTime.Now;

                        context.TInventors.Add(Constant.mapper.Map<ItemMaster, TInventor>(data));
                    }

                    hasil = new Tuple<bool, ItemMaster>(true, data);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, ItemMaster> checkPLUExistsInventor(ItemMaster data)
        {
            Tuple<bool, ItemMaster> hasil = new Tuple<bool, ItemMaster>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var dataExist = context.TInventors.FirstOrDefault(o => o.PLU.Equals(data.PLU) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, ItemMaster>(false, Constant.mapper.Map<TInventor, ItemMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, ItemMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMaster", ex);
                }
            }
            return hasil;
        }

        public static Tuple<bool, ItemMaster> checkNamaExistsInventor(ItemMaster data)
        {
            Tuple<bool, ItemMaster> hasil = new Tuple<bool, ItemMaster>(false, null);
            using (Data.EM4Context context = new Data.EM4Context())
            {
                try
                {
                    var dataExist = context.TInventors.FirstOrDefault(o => o.Desc.Equals(data.Desc) && o.ID != data.ID);
                    if (dataExist != null)
                    {
                        hasil = new Tuple<bool, ItemMaster>(false, Constant.mapper.Map<TInventor, ItemMaster>(dataExist));
                    }
                    else
                    {
                        hasil = new Tuple<bool, ItemMaster>(true, null);
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{Name}.geItemMaster", ex);
                }
            }
            return hasil;
        }
    }
}
