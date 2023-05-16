
namespace MediaBazzar.Forms
{
    partial class WorkshiftDetails
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
            this.lbEmployeesAssigned = new System.Windows.Forms.ListBox();
            this.lblEmployeesAssigned = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblMaxAmount = new System.Windows.Forms.Label();
            this.nudMaxAmount = new System.Windows.Forms.NumericUpDown();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lbEmployeesAssigned
            // 
            this.lbEmployeesAssigned.FormattingEnabled = true;
            this.lbEmployeesAssigned.ItemHeight = 20;
            this.lbEmployeesAssigned.Location = new System.Drawing.Point(14, 48);
            this.lbEmployeesAssigned.Margin = new System.Windows.Forms.Padding(5);
            this.lbEmployeesAssigned.Name = "lbEmployeesAssigned";
            this.lbEmployeesAssigned.Size = new System.Drawing.Size(232, 424);
            this.lbEmployeesAssigned.TabIndex = 0;
            this.lbEmployeesAssigned.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployeesAssigned_KeyDown);
            // 
            // lblEmployeesAssigned
            // 
            this.lblEmployeesAssigned.AutoSize = true;
            this.lblEmployeesAssigned.Location = new System.Drawing.Point(14, 13);
            this.lblEmployeesAssigned.Name = "lblEmployeesAssigned";
            this.lblEmployeesAssigned.Size = new System.Drawing.Size(180, 22);
            this.lblEmployeesAssigned.TabIndex = 1;
            this.lblEmployeesAssigned.Text = "Assigned employees:";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.cbType);
            this.gbInfo.Controls.Add(this.lblType);
            this.gbInfo.Controls.Add(this.lblDate);
            this.gbInfo.Controls.Add(this.dtpDate);
            this.gbInfo.Controls.Add(this.lblMaxAmount);
            this.gbInfo.Controls.Add(this.nudMaxAmount);
            this.gbInfo.Location = new System.Drawing.Point(293, 38);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(277, 434);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Details";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(94, 159);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(150, 28);
            this.cbType.TabIndex = 5;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(27, 159);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(56, 22);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(23, 102);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 22);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDate.Location = new System.Drawing.Point(94, 102);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 27);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Value = new System.DateTime(2021, 6, 17, 14, 17, 14, 0);
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblMaxAmount
            // 
            this.lblMaxAmount.AutoSize = true;
            this.lblMaxAmount.Location = new System.Drawing.Point(23, 52);
            this.lblMaxAmount.Name = "lblMaxAmount";
            this.lblMaxAmount.Size = new System.Drawing.Size(154, 22);
            this.lblMaxAmount.TabIndex = 1;
            this.lblMaxAmount.Text = "Maximum amount:";
            // 
            // nudMaxAmount
            // 
            this.nudMaxAmount.Location = new System.Drawing.Point(183, 52);
            this.nudMaxAmount.Name = "nudMaxAmount";
            this.nudMaxAmount.Size = new System.Drawing.Size(42, 27);
            this.nudMaxAmount.TabIndex = 0;
            this.nudMaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMaxAmount.ValueChanged += new System.EventHandler(this.nudMaxAmount_ValueChanged);
            // 
            // WorkshiftDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 486);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.lblEmployeesAssigned);
            this.Controls.Add(this.lbEmployeesAssigned);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "WorkshiftDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workshift Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkshiftDetails_FormClosing);
            this.Load += new System.EventHandler(this.WorkshiftDetails_Load);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbEmployeesAssigned;
        private System.Windows.Forms.Label lblEmployeesAssigned;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblMaxAmount;
        private System.Windows.Forms.NumericUpDown nudMaxAmount;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
    }
}