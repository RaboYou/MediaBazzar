using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaBazaar
{
	public partial class AddManufacturer : Form
	{
		private SQLConManufacturersHandling conManufacturers = new SQLConManufacturersHandling();

		public AddManufacturer()
		{
			InitializeComponent();
		}
		private List<Manufacturer> _manufacturers = new List<Manufacturer>();
		private Dictionary<string, int> _manufacturersNameToId = new Dictionary<string, int>();
		private int hiddenId;

		private void AddManufacturer_Load_1(object sender, EventArgs e)
		{
			LoadManufacturers();
			Init();
			DisableAll();
		}

		private void Init()
		{
			foreach (var manCountry in Enum.GetNames(typeof(ManCountry)))
			{
				cBManCountry.Items.Add(manCountry);
			}

			foreach (var manufacturer in conManufacturers.GetAllManufacturers())
			{
				lbManufacturer.Items.Add(manufacturer.ManName);
			}
			cBManCountry.SelectedIndex = 0;
		}
		private void BtnSearchManufacturerClick(object sender, EventArgs e)
		{
			_manufacturersNameToId.Clear();
			lbManufacturer.Items.Clear();
			if (conManufacturers.SearchManufacturers(tBSearchManufacturer.Text) != null)
			{
				foreach (var manufacturer in conManufacturers.SearchManufacturers(tBSearchManufacturer.Text))
				{
					_manufacturersNameToId.Add($"{manufacturer.ManName}, {manufacturer.ManId}", manufacturer.ManId);
					lbManufacturer.Items.Add($"{manufacturer.ManName}, {manufacturer.ManId}");
				}
			}
			else
			{
				lbManufacturer.Items.Add("No products found with that name");
			}
		}

		private void LoadManufacturers()
		{
			_manufacturersNameToId.Clear();
			lbManufacturer.Items.Clear();
			_manufacturers = conManufacturers.GetAllManufacturers();
			foreach (var manufacturers in _manufacturers)
			{
				_manufacturersNameToId.Add($"{manufacturers.ManName}, {manufacturers.ManId}", manufacturers.ManId);
				lbManufacturer.Items.Add($"{manufacturers.ManName}, {manufacturers.ManId}");
			}
		}

		private void lbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(btnCreateManufacturer.Text == "Save" || btnEditManufacturer.Text == "Save")
            {
				DisableAll();
				btnCreateManufacturer.Text = "Create";
				btnEditManufacturer.Text = "Edit";
            }
			else if (lbManufacturer.SelectedItem.Equals(null)) { }
			else
			{
				if (!lbManufacturer.SelectedItem.Equals("No products found with that name"))
				{
					Manufacturer selectedmanufacturer = null;
					foreach (var item in _manufacturers)
					{
						if (item.ManId == _manufacturersNameToId[lbManufacturer.SelectedItem.ToString()])
						{
							selectedmanufacturer = item;
						}
					}
					hiddenId = selectedmanufacturer.ManId;
					tbManName.Text = selectedmanufacturer.ManName;
					tbManAdress.Text = selectedmanufacturer.ManAdress;
					cBManCountry.Text = selectedmanufacturer.ManCountry.ToString();
				}
			}
		}

		private void btnCreateManufacturer_Click(object sender, EventArgs e)
		{
			var valid = true;
			var errorstatus = "";
			if(btnCreateManufacturer.Text == "Create")
            {
				EnableAll();
				ClearAll();
				btnCreateManufacturer.Text = "Save";
            }
			else if (btnCreateManufacturer.Text == "Save")
            {
				if (tbManName.Text.Equals("") || tbManAdress.Text.Equals(""))
				{
					errorstatus += "- One or more of the fields are empty.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbManName.Text, "^[a-zA-Z]+$"))
				{
					errorstatus += "- Please check whether you entered a valid Manufacturer name.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbManAdress.Text, "^[0-9]+ [a-zA-Z]+ [a-zA-Z]+$"))
				{
					errorstatus += "- Please check whether you entered a valid Manufacturer address.\n\n";
					valid = false;
				}
				if (valid)
				{
					Enum.TryParse(cBManCountry.SelectedItem.ToString(), out ManCountry manCountry);
					var manName = tbManName.Text;
					var manAddress = tbManAdress.Text;

					if (!conManufacturers.CheckManufacturer(manName))
					{
						var newManufacturer = new Manufacturer(manName, manAddress, manCountry);
						conManufacturers.CreateManufacturer(newManufacturer);
						LoadManufacturers();
					}
				}
				DisableAll();
				btnCreateManufacturer.Text = "Create";
			}
			else
			{
				MessageBox.Show(errorstatus, "There are one or more issues with the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEditManufacturer_Click(object sender, EventArgs e)
		{
			var valid = true;
			var errorstatus = "";
			if (btnEditManufacturer.Text == "Edit")
            {
				EnableAll();
				btnEditManufacturer.Text = "Save";
            }
			else if (btnEditManufacturer.Text == "Save")
            {
				if (tbManName.Text.Equals("") || tbManAdress.Text.Equals(""))
				{
					errorstatus += "- One or more of the fields are empty.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbManName.Text, "^[a-zA-Z]+$"))
				{
					errorstatus += "- Please check whether you entered a valid Manufacturer name.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbManAdress.Text, "^[0-9]+ [a-zA-Z]+ [a-zA-Z]+$"))
				{
					errorstatus += "- Please check whether you entered a valid Manufacturer address.\n\n";
					valid = false;
				}
				if (valid)
				{
					Enum.TryParse(cBManCountry.SelectedItem.ToString(), out ManCountry manCountry);
					var manName = tbManName.Text;
					var manAddress = tbManAdress.Text;
					foreach (var item in _manufacturers)
					{
						if (item.ManId == hiddenId)
						{
							item.ManName = manName;
							item.ManAdress = manAddress;
							item.ManCountry = manCountry;
							conManufacturers.UpdateManufacturer(item);
						}
					}
					LoadManufacturers();
				}
				DisableAll();
				btnEditManufacturer.Text = "Save";
			}
			else
			{
				MessageBox.Show(errorstatus, "There are one or more issues with the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void DisableAll()
		{
			tbManAdress.Enabled = false;
			tbManName.Enabled = false;
			cBManCountry.Enabled = false;
		}

		public void EnableAll()
		{
			tbManAdress.Enabled = true;
			tbManName.Enabled = true;
			cBManCountry.Enabled = true;
		}

		public void ClearAll()
		{
			tbManAdress.Clear();
			tbManName.Clear();
			cBManCountry.SelectedIndex = 0;
		}

        private void btnClearManufacturer_Click(object sender, EventArgs e)
        {
			if (btnCreateManufacturer.Text.Equals("Create") && btnEditManufacturer.Text.Equals("Edit"))
            {

            }
			else
            {
				ClearAll();
            }
        }

        private void btnCancelManufacturer_Click(object sender, EventArgs e)
        {
			DisableAll();
			btnCreateManufacturer.Text = "Create";
			btnEditManufacturer.Text = "Edit";
        }
    }
}
