using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listmenu= new List<Menu>();
            string query = "SELECT f.name, bi.Count, f.Price, f.Price*bi.Count AS TotalPrice FROM dbo.BillInfo AS bi,dbo.Bill AS b,dbo.Food AS f WHERE bi.idBill=b.id AND bi.idFood=f.id AND b.status = 0 AND b.idTable = "+ id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
