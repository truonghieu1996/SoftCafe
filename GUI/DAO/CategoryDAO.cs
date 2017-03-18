using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
	public class CategoryDAO
	{
		private static CategoryDAO instance;

		public static CategoryDAO Instance
		{
			get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
			private set { CategoryDAO.instance = value; }
		}

		private CategoryDAO() { }

		public List<Category> GetListCategory()
		{
			List<Category> listcategory = new List<Category>();
			string query = "USP_GetListFoodCategory";
			DataTable data = DataProvider.Instance.ExcuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				Category category = new Category(item);
				listcategory.Add(category);
			}
			return listcategory;
		}

		public Category GetCatagoryByID(int id)
		{
			Category category = null;
			string query = "select * from FoodCategory where id = " + id;
			DataTable data = DataProvider.Instance.ExcuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				category = new Category(item);
				return category;
			}
			return category;
		}
		public bool InsertCategory(string nameCategory)
		{
			string query = string.Format("INSERT INTO dbo.FoodCategory( name )VALUES  ( N'{0}' )",nameCategory);
			int result = DataProvider.Instance.ExcuteNoneQuery(query);
			return result > 0;
		}
		public bool DeleteCategory(int id)
		{
			string query = "EXEC dbo.USP_DeleteCateGoryByID @id ";
			int result = DataProvider.Instance.ExcuteNoneQuery(query, new object[] { id });
			return result > 0;
		}
		public bool UpdateCategory(int id ,string nameCategory)
		{
			string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{1}' WHERE id = {0} ", id , nameCategory);
			int result = DataProvider.Instance.ExcuteNoneQuery(query);
			return result > 0;
		}
    }
}
