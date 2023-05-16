
namespace MediaBazaar
{
    partial class FireForm
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
            this.btnCancelFire = new System.Windows.Forms.Button();
            this.btnConfirmFire = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelFire
            // 
            this.btnCancelFire.BackColor = System.Drawing.Color.Tomato;
            this.btnCancelFire.Location = new System.Drawing.Point(-7, 325);
            this.btnCancelFire.Name = "btnCancelFire";
            this.btnCancelFire.Size = new System.Drawing.Size(232, 77);
            this.btnCancelFire.TabIndex = 0;
            this.btnCancelFire.Text = "Cancel";
            this.btnCancelFire.UseVisualStyleBackColor = false;
            this.btnCancelFire.Click += new System.EventHandler(this.BtnCancelFireClick);
            // 
            // btnConfirmFire
            // 
            this.btnConfirmFire.BackColor = System.Drawing.Color.LawnGreen;
            this.btnConfirmFire.Location = new System.Drawing.Point(221, 325);
            this.btnConfirmFire.Name = "btnConfirmFire";
            this.btnConfirmFire.Size = new System.Drawing.Size(220, 77);
            this.btnConfirmFire.TabIndex = 1;
            this.btnConfirmFire.Text = "Confirm";
            this.btnConfirmFire.UseVisualStyleBackColor = false;
            this.btnConfirmFire.Click += new System.EventHandler(this.BtnConfirmFireClick);
            // 
            // tbDescription
            // 
            this.tbDescription.AcceptsReturn = true;
            this.tbDescription.Location = new System.Drawing.Point(63, 118);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(321, 186);
            this.tbDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(165, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(105, 22);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // tbReason
            // 
            this.tbReason.Location = new System.Drawing.Point(63, 53);
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(321, 27);
            this.tbReason.TabIndex = 4;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(149, 22);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(130, 22);
            this.lblReason.TabIndex = 5;
            this.lblReason.Text = "Supply reason:";
            // 
            // FireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 395);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.btnConfirmFire);
            this.Controls.Add(this.btnCancelFire);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FireForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Reason";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelFire;
        private System.Windows.Forms.Button btnConfirmFire;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Label lblReason;
    }
}