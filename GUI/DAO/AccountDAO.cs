using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @UserName , @PassWord";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[]{username,password});
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUsername(string userName)
        {
            string query = "EXECUTE dbo.USP_GetAccountByUsername @Username ";
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExcuteQuery(query, new object[]{userName});
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool InsertAccount(string name, string displayname, int type)
        {
            string query = string.Format("INSERT dbo.Account( username , displayname , type )VALUES  ( N'{0}',N'{1}', {2})", name, displayname, type);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(String username, string displayname, string pass, string newpass)
        {
            int result = DataProvider.Instance.ExcuteNoneQuery("EXECUTE	dbo.USP_UpdateAccount @userName , @displayName , @password , @newPassword ", new object[]{username,displayname,pass,newpass});
            return result > 0;
        }

        public bool UpdateAccount1(String username, string displayname, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET displayname = N'{1}' , type = {2} WHERE username = N'{0}' ", username, displayname, type);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set password = N'0' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }

        public DataTable GetAccount()
        {
            return DataProvider.Instance.ExcuteQuery("Select Username , Displayname , Type from Account");
        }

    }
}
