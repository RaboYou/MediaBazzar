
namespace MediaBazaar
{
    partial class AddProduct
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
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.tBSearchProduct = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tBSellPrice = new System.Windows.Forms.TextBox();
            this.cBProductStatus = new System.Windows.Forms.ComboBox();
            this.cBProductCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBBuyPrice = new System.Windows.Forms.TextBox();
            this.btnCreateProduct = new System.Windows.Forms.Button();
            this.tBProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbProductWeight = new System.Windows.Forms.TextBox();
            this.tbProductDepth = new System.Windows.Forms.TextBox();
            this.tbProductHeight = new System.Windows.Forms.TextBox();
            this.tbProductWidth = new System.Windows.Forms.TextBox();
            this.manufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.manufacturerLabel = new System.Windows.Forms.Label();
            this.tBproductDescription = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAddManufacturer = new System.Windows.Forms.Button();
            this.btnViewRestocks = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbProducts
            // 
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.ItemHeight = 29;
            this.lbProducts.Location = new System.Drawing.Point(9, 138);
            this.lbProducts.Margin = new System.Windows.Forms.Padding(2);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(338, 497);
            this.lbProducts.TabIndex = 35;
            this.lbProducts.SelectedIndexChanged += new System.EventHandler(this.LbProductsSelectedIndexChanged);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(297, 522);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(137, 54);
            this.btnEditProduct.TabIndex = 26;
            this.btnEditProduct.Text = "Edit";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.EditProductButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchProduct);
            this.groupBox2.Controls.Add(this.lbProducts);
            this.groupBox2.Controls.Add(this.tBSearchProduct);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.groupBox2.Location = new System.Drawing.Point(623, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(362, 676);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit Product";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(246, 86);
            this.btnSearchProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(100, 39);
            this.btnSearchProduct.TabIndex = 37;
            this.btnSearchProduct.Text = "Search";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.BtnSearchProductClick);
            // 
            // tBSearchProduct
            // 
            this.tBSearchProduct.Location = new System.Drawing.Point(178, 44);
            this.tBSearchProduct.Margin = new System.Windows.Forms.Padding(2);
            this.tBSearchProduct.Name = "tBSearchProduct";
            this.tBSearchProduct.Size = new System.Drawing.Size(168, 35);
            this.tBSearchProduct.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 29);
            this.label11.TabIndex = 22;
            this.label11.Text = "Search product:";
            // 
            // tBSellPrice
            // 
            this.tBSellPrice.Location = new System.Drawing.Point(184, 166);
            this.tBSellPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tBSellPrice.Name = "tBSellPrice";
            this.tBSellPrice.Size = new System.Drawing.Size(333, 35);
            this.tBSellPrice.TabIndex = 14;
            // 
            // cBProductStatus
            // 
            this.cBProductStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBProductStatus.FormattingEnabled = true;
            this.cBProductStatus.Location = new System.Drawing.Point(184, 292);
            this.cBProductStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cBProductStatus.Name = "cBProductStatus";
            this.cBProductStatus.Size = new System.Drawing.Size(333, 37);
            this.cBProductStatus.TabIndex = 13;
            // 
            // cBProductCategory
            // 
            this.cBProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBProductCategory.FormattingEnabled = true;
            this.cBProductCategory.Location = new System.Drawing.Point(184, 247);
            this.cBProductCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cBProductCategory.Name = "cBProductCategory";
            this.cBProductCategory.Size = new System.Drawing.Size(333, 37);
            this.cBProductCategory.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 293);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 252);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sell price (€):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buy price (€):";
            // 
            // tBBuyPrice
            // 
            this.tBBuyPrice.Location = new System.Drawing.Point(184, 126);
            this.tBBuyPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tBBuyPrice.Name = "tBBuyPrice";
            this.tBBuyPrice.Size = new System.Drawing.Size(333, 35);
            this.tBBuyPrice.TabIndex = 3;
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.Location = new System.Drawing.Point(109, 522);
            this.btnCreateProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(137, 54);
            this.btnCreateProduct.TabIndex = 2;
            this.btnCreateProduct.Text = "Create";
            this.btnCreateProduct.UseVisualStyleBackColor = true;
            this.btnCreateProduct.Click += new System.EventHandler(this.BtnCreateProductClick);
            // 
            // tBProductName
            // 
            this.tBProductName.Location = new System.Drawing.Point(184, 88);
            this.tBProductName.Margin = new System.Windows.Forms.Padding(2);
            this.tBProductName.Name = "tBProductName";
            this.tBProductName.Size = new System.Drawing.Size(333, 35);
            this.tBProductName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnEditProduct);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tbProductWeight);
            this.groupBox1.Controls.Add(this.tbProductDepth);
            this.groupBox1.Controls.Add(this.tbProductHeight);
            this.groupBox1.Controls.Add(this.tbProductWidth);
            this.groupBox1.Controls.Add(this.manufacturerComboBox);
            this.groupBox1.Controls.Add(this.manufacturerLabel);
            this.groupBox1.Controls.Add(this.tBproductDescription);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tBSellPrice);
            this.groupBox1.Controls.Add(this.cBProductStatus);
            this.groupBox1.Controls.Add(this.cBProductCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tBBuyPrice);
            this.groupBox1.Controls.Add(this.btnCreateProduct);
            this.groupBox1.Controls.Add(this.tBProductName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.groupBox1.Location = new System.Drawing.Point(16, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(541, 783);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Product";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 667);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 54);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(205, 595);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 54);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 456);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 29);
            this.label18.TabIndex = 26;
            this.label18.Text = "Weight (g):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 417);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 29);
            this.label17.TabIndex = 25;
            this.label17.Text = "Depth (cm):";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 378);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 29);
            this.label16.TabIndex = 24;
            this.label16.Text = "Height (cm):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 339);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 29);
            this.label15.TabIndex = 23;
            this.label15.Text = "Width (cm):";
            // 
            // tbProductWeight
            // 
            this.tbProductWeight.Location = new System.Drawing.Point(184, 450);
            this.tbProductWeight.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductWeight.Name = "tbProductWeight";
            this.tbProductWeight.Size = new System.Drawing.Size(333, 35);
            this.tbProductWeight.TabIndex = 22;
            // 
            // tbProductDepth
            // 
            this.tbProductDepth.Location = new System.Drawing.Point(184, 411);
            this.tbProductDepth.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductDepth.Name = "tbProductDepth";
            this.tbProductDepth.Size = new System.Drawing.Size(333, 35);
            this.tbProductDepth.TabIndex = 21;
            // 
            // tbProductHeight
            // 
            this.tbProductHeight.Location = new System.Drawing.Point(184, 372);
            this.tbProductHeight.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductHeight.Name = "tbProductHeight";
            this.tbProductHeight.Size = new System.Drawing.Size(333, 35);
            this.tbProductHeight.TabIndex = 20;
            // 
            // tbProductWidth
            // 
            this.tbProductWidth.Location = new System.Drawing.Point(184, 333);
            this.tbProductWidth.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductWidth.Name = "tbProductWidth";
            this.tbProductWidth.Size = new System.Drawing.Size(333, 35);
            this.tbProductWidth.TabIndex = 19;
            // 
            // manufacturerComboBox
            // 
            this.manufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerComboBox.FormattingEnabled = true;
            this.manufacturerComboBox.Location = new System.Drawing.Point(184, 43);
            this.manufacturerComboBox.Name = "manufacturerComboBox";
            this.manufacturerComboBox.Size = new System.Drawing.Size(333, 37);
            this.manufacturerComboBox.TabIndex = 18;
            // 
            // manufacturerLabel
            // 
            this.manufacturerLabel.AutoSize = true;
            this.manufacturerLabel.Location = new System.Drawing.Point(14, 51);
            this.manufacturerLabel.Name = "manufacturerLabel";
            this.manufacturerLabel.Size = new System.Drawing.Size(158, 29);
            this.manufacturerLabel.TabIndex = 17;
            this.manufacturerLabel.Text = "Manufacturer:";
            // 
            // tBproductDescription
            // 
            this.tBproductDescription.Location = new System.Drawing.Point(184, 206);
            this.tBproductDescription.Margin = new System.Windows.Forms.Padding(2);
            this.tBproductDescription.Name = "tBproductDescription";
            this.tBproductDescription.Size = new System.Drawing.Size(333, 35);
            this.tBproductDescription.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 212);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 29);
            this.label13.TabIndex = 15;
            this.label13.Text = "Description:";
            // 
            // btnAddManufacturer
            // 
            this.btnAddManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnAddManufacturer.Location = new System.Drawing.Point(1119, 294);
            this.btnAddManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddManufacturer.Name = "btnAddManufacturer";
            this.btnAddManufacturer.Size = new System.Drawing.Size(164, 72);
            this.btnAddManufacturer.TabIndex = 14;
            this.btnAddManufacturer.Text = "Add Manufacturer";
            this.btnAddManufacturer.Click += new System.EventHandler(this.BtnAddManufacturerClick);
            // 
            // btnViewRestocks
            // 
            this.btnViewRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnViewRestocks.Location = new System.Drawing.Point(1119, 457);
            this.btnViewRestocks.Name = "btnViewRestocks";
            this.btnViewRestocks.Size = new System.Drawing.Size(179, 72);
            this.btnViewRestocks.TabIndex = 15;
            this.btnViewRestocks.Text = "View Restocks";
            this.btnViewRestocks.UseVisualStyleBackColor = true;
            this.btnViewRestocks.Click += new System.EventHandler(this.btnViewRestocks_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 846);
            this.Controls.Add(this.btnViewRestocks);
            this.Controls.Add(this.btnAddManufacturer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tBSearchProduct;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBSellPrice;
        private System.Windows.Forms.ComboBox cBProductStatus;
        private System.Windows.Forms.ComboBox cBProductCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBBuyPrice;
        private System.Windows.Forms.Button btnCreateProduct;
        private System.Windows.Forms.TextBox tBProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBproductDescription;
        private System.Windows.Forms.Button btnAddManufacturer;
        private System.Windows.Forms.ComboBox manufacturerComboBox;
        private System.Windows.Forms.Label manufacturerLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbProductWeight;
        private System.Windows.Forms.TextBox tbProductDepth;
        private System.Windows.Forms.TextBox tbProductHeight;
        private System.Windows.Forms.TextBox tbProductWidth;
        private System.Windows.Forms.Button btnViewRestocks;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
    }
}