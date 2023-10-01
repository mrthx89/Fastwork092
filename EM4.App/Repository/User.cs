﻿using EM4.App.Model.Entity;
using EM4.App.Utils;
using EM4.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Repository
{
    public class User
    {
        public static Data.EM4Context eM4Context = new Data.EM4Context(Constant.appSetting.KoneksiString);

        public static Tuple<bool, TUser> getLogin(string UserID, string Pwd)
        {
            Tuple<bool, TUser> hasil = new Tuple<bool, TUser>(false, null);
            try
            {
                var user = eM4Context.TUsers.FirstOrDefault(o => o.UserID.Equals(UserID));
                if (user != null && user.Password.Equals(Utils.GetHash(Pwd)))
                {
                    hasil = new Tuple<bool, TUser>(true, user);
                }
                else
                {
                    MsgBoxHelper.MsgWarn("User.getLogin", "User yang anda masukkan salah!");
                    hasil = new Tuple<bool, TUser>(false, null);
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError("User.getLogin", ex);
            }
            return hasil;
        }

        public static Tuple<bool, List<TUser>> getUsers()
        {
            Tuple<bool, List<TUser>> hasil = new Tuple<bool, List<TUser>>(false, null);
            try
            {
                var user = eM4Context.TUsers.ToList();
                hasil = new Tuple<bool, List<TUser>>(true, user);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError("User.getUsers", ex);
            }
            return hasil;
        }

        public static Tuple<bool, dynamic> getLookUp()
        {
            Tuple<bool, dynamic> hasil = new Tuple<bool, dynamic>(false, null);
            try
            {
                var user = (from x in eM4Context.TUsers
                            select new { x.ID, x.Nama, x.UserID }).ToList();
                hasil = new Tuple<bool, dynamic>(true, user);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError("User.getLookUp", ex);
            }
            return hasil;
        }

        public static Tuple<bool, List<TUser>> saveUsers(List<TUser> users)
        {
            Tuple<bool, List<TUser>> hasil = new Tuple<bool, List<TUser>>(false, null);
            using (Data.EM4Context dbContext = new Data.EM4Context(Constant.appSetting.KoneksiString))
            {
                try
                {
                    var userExists = dbContext.TUsers.ToList();
                    foreach (var item in userExists)
                    {
                        if (users.FirstOrDefault(o => o.ID == item.ID) == null)
                        {
                            dbContext.TUsers.Remove(item);
                        }
                    }

                    foreach (var item in users)
                    {
                        var existingItem = dbContext.TUsers.FirstOrDefault(i => i.ID == item.ID);
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
                            dbContext.TUsers.Add(item);
                        }
                    }

                    dbContext.SaveChanges();

                    hasil = new Tuple<bool, List<TUser>>(true, dbContext.TUsers.ToList());
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError("User.saveUsers", ex);
                }
            }
            return hasil;
        }
    }
}
