using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount.Type); }
        }
        public frmTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadCombooxTable(cmbSwichTable);
        }
        #region Methods

        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảngToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        void LoadCombooxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "name";
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategoryFood.DataSource = listCategory;
            cbCategoryFood.DisplayMember = "name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetlistFood(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "name";
        }

        void LoadTable()
        {
            flpTableList.Controls.Clear();
            List<Table> tablelist =  TableDAO.Instance.LoadTableList();
            foreach (Table item in tablelist)
            {
                Button btn = new Button() {Width = TableDAO.tableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.MouseMove +=btn_MouseMove;
                btn.MouseLeave +=btn_MouseLeave;
                //btn.FlatStyle = FlatStyle.Flat;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.WhiteSmoke;
                        break;
                    default:
                        btn.BackColor = Color.Aqua;
                        break;
                }
                flpTableList.Controls.Add(btn);
            }
        }
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            if(((sender as Button).Tag as Table).Status.Trim().ToLower().CompareTo("trống")==0)
                (sender as Button).BackColor = Color.WhiteSmoke;
            else
                (sender as Button).BackColor = Color.Aqua;
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = Color.Yellow;
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<GUI.DTO.Menu> listmenu = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (GUI.DTO.Menu item in listmenu)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = cultureInfo; thay đổi trong cài đặt máy tính.
            txttotalPrice.Text = totalPrice.ToString("c",cultureInfo);
        }
        #endregion

        #region Events
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccountProfile frmAccountInfo = new FrmAccountProfile(LoginAccount);
            frmAccountInfo.ShowDialog();
        }

        

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin frmadmin = new frmAdmin();
            frmadmin.InsertFood += frmadmin_InsertFood;
            frmadmin.UpdateFood += frmadmin_UpdateFood;
            frmadmin.DeleteFood += frmadmin_DeleteFood;
			frmadmin.InsertCategory += Frmadmin_InsertCategory;
			frmadmin.UpdateCategory += Frmadmin_UpdateCategory;
			frmadmin.DeleteCategory += Frmadmin_DeleteCategory;
			frmadmin.InsertTable += Frmadmin_InsertTable;
			frmadmin.DeleteTable += Frmadmin_DeleteTable;
            frmadmin.ShowDialog();
        }

		private void Frmadmin_DeleteTable(object sender, EventArgs e)
		{
			LoadTable();
		}

		private void Frmadmin_InsertTable(object sender, EventArgs e)
		{
			LoadTable();
		}

		private void Frmadmin_DeleteCategory(object sender, EventArgs e)
		{
			LoadCategory();
		}

		private void Frmadmin_UpdateCategory(object sender, EventArgs e)
		{
			LoadCategory();
		}

		private void Frmadmin_InsertCategory(object sender, EventArgs e)
		{
			LoadCategory();
		}

		private void frmadmin_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void frmadmin_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void frmadmin_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).Id);
            if(lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }
        

        private void cnCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFood.ResetText();
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.Id;
            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
                Table table = lsvBill.Tag as Table;
                if (table != null)
                {
                    int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                    int idFood = (cbFood.SelectedItem as Food).Id;
                    int count = (int)nmFoodCount.Value;
                    if (idBill == -1)
                    {
                        BillDAO.Instance.InsertBill(table.ID);
                        BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
                    }
                    else
                    {
                        BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                    }
                    ShowBill(table.ID);
                    LoadTable();
                }
                else 
                {
                    MessageBox.Show("Bạn chưa chọn bàn !", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = lsvBill.Tag as Table;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                int discount = (int)nmDiscount.Value;
                double totalPrice = Convert.ToDouble(txttotalPrice.Text.Split(',')[0]);
                double finalTotalPrice = (totalPrice - (totalPrice / 100) * discount) * 1000;
                if (idBill != -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền /100) x Giảm giá\n => {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                        ShowBill(table.ID);
                        LoadTable();
                    }
                }
            }
            catch
            { 
                return; 
            }
        }

        private void btnSwichTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id1 = (lsvBill.Tag as Table).ID;
                int id2 = (cmbSwichTable.SelectedItem as Table).ID;
                if (MessageBox.Show(string.Format("Bạn có muốn chuyễn bàn {0} sang bàn {1} không ?", (lsvBill.Tag as Table).Name, (cmbSwichTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    TableDAO.Instance.SwitchTable(id1, id2);
                    LoadTable();
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
