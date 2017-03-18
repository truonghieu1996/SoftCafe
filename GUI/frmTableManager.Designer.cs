namespace GUI
{
    partial class frmTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableManager));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinTàiKhoảngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flpTableList = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txttotalPrice = new System.Windows.Forms.TextBox();
			this.nmDiscount = new System.Windows.Forms.NumericUpDown();
			this.btnCheckOut = new System.Windows.Forms.Button();
			this.cmbSwichTable = new System.Windows.Forms.ComboBox();
			this.btnSwichTable = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
			this.btnAddFood = new System.Windows.Forms.Button();
			this.cbFood = new System.Windows.Forms.ComboBox();
			this.cbCategoryFood = new System.Windows.Forms.ComboBox();
			this.lsvBill = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảngToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(972, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// adminToolStripMenuItem
			// 
			this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
			this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.adminToolStripMenuItem.Text = "Admin";
			this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
			// 
			// thôngTinTàiKhoảngToolStripMenuItem
			// 
			this.thôngTinTàiKhoảngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
			this.thôngTinTàiKhoảngToolStripMenuItem.Name = "thôngTinTàiKhoảngToolStripMenuItem";
			this.thôngTinTàiKhoảngToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
			this.thôngTinTàiKhoảngToolStripMenuItem.Text = "Thông tin tài khoảng";
			// 
			// thôngTinCáNhânToolStripMenuItem
			// 
			this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
			this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
			this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
			// 
			// đăngXuấtToolStripMenuItem
			// 
			this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
			this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
			this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
			// 
			// flpTableList
			// 
			this.flpTableList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpTableList.AutoScroll = true;
			this.flpTableList.Location = new System.Drawing.Point(12, 30);
			this.flpTableList.Name = "flpTableList";
			this.flpTableList.Size = new System.Drawing.Size(431, 506);
			this.flpTableList.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.txttotalPrice);
			this.panel2.Controls.Add(this.nmDiscount);
			this.panel2.Controls.Add(this.btnCheckOut);
			this.panel2.Location = new System.Drawing.Point(449, 480);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(511, 56);
			this.panel2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "Giảm giá";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(185, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "Tổng tiền";
			// 
			// txttotalPrice
			// 
			this.txttotalPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txttotalPrice.ForeColor = System.Drawing.Color.Red;
			this.txttotalPrice.Location = new System.Drawing.Point(254, 22);
			this.txttotalPrice.Name = "txttotalPrice";
			this.txttotalPrice.ReadOnly = true;
			this.txttotalPrice.Size = new System.Drawing.Size(109, 22);
			this.txttotalPrice.TabIndex = 10;
			this.txttotalPrice.Text = "0";
			this.txttotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// nmDiscount
			// 
			this.nmDiscount.Location = new System.Drawing.Point(71, 23);
			this.nmDiscount.Name = "nmDiscount";
			this.nmDiscount.Size = new System.Drawing.Size(75, 20);
			this.nmDiscount.TabIndex = 7;
			// 
			// btnCheckOut
			// 
			this.btnCheckOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCheckOut.Location = new System.Drawing.Point(428, 8);
			this.btnCheckOut.Name = "btnCheckOut";
			this.btnCheckOut.Size = new System.Drawing.Size(75, 45);
			this.btnCheckOut.TabIndex = 1;
			this.btnCheckOut.Text = "Thanh toán";
			this.btnCheckOut.UseVisualStyleBackColor = true;
			this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
			// 
			// cmbSwichTable
			// 
			this.cmbSwichTable.FormattingEnabled = true;
			this.cmbSwichTable.Location = new System.Drawing.Point(428, 28);
			this.cmbSwichTable.Name = "cmbSwichTable";
			this.cmbSwichTable.Size = new System.Drawing.Size(75, 21);
			this.cmbSwichTable.TabIndex = 9;
			// 
			// btnSwichTable
			// 
			this.btnSwichTable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSwichTable.Location = new System.Drawing.Point(428, 3);
			this.btnSwichTable.Name = "btnSwichTable";
			this.btnSwichTable.Size = new System.Drawing.Size(75, 24);
			this.btnSwichTable.TabIndex = 8;
			this.btnSwichTable.Text = "Chuyển bàn";
			this.btnSwichTable.UseVisualStyleBackColor = true;
			this.btnSwichTable.Click += new System.EventHandler(this.btnSwichTable_Click);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.nmFoodCount);
			this.panel3.Controls.Add(this.btnAddFood);
			this.panel3.Controls.Add(this.cbFood);
			this.panel3.Controls.Add(this.cmbSwichTable);
			this.panel3.Controls.Add(this.cbCategoryFood);
			this.panel3.Controls.Add(this.btnSwichTable);
			this.panel3.Location = new System.Drawing.Point(449, 27);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(523, 51);
			this.panel3.TabIndex = 4;
			// 
			// nmFoodCount
			// 
			this.nmFoodCount.Location = new System.Drawing.Point(339, 17);
			this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.nmFoodCount.Name = "nmFoodCount";
			this.nmFoodCount.Size = new System.Drawing.Size(69, 20);
			this.nmFoodCount.TabIndex = 7;
			this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnAddFood
			// 
			this.btnAddFood.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnAddFood.FlatAppearance.BorderSize = 2;
			this.btnAddFood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
			this.btnAddFood.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnAddFood.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddFood.Location = new System.Drawing.Point(246, 3);
			this.btnAddFood.Name = "btnAddFood";
			this.btnAddFood.Size = new System.Drawing.Size(75, 45);
			this.btnAddFood.TabIndex = 0;
			this.btnAddFood.Text = "Thêm món";
			this.btnAddFood.UseVisualStyleBackColor = true;
			this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
			// 
			// cbFood
			// 
			this.cbFood.FormattingEnabled = true;
			this.cbFood.Location = new System.Drawing.Point(0, 27);
			this.cbFood.Name = "cbFood";
			this.cbFood.Size = new System.Drawing.Size(238, 21);
			this.cbFood.TabIndex = 6;
			// 
			// cbCategoryFood
			// 
			this.cbCategoryFood.FormattingEnabled = true;
			this.cbCategoryFood.Location = new System.Drawing.Point(0, 3);
			this.cbCategoryFood.Name = "cbCategoryFood";
			this.cbCategoryFood.Size = new System.Drawing.Size(238, 21);
			this.cbCategoryFood.TabIndex = 5;
			this.cbCategoryFood.SelectedIndexChanged += new System.EventHandler(this.cnCategoryFood_SelectedIndexChanged);
			// 
			// lsvBill
			// 
			this.lsvBill.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
			this.lsvBill.AllowDrop = true;
			this.lsvBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lsvBill.GridLines = true;
			this.lsvBill.Location = new System.Drawing.Point(449, 81);
			this.lsvBill.Name = "lsvBill";
			this.lsvBill.Size = new System.Drawing.Size(523, 393);
			this.lsvBill.TabIndex = 0;
			this.lsvBill.UseCompatibleStateImageBehavior = false;
			this.lsvBill.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Tên món";
			this.columnHeader1.Width = 170;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Số lượng";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Đơn giá";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Thành tiền";
			this.columnHeader4.Width = 150;
			// 
			// frmTableManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(972, 541);
			this.Controls.Add(this.lsvBill);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.flpTableList);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmTableManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phần mền quản lý quán cafe";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpTableList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategoryFood;
        private System.Windows.Forms.ComboBox cmbSwichTable;
        private System.Windows.Forms.Button btnSwichTable;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttotalPrice;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lsvBill;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
	}
}