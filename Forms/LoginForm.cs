using System;
using System.Windows.Forms;

namespace MediaBazaar
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This method handles the initialization of the next form, will pass the person class object to the next form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginButtonClick(object sender, EventArgs e)
		{
			//comments below should be uncommented after adding forms to call
			var user = userTextBox.Text;
			var password = passwordTextBox.Text;

			var sqlcon = new SQLConLogin();
			var person = sqlcon.CheckPassword(user, password);
			if (!(person is null))
			{
				var accessLevel = sqlcon.GetPersonAccessLevel(person.Id);
				this.Hide();
				//Bazaar bazaar = new Bazaar(person);
				//bazaar.ShowDialog();
				//userTextBox.Text = "";
				//passwordTextBox.Text = "";

				switch (accessLevel)
				{
					//place to put forms to initialize
					case 1:
						//MessageBox.Show("Access level: 1", "Access level", MessageBoxButtons.OK, MessageBoxIcon.Error);
						//something like:
						// FormName FormNameForm = new FormName(person);
						var sales = new SalesForm(person);
						sales.ShowDialog();
						break;
					case 2:
						var bazaar = new Bazaar(person);
						bazaar.ShowDialog();
						break;
					case 3:
						var addproduct = new AddProduct(person);
						addproduct.ShowDialog();

						//MessageBox.Show("Access level: 3", "Access level", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					case 4:
						var manager = new ManagerForm();
						manager.ShowDialog();
						//MessageBox.Show("Access level: 4", "Access level", MessageBoxButtons.OK, MessageBoxIcon.Error);

						break;
					default:
						MessageBox.Show($"Something went wrong with the access level, it's: {accessLevel}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
				}
				this.Show();
			}
			else
			{
				MessageBox.Show("Incorrect credentials");
				//passwordTextBox.Text = "";
			}
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
