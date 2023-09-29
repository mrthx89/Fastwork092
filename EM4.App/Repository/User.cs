using EM4.App.Model.Entity;
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
    }
}
