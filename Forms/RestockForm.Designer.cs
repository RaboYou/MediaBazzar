
namespace MediaBazzar.Forms
{
    partial class RestockForm
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
            this.btnSearchRestocks = new System.Windows.Forms.Button();
            this.lbRestocks = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearchRestocks = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAcceptQuantity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblAcceptCategory = new System.Windows.Forms.Label();
            this.lblAcceptSellPrice = new System.Windows.Forms.Label();
            this.lblAcceptBuyPrice = new System.Windows.Forms.Label();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.lblAcceptProductName = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnAcceptRestocks = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearchConfirmedRestocks = new System.Windows.Forms.Button();
            this.lbConfirmedRestocks = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchConfirmedRestocks = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchRestocks);
            this.groupBox2.Controls.Add(this.lbRestocks);
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Controls.Add(this.tbSearchRestocks);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(542, 1013);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active Restocks";
            // 
            // btnSearchRestocks
            // 
            this.btnSearchRestocks.Location = new System.Drawing.Point(407, 35);
            this.btnSearchRestocks.Name = "btnSearchRestocks";
            this.btnSearchRestocks.Size = new System.Drawing.Size(123, 36);
            this.btnSearchRestocks.TabIndex = 12;
            this.btnSearchRestocks.Text = "Search";
            this.btnSearchRestocks.UseVisualStyleBackColor = true;
            this.btnSearchRestocks.Click += new System.EventHandler(this.btnSearchRestocks_Click);
            // 
            // lbRestocks
            // 
            this.lbRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRestocks.FormattingEnabled = true;
            this.lbRestocks.ItemHeight = 29;
            this.lbRestocks.Location = new System.Drawing.Point(10, 97);
            this.lbRestocks.Margin = new System.Windows.Forms.Padding(5);
            this.lbRestocks.Name = "lbRestocks";
            this.lbRestocks.Size = new System.Drawing.Size(521, 903);
            this.lbRestocks.TabIndex = 1;
            this.lbRestocks.SelectedIndexChanged += new System.EventHandler(this.lbRestocks_SelectedIndexChanged);
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
            // tbSearchRestocks
            // 
            this.tbSearchRestocks.Location = new System.Drawing.Point(113, 36);
            this.tbSearchRestocks.Margin = new System.Windows.Forms.Padding(5);
            this.tbSearchRestocks.Multiline = true;
            this.tbSearchRestocks.Name = "tbSearchRestocks";
            this.tbSearchRestocks.Size = new System.Drawing.Size(286, 36);
            this.tbSearchRestocks.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAcceptQuantity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.lblAcceptCategory);
            this.groupBox1.Controls.Add(this.lblAcceptSellPrice);
            this.groupBox1.Controls.Add(this.lblAcceptBuyPrice);
            this.groupBox1.Controls.Add(this.lblSellPrice);
            this.groupBox1.Controls.Add(this.lblBuyPrice);
            this.groupBox1.Controls.Add(this.lblAcceptProductName);
            this.groupBox1.Controls.Add(this.lblProductName);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.btnAcceptRestocks);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(566, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(542, 1013);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accept Restocks";
            // 
            // lblAcceptQuantity
            // 
            this.lblAcceptQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptQuantity.Location = new System.Drawing.Point(201, 488);
            this.lblAcceptQuantity.Name = "lblAcceptQuantity";
            this.lblAcceptQuantity.Size = new System.Drawing.Size(216, 29);
            this.lblAcceptQuantity.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Quantity:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(61, 429);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(116, 29);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "Category:";
            // 
            // lblAcceptCategory
            // 
            this.lblAcceptCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptCategory.Location = new System.Drawing.Point(201, 429);
            this.lblAcceptCategory.Name = "lblAcceptCategory";
            this.lblAcceptCategory.Size = new System.Drawing.Size(216, 29);
            this.lblAcceptCategory.TabIndex = 21;
            // 
            // lblAcceptSellPrice
            // 
            this.lblAcceptSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptSellPrice.Location = new System.Drawing.Point(201, 372);
            this.lblAcceptSellPrice.Name = "lblAcceptSellPrice";
            this.lblAcceptSellPrice.Size = new System.Drawing.Size(216, 29);
            this.lblAcceptSellPrice.TabIndex = 20;
            // 
            // lblAcceptBuyPrice
            // 
            this.lblAcceptBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptBuyPrice.Location = new System.Drawing.Point(201, 315);
            this.lblAcceptBuyPrice.Name = "lblAcceptBuyPrice";
            this.lblAcceptBuyPrice.Size = new System.Drawing.Size(216, 29);
            this.lblAcceptBuyPrice.TabIndex = 19;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Location = new System.Drawing.Point(61, 372);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(121, 29);
            this.lblSellPrice.TabIndex = 18;
            this.lblSellPrice.Text = "Sell price:";
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(63, 315);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(119, 29);
            this.lblBuyPrice.TabIndex = 17;
            this.lblBuyPrice.Text = "Buy price:";
            // 
            // lblAcceptProductName
            // 
            this.lblAcceptProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptProductName.Location = new System.Drawing.Point(201, 256);
            this.lblAcceptProductName.Name = "lblAcceptProductName";
            this.lblAcceptProductName.Size = new System.Drawing.Size(216, 29);
            this.lblAcceptProductName.TabIndex = 16;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(98, 256);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(84, 29);
            this.lblProductName.TabIndex = 15;
            this.lblProductName.Text = "Name:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(223, 142);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(147, 29);
            this.lblProduct.TabIndex = 14;
            this.lblProduct.Text = "Product info:";
            // 
            // btnAcceptRestocks
            // 
            this.btnAcceptRestocks.Location = new System.Drawing.Point(185, 586);
            this.btnAcceptRestocks.Name = "btnAcceptRestocks";
            this.btnAcceptRestocks.Size = new System.Drawing.Size(196, 82);
            this.btnAcceptRestocks.TabIndex = 13;
            this.btnAcceptRestocks.Text = "Accept Restock";
            this.btnAcceptRestocks.UseVisualStyleBackColor = true;
            this.btnAcceptRestocks.Click += new System.EventHandler(this.btnAcceptRestocks_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearchConfirmedRestocks);
            this.groupBox3.Controls.Add(this.lbConfirmedRestocks);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbSearchConfirmedRestocks);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1118, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(542, 1013);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Confirmed Restocks";
            // 
            // btnSearchConfirmedRestocks
            // 
            this.btnSearchConfirmedRestocks.Location = new System.Drawing.Point(407, 35);
            this.btnSearchConfirmedRestocks.Name = "btnSearchConfirmedRestocks";
            this.btnSearchConfirmedRestocks.Size = new System.Drawing.Size(123, 36);
            this.btnSearchConfirmedRestocks.TabIndex = 12;
            this.btnSearchConfirmedRestocks.Text = "Search";
            this.btnSearchConfirmedRestocks.UseVisualStyleBackColor = true;
            this.btnSearchConfirmedRestocks.Click += new System.EventHandler(this.btnSearchConfirmedRestocks_Click);
            // 
            // lbConfirmedRestocks
            // 
            this.lbConfirmedRestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmedRestocks.FormattingEnabled = true;
            this.lbConfirmedRestocks.ItemHeight = 29;
            this.lbConfirmedRestocks.Location = new System.Drawing.Point(10, 97);
            this.lbConfirmedRestocks.Margin = new System.Windows.Forms.Padding(5);
            this.lbConfirmedRestocks.Name = "lbConfirmedRestocks";
            this.lbConfirmedRestocks.Size = new System.Drawing.Size(521, 903);
            this.lbConfirmedRestocks.TabIndex = 1;
            this.lbConfirmedRestocks.SelectedIndexChanged += new System.EventHandler(this.lbConfirmedRestocks_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search:";
            // 
            // tbSearchConfirmedRestocks
            // 
            this.tbSearchConfirmedRestocks.Location = new System.Drawing.Point(113, 36);
            this.tbSearchConfirmedRestocks.Margin = new System.Windows.Forms.Padding(5);
            this.tbSearchConfirmedRestocks.Multiline = true;
            this.tbSearchConfirmedRestocks.Name = "tbSearchConfirmedRestocks";
            this.tbSearchConfirmedRestocks.Size = new System.Drawing.Size(286, 36);
            this.tbSearchConfirmedRestocks.TabIndex = 11;
            // 
            // RestockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "RestockForm";
            this.Text = "Restock";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchRestocks;
        private System.Windows.Forms.ListBox lbRestocks;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearchRestocks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAcceptRestocks;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblAcceptCategory;
        private System.Windows.Forms.Label lblAcceptSellPrice;
        private System.Windows.Forms.Label lblAcceptBuyPrice;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.Label lblAcceptProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblAcceptQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearchConfirmedRestocks;
        private System.Windows.Forms.ListBox lbConfirmedRestocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchConfirmedRestocks;
    }
}