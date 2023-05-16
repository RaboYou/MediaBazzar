using MediaBazaar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazzar.Forms
{
    public partial class WorkshiftDetails : Form
    {
        private Workshift workshift;

        public WorkshiftDetails(Workshift workshift)
        {
            InitializeComponent();
            this.workshift = workshift;
        }

        private void WorkshiftDetails_Load(object sender, EventArgs e)
        {
            LoadFormData();
            LoadEmployees();
        }

        private void lbEmployeesAssigned_KeyDown(object sender, KeyEventArgs e)
        {
            string[] employeeName = { };
            if (lbEmployeesAssigned.SelectedIndex >= 0)
            {
                employeeName = lbEmployeesAssigned.SelectedItem.ToString().Split(' ');
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.D)
            {
                foreach(ShiftPerson person in this.workshift.Persons)
                {
                    if (person.FirstName == employeeName[0] && person.LastName == employeeName[1])
                    {
                        this.workshift.Persons.Remove(person);
                        LoadEmployees();
                        return;
                    }
                }
            }
        }

        private void LoadEmployees()
        {
            lbEmployeesAssigned.Items.Clear();
            foreach (ShiftPerson person in this.workshift.Persons)
            {
                lbEmployeesAssigned.Items.Add(person.FirstName + " " + person.LastName);
            }
        }

        private void LoadFormData()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd-MM-yyyy";

            this.Text += $" - {this.workshift.Date.DayOfWeek} {this.workshift.Date.ToShortDateString()}";
            nudMaxAmount.Value = this.workshift.MaxAmount;
            dtpDate.Value = this.workshift.Date;

            foreach(ShiftType type in (ShiftType[])Enum.GetValues(typeof(ShiftType)))
            {
                cbType.Items.Add(type.ToString());
            }
            cbType.SelectedItem = this.workshift.Type.ToString();
        }   

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            this.workshift.Date = dtpDate.Value;
        }

        private void nudMaxAmount_ValueChanged(object sender, EventArgs e)
        {
            this.workshift.MaxAmount = Convert.ToInt32(nudMaxAmount.Value);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex >= 0)
            {
                this.workshift.Type = (ShiftType)Enum.Parse(typeof(ShiftType), cbType.SelectedItem.ToString());
            }
        }

        private void WorkshiftDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.workshift.Persons.Count > this.workshift.MaxAmount)
            {
                MessageBox.Show("The amount of persons is larger than\nthe maximum amount of this workshift.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
