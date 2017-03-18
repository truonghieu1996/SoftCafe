using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GUI.DAO;
using GUI.DTO;

namespace GUI
{
	public partial class frmAdmin : Form
	{
		BindingSource foofList = new BindingSource();
		BindingSource categoryList = new BindingSource();
		BindingSource listTable = new BindingSource();
		BindingSource listAccount = new BindingSource();
		public frmAdmin()
		{
			InitializeComponent();
			Load();
		}

		#region Methods
		void Load()
		{
			dgvFood.DataSource = foofList;
			dgvCategory.DataSource = categoryList;
			dgvTable.DataSource = listTable;
			dgvAccount.DataSource = listAccount;
			LoadDaTimePickerBill();
			LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
			LoadListFood();
			LoadCategoryIntoCombobox(cbCategory);
			addFoodBinding();
			LoadListCategory();
			addCategoryBinding();
			LoadListTable();
			addBindingTable();
			LoadListAccount();
			addBindingAccount();
		}

		List<Food> SearchFoodByName(string name)
		{
			List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

			return listFood;
		}

		void LoadListAccount()
		{
			listAccount.DataSource = AccountDAO.Instance.GetAccount();
			dgvAccount.Columns["username"].HeaderText = "Tên tài khoản";
			dgvAccount.Columns["displayname"].HeaderText = "Tên hiển thị";
			dgvAccount.Columns["type"].HeaderText = "Loại tài khoản";
		}

		void LoadListTable()
		{
			listTable.DataSource = TableDAO.Instance.LoadTableList();
			dgvTable.Columns["id"].Visible = false;
			dgvTable.Columns["name"].HeaderText = "Tên bàn";
			dgvTable.Columns["status"].HeaderText = "Trạng thái";
		}

		void LoadListCategory()
		{
			categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
			dgvCategory.Columns["id"].Visible = false;
			dgvCategory.Columns["name"].HeaderText = "Tên danh mục";
		}

		void LoadListFood()
		{
			foofList.DataSource = FoodDAO.Instance.GetFood();
			dgvFood.Columns["id"].Visible = false;
			dgvFood.Columns["id1"].Visible = false;
			dgvFood.Columns["idCategory"].Visible = false;
			dgvFood.Columns["name"].HeaderText = "Tên món";
			dgvFood.Columns["name1"].HeaderText = "Danh mục";
			dgvFood.Columns["Price"].HeaderText = "Giá";
		}

		void LoadDaTimePickerBill()
		{
			DateTime today = DateTime.Now;
			dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
			dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
		}
		void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
		{
			dgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
		}

