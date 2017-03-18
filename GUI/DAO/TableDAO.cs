using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExcuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[]{id1, id2});
        }

        public static int tableWidth = 150;
        public static int TableHeight = 120;

        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuery("EXEC dbo.USP_GetTableList");

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }

        public Table GetTableByID(int id)
        {
            Table table = null;
            string query = " USP_GetListTableByID @id ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] {id});
            foreach (DataRow item in data.Rows)
            {
                table = new Table(item);
                return table;
            }
            return table;
        }

        public bool InsertTableFood(string nameTable)
        {
            string query = string.Format("INSERT INTO dbo.TableFood( name )VALUES  ( N'{0}')",nameTable);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }
		public bool DeleteTableByID(int id)
		{
			string query = "EXEC dbo.USP_DeleteTabeByID @id ";
			int result = DataProvider.Instance.ExcuteNoneQuery(query, new object[] {id});
			return result > 0;
		}

    }
}
