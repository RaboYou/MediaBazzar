using System;
using System.Windows.Forms;

namespace MediaBazaar
{
	public partial class FireForm : Form
	{
		private SQLConPersonHandling con = new SQLConPersonHandling();
		private Person person;

		public FireForm(Person person)
		{
			InitializeComponent();
			this.person = person;
		}

		private void BtnCancelFireClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BtnConfirmFireClick(object sender, EventArgs e)
		{
			if (tbDescription.Text.Equals("") || tbDescription.Text.Equals(""))
			{
				MessageBox.Show("You did not fill in all the fields.");
			}
			else
			{
				con.TerminatePerson(person, tbDescription.Text, tbDescription.Text);
				person.IsActive = false;
				MessageBox.Show("Employee " + person.FirstName + " " + person.LastName + " has been set to inactive:\nReason: " + tbReason.Text + "\nDescription: " + tbDescription.Text);
				this.Close();
			}
		}
	}
}
