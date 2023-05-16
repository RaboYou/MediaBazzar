
namespace MediaBazaar
{
    partial class AddManufacturer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBManCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbManAdress = new System.Windows.Forms.TextBox();
            this.btnCreateManufacturer = new System.Windows.Forms.Button();
            this.tbManName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchManufacturer = new System.Windows.Forms.Button();
            this.lbManufacturer = new System.Windows.Forms.ListBox();
            this.btnEditManufacturer = new System.Windows.Forms.Button();
            this.tBSearchManufacturer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelManufacturer = new System.Windows.Forms.Button();
            this.btnClearManufacturer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearManufacturer);
            this.groupBox1.Controls.Add(this.btnCancelManufacturer);
            this.groupBox1.Controls.Add(this.cBManCountry);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEditManufacturer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbManAdress);
            this.groupBox1.Controls.Add(this.btnCreateManufacturer);
            this.groupBox1.Controls.Add(this.tbManName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.groupBox1.Location = new System.Drawing.Point(9, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(524, 493);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add manufacturer";
            // 
            // cBManCountry
            // 
            this.cBManCountry.FormattingEnabled = true;
            this.cBManCountry.Location = new System.Drawing.Point(234, 126);
            this.cBManCountry.Margin = new System.Windows.Forms.Padding(2);
            this.cBManCountry.Name = "cBManCountry";
            this.cBManCountry.Size = new System.Drawing.Size(240, 37);
            this.cBManCountry.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Country:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adress:";
            // 
            // tbManAdress
            // 
            this.tbManAdress.Location = new System.Drawing.Point(234, 87);
            this.tbManAdress.Margin = new System.Windows.Forms.Padding(2);
            this.tbManAdress.Name = "tbManAdress";
            this.tbManAdress.Size = new System.Drawing.Size(240, 35);
            this.tbManAdress.TabIndex = 3;
            // 
            // btnCreateManufacturer
            // 
            this.btnCreateManufacturer.Location = new System.Drawing.Point(78, 213);
            this.btnCreateManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateManufacturer.Name = "btnCreateManufacturer";
            this.btnCreateManufacturer.Size = new System.Drawing.Size(137, 54);
            this.btnCreateManufacturer.TabIndex = 2;
            this.btnCreateManufacturer.Text = "Create";
            this.btnCreateManufacturer.UseVisualStyleBackColor = true;
            this.btnCreateManufacturer.Click += new System.EventHandler(this.btnCreateManufacturer_Click);
            // 
            // tbManName
            // 
            this.tbManName.Location = new System.Drawing.Point(234, 51);
            this.tbManName.Margin = new System.Windows.Forms.Padding(2);
            this.tbManName.Name = "tbManName";
            this.tbManName.Size = new System.Drawing.Size(240, 35);
            this.tbManName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manufacturer name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchManufacturer);
            this.groupBox2.Controls.Add(this.lbManufacturer);
            this.groupBox2.Controls.Add(this.tBSearchManufacturer);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.groupBox2.Location = new System.Drawing.Point(549, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(900, 676);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit manufacturer";
            // 
            // btnSearchManufacturer
            // 
            this.btnSearchManufacturer.Location = new System.Drawing.Point(272, 90);
            this.btnSearchManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchManufacturer.Name = "btnSearchManufacturer";
            this.btnSearchManufacturer.Size = new System.Drawing.Size(99, 37);
            this.btnSearchManufacturer.TabIndex = 37;
            this.btnSearchManufacturer.Text = "Search";
            this.btnSearchManufacturer.UseVisualStyleBackColor = true;
            this.btnSearchManufacturer.Click += new System.EventHandler(this.BtnSearchManufacturerClick);
            // 
            // lbManufacturer
            // 
            this.lbManufacturer.FormattingEnabled = true;
            this.lbManufacturer.ItemHeight = 29;
            this.lbManufacturer.Location = new System.Drawing.Point(34, 139);
            this.lbManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.lbManufacturer.Name = "lbManufacturer";
            this.lbManufacturer.Size = new System.Drawing.Size(338, 497);
            this.lbManufacturer.TabIndex = 35;
            this.lbManufacturer.SelectedIndexChanged += new System.EventHandler(this.lbManufacturer_SelectedIndexChanged);
            // 
            // btnEditManufacturer
            // 
            this.btnEditManufacturer.Location = new System.Drawing.Point(278, 213);
            this.btnEditManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditManufacturer.Name = "btnEditManufacturer";
            this.btnEditManufacturer.Size = new System.Drawing.Size(137, 54);
            this.btnEditManufacturer.TabIndex = 26;
            this.btnEditManufacturer.Text = "Edit";
            this.btnEditManufacturer.UseVisualStyleBackColor = true;
            this.btnEditManufacturer.Click += new System.EventHandler(this.btnEditManufacturer_Click);
            // 
            // tBSearchManufacturer
            // 
            this.tBSearchManufacturer.Location = new System.Drawing.Point(235, 50);
            this.tBSearchManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.tBSearchManufacturer.Name = "tBSearchManufacturer";
            this.tBSearchManufacturer.Size = new System.Drawing.Size(137, 35);
            this.tBSearchManufacturer.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label11.Location = new System.Drawing.Point(4, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 26);
            this.label11.TabIndex = 22;
            this.label11.Text = "Search manufacturer:";
            // 
            // btnCancelManufacturer
            // 
            this.btnCancelManufacturer.Location = new System.Drawing.Point(176, 360);
            this.btnCancelManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelManufacturer.Name = "btnCancelManufacturer";
            this.btnCancelManufacturer.Size = new System.Drawing.Size(137, 54);
            this.btnCancelManufacturer.TabIndex = 27;
            this.btnCancelManufacturer.Text = "Cancel";
            this.btnCancelManufacturer.UseVisualStyleBackColor = true;
            this.btnCancelManufacturer.Click += new System.EventHandler(this.btnCancelManufacturer_Click);
            // 
            // btnClearManufacturer
            // 
            this.btnClearManufacturer.Location = new System.Drawing.Point(176, 289);
            this.btnClearManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearManufacturer.Name = "btnClearManufacturer";
            this.btnClearManufacturer.Size = new System.Drawing.Size(137, 54);
            this.btnClearManufacturer.TabIndex = 28;
            this.btnClearManufacturer.Text = "Clear";
            this.btnClearManufacturer.UseVisualStyleBackColor = true;
            this.btnClearManufacturer.Click += new System.EventHandler(this.btnClearManufacturer_Click);
            // 
            // AddManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 742);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddManufacturer";
            this.Text = "AddManufacturer";
            this.Load += new System.EventHandler(this.AddManufacturer_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBManCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbManAdress;
        private System.Windows.Forms.Button btnCreateManufacturer;
        private System.Windows.Forms.TextBox tbManName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchManufacturer;
        private System.Windows.Forms.ListBox lbManufacturer;
        private System.Windows.Forms.Button btnEditManufacturer;
        private System.Windows.Forms.TextBox tBSearchManufacturer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClearManufacturer;
        private System.Windows.Forms.Button btnCancelManufacturer;
    }
}