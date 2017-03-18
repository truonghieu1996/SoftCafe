using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
           private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetlistFood(int id)
        {
            List<Food> listFood = new List<Food>();
            string query = "SELECT * FROM dbo.Food WHERE idCategory= "+id;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public DataTable GetFood()
        {
			string query = "SELECT * FROM dbo.Food AS f, dbo.FoodCategory AS fc WHERE f.idCategory = fc.id";
			try
			{
				return DataProvider.Instance.ExcuteQuery(query);
			}
			catch(Exception ex)
			{
				throw (ex);
			}			
		}

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.Food( name , idCategory , Price )VALUES  ( N'{0}',{1}, {2})",name, id, price);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, id, price, idFood);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("DELETE dbo.Food WHERE id = {0}",idFood);
            int result = DataProvider.Instance.ExcuteNoneQuery(query);
            return result > 0;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();

            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
    }
}
