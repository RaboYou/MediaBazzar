
namespace MediaBazzar
{
    partial class DepoForm
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
            this.gbAddRemStock = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbStock = new System.Windows.Forms.GroupBox();
            this.lbListStock = new System.Windows.Forms.ListBox();
            this.lblSearchProduct = new System.Windows.Forms.Label();
            this.tbSearchStock = new System.Windows.Forms.TextBox();
            this.tbcDepot = new System.Windows.Forms.TabControl();
            this.tbpStock = new System.Windows.Forms.TabPage();
            this.tbpProducts = new System.Windows.Forms.TabPage();
            this.gbAddRemStock.SuspendLayout();
            this.gbStock.SuspendLayout();
            this.tbcDepot.SuspendLayout();
            this.tbpStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddRemStock
            // 
            this.gbAddRemStock.Controls.Add(this.button4);
            this.gbAddRemStock.Controls.Add(this.button3);
            this.gbAddRemStock.Controls.Add(this.button1);
            this.gbAddRemStock.Location = new System.Drawing.Point(8, 8);
            this.gbAddRemStock.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbAddRemStock.Name = "gbAddRemStock";
            this.gbAddRemStock.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbAddRemStock.Size = new System.Drawing.Size(333, 251);
            this.gbAddRemStock.TabIndex = 3;
            this.gbAddRemStock.TabStop = false;
            this.gbAddRemStock.Text = "Stock mangement";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(75, 162);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(183, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Restock requests";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(75, 117);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Modify";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add/Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gbStock
            // 
            this.gbStock.Controls.Add(this.lbListStock);
            this.gbStock.Controls.Add(this.tbSearchStock);
            this.gbStock.Controls.Add(this.lblSearchProduct);
            this.gbStock.Location = new System.Drawing.Point(1125, 8);
            this.gbStock.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbStock.Name = "gbStock";
            this.gbStock.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbStock.Size = new System.Drawing.Size(739, 968);
            this.gbStock.TabIndex = 8;
            this.gbStock.TabStop = false;
            this.gbStock.Text = "Stock list";
            // 
            // lbListStock
            // 
            this.lbListStock.FormattingEnabled = true;
            this.lbListStock.ItemHeight = 20;
            this.lbListStock.Location = new System.Drawing.Point(10, 89);
            this.lbListStock.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lbListStock.Name = "lbListStock";
            this.lbListStock.Size = new System.Drawing.Size(719, 864);
            this.lbListStock.TabIndex = 1;
            // 
            // lblSearchProduct
            // 
            this.lblSearchProduct.AutoSize = true;
            this.lblSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchProduct.Location = new System.Drawing.Point(10, 33);
            this.lblSearchProduct.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSearchProduct.Name = "lblSearchProduct";
            this.lblSearchProduct.Size = new System.Drawing.Size(119, 22);
            this.lblSearchProduct.TabIndex = 10;
            this.lblSearchProduct.Text = "Search stock:";
            // 
            // tbSearchStock
            // 
            this.tbSearchStock.Location = new System.Drawing.Point(157, 30);
            this.tbSearchStock.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tbSearchStock.Multiline = true;
            this.tbSearchStock.Name = "tbSearchStock";
            this.tbSearchStock.Size = new System.Drawing.Size(572, 36);
            this.tbSearchStock.TabIndex = 11;
            // 
            // tbcDepot
            // 
            this.tbcDepot.Controls.Add(this.tbpStock);
            this.tbcDepot.Controls.Add(this.tbpProducts);
            this.tbcDepot.Location = new System.Drawing.Point(12, 12);
            this.tbcDepot.Name = "tbcDepot";
            this.tbcDepot.SelectedIndex = 0;
            this.tbcDepot.Size = new System.Drawing.Size(1880, 1017);
            this.tbcDepot.TabIndex = 12;
            // 
            // tbpStock
            // 
            this.tbpStock.Controls.Add(this.gbAddRemStock);
            this.tbpStock.Controls.Add(this.gbStock);
            this.tbpStock.Location = new System.Drawing.Point(4, 29);
            this.tbpStock.Name = "tbpStock";
            this.tbpStock.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStock.Size = new System.Drawing.Size(1872, 984);
            this.tbpStock.TabIndex = 0;
            this.tbpStock.Text = "Stock";
            this.tbpStock.UseVisualStyleBackColor = true;
            // 
            // tbpProducts
            // 
            this.tbpProducts.Location = new System.Drawing.Point(4, 29);
            this.tbpProducts.Name = "tbpProducts";
            this.tbpProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProducts.Size = new System.Drawing.Size(1872, 984);
            this.tbpProducts.TabIndex = 1;
            this.tbpProducts.Text = "Products";
            this.tbpProducts.UseVisualStyleBackColor = true;
            // 
            // DepoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tbcDepot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "DepoForm";
            this.Text = "Media Bazaar";
            this.gbAddRemStock.ResumeLayout(false);
            this.gbStock.ResumeLayout(false);
            this.gbStock.PerformLayout();
            this.tbcDepot.ResumeLayout(false);
            this.tbpStock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbAddRemStock;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbStock;
        private System.Windows.Forms.ListBox lbListStock;
        private System.Windows.Forms.Label lblSearchProduct;
        private System.Windows.Forms.TextBox tbSearchStock;
        private System.Windows.Forms.TabControl tbcDepot;
        private System.Windows.Forms.TabPage tbpStock;
        private System.Windows.Forms.TabPage tbpProducts;
    }
}