		void addFoodBinding()
		{
			txtNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "name", true, DataSourceUpdateMode.Never));
			txtFoodID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "id", true, DataSourceUpdateMode.Never));
			nmFoodPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));

		}

		void addCategoryBinding()
		{
			txtCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
			txtnameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
		}

		void addBindingTable()
		{
			txtTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
			txtTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
			txtStatus.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
		}

		void addBindingAccount()
		{
			txtNameAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "username", true, DataSourceUpdateMode.Never));
			txtViewName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "displayname", true, DataSourceUpdateMode.Never));
			nmTypeAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
		}

		void LoadCategoryIntoCombobox(ComboBox cb)
		{
			cb.DataSource = CategoryDAO.Instance.GetListCategory();
			cb.DisplayMember = "name";
		}

		void LoadStatusTableIntoCombobox(ComboBox cb)
		{
			cb.DataSource = TableDAO.Instance.LoadTableList();
			cb.DisplayMember = "status";
		}

		void AddAccount(string username, string displayname, int type)
		{
			try
			{
				if (AccountDAO.Instance.InsertAccount(username, displayname, type))
				{
					MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListAccount();
				}
				else
				{
					MessageBox.Show("Thêm tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				MessageBox.Show("Tên người dùng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void DeleteAccount(string username)
		{
			try
			{
				if (AccountDAO.Instance.DeleteAccount(username))
				{
					MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListAccount();
				}
				else
				{
					MessageBox.Show("Xóa tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				MessageBox.Show(" Xóa thất bại. Tài khoản này đang dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void UpdateAccount(string username, string displayname, int type)
		{
			try
			{
				if (AccountDAO.Instance.UpdateAccount1(username, displayname, type))
				{
					MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListAccount();
				}
				else
				{
					MessageBox.Show("Cập nhật tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				return;
			}
		}

		void ResetPassword(string username)
		{
			try
			{
				if (AccountDAO.Instance.ResetPassword(username))
				{
					MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Đặt lại mật khẩu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				return;
			}
		}

		#endregion
		#region Events
		private event EventHandler insertFood;
		public event EventHandler InsertFood
		{
			add { insertFood += value; }
			remove { insertFood -= value; }
		}

		private event EventHandler deleteFood;
		public event EventHandler DeleteFood
		{
			add { deleteFood += value; }
			remove { deleteFood -= value; }
		}

		private event EventHandler updateFood;
		public event EventHandler UpdateFood
		{
			add { updateFood += value; }
			remove { updateFood -= value; }
		}

		private event EventHandler insertCategory;
		public event EventHandler InsertCategory
		{
			add { insertCategory += value; }
			remove { insertCategory -= value; }
		}

		private event EventHandler updateCategory;
		public event EventHandler UpdateCategory
		{
			add { updateCategory += value; }
			remove { updateCategory -= value; }
		}

		private event EventHandler deleteCategory;
		public event EventHandler DeleteCategory
		{
			add { deleteCategory += value; }
			remove { deleteCategory -= value; }
		}

		private event EventHandler insertTable;
		public event EventHandler InsertTable
		{
			add { insertTable += value; }
			remove { insertTable -= value; }
		}

		private event EventHandler deleteTable;
		public event EventHandler DeleteTable
		{
			add { deleteTable += value; }
			remove { deleteTable -= value; }
		} 

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }
        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                    Category category = CategoryDAO.Instance.GetCatagoryByID(id);

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbCategory.Items)
                    {
                        if (item.Id == category.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbCategory.SelectedIndex = index;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy tên bạn vừa nhập!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }      
        }
        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameFood.Text;
                int CategoryID = (cbCategory.SelectedItem as Category).Id;
                float price = (float)nmFoodPrice.Value;
                if (FoodDAO.Instance.InsertFood(name, CategoryID, price))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListFood();
                    if (insertFood != null)
                        insertFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm thức ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                return;
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtFoodID.Text);
                if (FoodDAO.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListFood();
                    if (deleteFood != null)
                        deleteFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                return;
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameFood.Text;
                int CategoryID = (cbCategory.SelectedItem as Category).Id;
                float price = (float)nmFoodPrice.Value;
                int id = Convert.ToInt32(txtFoodID.Text);
                if (FoodDAO.Instance.UpdateFood(id, name, CategoryID, price))
                {
                    MessageBox.Show("Sửa thành công.", "Thông báo");
                    LoadListFood();
                    if (updateFood != null)
                        updateFood(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Sửa thất bại.", "Thông báo");
                }
            }
            catch
            {
                return;
            }
        }
        
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            if (txtSearchFoodName.Text != "")
            {
                foofList.DataSource = SearchFoodByName(txtSearchFoodName.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu cho ô tìm kiếm!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchFoodName.Focus();
            }

        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string displayname = txtViewName.Text;
            string username = txtNameAccount.Text;
            int type = (int)nmTypeAccount.Value;
            AddAccount(username,displayname,type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtNameAccount.Text;
            if (nmTypeAccount.Value != 1)
            {
                DeleteAccount(username);
            }
            else
            {
                MessageBox.Show("Không thể xóa tài khoản thuộc về người quản trị !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string displayname = txtViewName.Text;
            string username = txtNameAccount.Text;
            int type = (int)nmTypeAccount.Value;
            UpdateAccount(username, displayname, type);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtNameAccount.Text;
            ResetPassword(username);
        }
		private void btnAddTable_Click(object sender, EventArgs e)
		{
			try
			{
				string nameTable = txtTableName.Text;
				if (TableDAO.Instance.InsertTableFood(nameTable))
				{
					MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListTable();
					if (insertTable != null)
						insertTable(this, new EventArgs());
				}
				else
				{
					MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch
			{ return; }
		}

		private void btnDeleteTable_Click(object sender, EventArgs e)
		{
			try
			{
				int id = int.Parse(txtTableID.Text);
				if (TableDAO.Instance.DeleteTableByID(id))
				{
					MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListTable();
					if (deleteTable != null)
						deleteTable(this, new EventArgs());
				}
				else
				{
					MessageBox.Show("Xóa không thành công! \nBàn chỉ xóa được khi bàn trống và thông tin hóa đơn trên bàn đó không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch
			{
				return;
			}
		}

		private void btnAddCategory_Click(object sender, EventArgs e)
		{
			if (txtnameCategory.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập thông tin cho tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				try
				{
					string nameCategory = txtnameCategory.Text.ToString();
					if (CategoryDAO.Instance.InsertCategory(nameCategory))
					{
						MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadListCategory();
						if (insertCategory != null)
							insertCategory(this, new EventArgs());
					}
					else
					{
						MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				catch
				{
					return;
				}
			}
		}

		private void btnDeleteCategory_Click(object sender, EventArgs e)
		{
			try
			{
				int id = int.Parse(txtCategoryID.Text);
				if (CategoryDAO.Instance.DeleteCategory(id))
				{
					MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListCategory();
					if (deleteCategory != null)
						deleteCategory(this, new EventArgs());
				}
				else
				{
					MessageBox.Show("Xóa không thành công! \nDanh mục này chỉ xóa được khi danh sách thức ăn trong danh mục này rổng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch
			{
				return;
			}
		}

		private void btnEditCategory_Click(object sender, EventArgs e)
		{
			try
			{
				string nameCategory = txtnameCategory.Text.ToString();
				int id = int.Parse(txtCategoryID.Text);
				if (CategoryDAO.Instance.UpdateCategory(id,nameCategory))
				{
					MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadListCategory();
					if (updateCategory != null)
						updateCategory(this, new EventArgs());
				}
				else
				{
					MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch
			{
				return;
			}
		}
		#endregion
	}
}
