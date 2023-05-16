
namespace MediaBazaar
{
    partial class SalesForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbShelf = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.btnRequestRestock = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDCategory = new System.Windows.Forms.Label();
            this.lblDSellPrice = new System.Windows.Forms.Label();
            this.lblDBuyPrice = new System.Windows.Forms.Label();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.lblDProductName = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.gbProductsNeedingRestock = new System.Windows.Forms.GroupBox();
            this.lblRestockInfo = new System.Windows.Forms.Label();
            this.lbRestock = new System.Windows.Forms.ListBox();
            this.lblRequestQuantity = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            this.gbProductsNeedingRestock.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.lbShelf);
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Controls.Add(this.tbSearch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(542, 1013);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shelf info";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(407, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 36);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            // 
            // lbShelf
            // 
            this.lbShelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShelf.FormattingEnabled = true;
            this.lbShelf.ItemHeight = 29;
            this.lbShelf.Location = new System.Drawing.Point(10, 97);
            this.lbShelf.Margin = new System.Windows.Forms.Padding(5);
            this.lbShelf.Name = "lbShelf";
            this.lbShelf.Size = new System.Drawing.Size(521, 903);
            this.lbShelf.TabIndex = 1;
            this.lbShelf.SelectedIndexChanged += new System.EventHandler(this.LbShelfSelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(17, 42);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(86, 25);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(113, 36);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(5);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(286, 36);
            this.tbSearch.TabIndex = 11;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearchTextChanged);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1747, 14);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(145, 46);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogoutClick);
            // 
            // gbProductInfo
            // 
            this.gbProductInfo.Controls.Add(this.lblRequestQuantity);
            this.gbProductInfo.Controls.Add(this.tbQuantity);
            this.gbProductInfo.Controls.Add(this.btnRequestRestock);
            this.gbProductInfo.Controls.Add(this.lblCategory);
            this.gbProductInfo.Controls.Add(this.lblDCategory);
            this.gbProductInfo.Controls.Add(this.lblDSellPrice);
            this.gbProductInfo.Controls.Add(this.lblDBuyPrice);
            this.gbProductInfo.Controls.Add(this.lblSellPrice);
            this.gbProductInfo.Controls.Add(this.lblBuyPrice);
            this.gbProductInfo.Controls.Add(this.lblDProductName);
            this.gbProductInfo.Controls.Add(this.lblProductName);
            this.gbProductInfo.Controls.Add(this.lblProduct);
            this.gbProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductInfo.Location = new System.Drawing.Point(1204, 75);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.Size = new System.Drawing.Size(688, 952);
            this.gbProductInfo.TabIndex = 9;
            this.gbProductInfo.TabStop = false;
            this.gbProductInfo.Text = "Product info";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(254, 576);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(235, 33);
            this.tbQuantity.TabIndex = 10;
            // 
            // btnRequestRestock
            // 
            this.btnRequestRestock.Location = new System.Drawing.Point(265, 660);
            this.btnRequestRestock.Name = "btnRequestRestock";
            this.btnRequestRestock.Size = new System.Drawing.Size(211, 55);
            this.btnRequestRestock.TabIndex = 9;
            this.btnRequestRestock.Text = "Request Restock";
            this.btnRequestRestock.UseVisualStyleBackColor = true;
            this.btnRequestRestock.Click += new System.EventHandler(this.BtnRequestRestockClick);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(120, 373);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(116, 29);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Category:";
            // 
            // lblDCategory
            // 
            this.lblDCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCategory.Location = new System.Drawing.Point(260, 373);
            this.lblDCategory.Name = "lblDCategory";
            this.lblDCategory.Size = new System.Drawing.Size(216, 29);
            this.lblDCategory.TabIndex = 7;
            // 
            // lblDSellPrice
            // 
            this.lblDSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSellPrice.Location = new System.Drawing.Point(260, 316);
            this.lblDSellPrice.Name = "lblDSellPrice";
            this.lblDSellPrice.Size = new System.Drawing.Size(216, 29);
            this.lblDSellPrice.TabIndex = 6;
            // 
            // lblDBuyPrice
            // 
            this.lblDBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBuyPrice.Location = new System.Drawing.Point(260, 259);
            this.lblDBuyPrice.Name = "lblDBuyPrice";
            this.lblDBuyPrice.Size = new System.Drawing.Size(216, 29);
            this.lblDBuyPrice.TabIndex = 5;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Location = new System.Drawing.Point(120, 316);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(121, 29);
            this.lblSellPrice.TabIndex = 4;
            this.lblSellPrice.Text = "Sell price:";
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(122, 259);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(119, 29);
            this.lblBuyPrice.TabIndex = 3;
            this.lblBuyPrice.Text = "Buy price:";
            // 
            // lblDProductName
            // 
            this.lblDProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDProductName.Location = new System.Drawing.Point(260, 200);
            this.lblDProductName.Name = "lblDProductName";
            this.lblDProductName.Size = new System.Drawing.Size(216, 29);
            this.lblDProductName.TabIndex = 2;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(157, 200);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(84, 29);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Name:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(282, 86);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(147, 29);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Product info:";
            // 
            // gbProductsNeedingRestock
            // 
            this.gbProductsNeedingRestock.Controls.Add(this.lblRestockInfo);
            this.gbProductsNeedingRestock.Controls.Add(this.lbRestock);
            this.gbProductsNeedingRestock.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductsNeedingRestock.Location = new System.Drawing.Point(564, 14);
            this.gbProductsNeedingRestock.Name = "gbProductsNeedingRestock";
            this.gbProductsNeedingRestock.Size = new System.Drawing.Size(634, 1013);
            this.gbProductsNeedingRestock.TabIndex = 10;
            this.gbProductsNeedingRestock.TabStop = false;
            this.gbProductsNeedingRestock.Text = "Need restock";
            // 
            // lblRestockInfo
            // 
            this.lblRestockInfo.AutoSize = true;
            this.lblRestockInfo.Location = new System.Drawing.Point(137, 43);
            this.lblRestockInfo.Name = "lblRestockInfo";
            this.lblRestockInfo.Size = new System.Drawing.Size(354, 29);
            this.lblRestockInfo.TabIndex = 1;
            this.lblRestockInfo.Text = "These products require restock:";
            // 
            // lbRestock
            // 
            this.lbRestock.FormattingEnabled = true;
            this.lbRestock.ItemHeight = 29;
            this.lbRestock.Location = new System.Drawing.Point(6, 97);
            this.lbRestock.Name = "lbRestock";
            this.lbRestock.Size = new System.Drawing.Size(622, 903);
            this.lbRestock.TabIndex = 0;
            this.lbRestock.SelectedIndexChanged += new System.EventHandler(this.LbRestockSelectedIndexChanged);
            // 
            // lblRequestQuantity
            // 
            this.lblRequestQuantity.AutoSize = true;
            this.lblRequestQuantity.Location = new System.Drawing.Point(29, 579);
            this.lblRequestQuantity.Name = "lblRequestQuantity";
            this.lblRequestQuantity.Size = new System.Drawing.Size(219, 29);
            this.lblRequestQuantity.TabIndex = 11;
            this.lblRequestQuantity.Text = "Quantity to request:";
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.gbProductsNeedingRestock);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.gbProductInfo);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SalesForm";
            this.Text = "MediaBazaar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbProductInfo.ResumeLayout(false);
            this.gbProductInfo.PerformLayout();
            this.gbProductsNeedingRestock.ResumeLayout(false);
            this.gbProductsNeedingRestock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbShelf;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblDProductName;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDCategory;
        private System.Windows.Forms.Label lblDSellPrice;
        private System.Windows.Forms.Label lblDBuyPrice;
        private System.Windows.Forms.GroupBox gbProductsNeedingRestock;
        private System.Windows.Forms.ListBox lbRestock;
        private System.Windows.Forms.Label lblRestockInfo;
        private System.Windows.Forms.Button btnRequestRestock;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblRequestQuantity;
    }
}