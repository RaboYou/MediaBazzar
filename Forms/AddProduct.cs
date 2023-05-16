using MediaBazzar.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaBazaar
{
	public partial class AddProduct : Form
	{
		private readonly SQLConProductHandling conProduct = new SQLConProductHandling();
		private SQLConManufacturersHandling conManufacturers = new SQLConManufacturersHandling();

		public AddProduct(Person person)
		{
			InitializeComponent();
		}

		private List<Product> _products = new List<Product>();
		private List<Manufacturer> _manufacturers = new List<Manufacturer>();
		private Dictionary<string, int> _manufacturersNameToId = new Dictionary<string, int>();
		private Dictionary<string, int> productsNamesToId = new Dictionary<string, int>();
		private int hiddenId;

		private void AddProduct_Load(object sender, EventArgs e)
		{
			Init();
			LoadProducts();
			DisableAll();
		}

		private void Init()
		{
			_manufacturers = conManufacturers.GetAllManufacturers();
			foreach (var item in _manufacturers)
			{
				_manufacturersNameToId.Add($"{item.ManName}, {item.ManId}", item.ManId);
				manufacturerComboBox.Items.Add($"{item.ManName}, {item.ManId}");
			}

			foreach (var category in Enum.GetNames(typeof(Category)))
			{
				cBProductCategory.Items.Add(category);
			}

			foreach (var status in Enum.GetNames(typeof(ProductStatus)))
			{
				cBProductStatus.Items.Add(status);
			}

			manufacturerComboBox.SelectedIndex = 0;
			cBProductCategory.SelectedIndex = 0;
			cBProductStatus.SelectedIndex = 3;
			}

		private void LoadProducts()
		{
			productsNamesToId.Clear();
			lbProducts.Items.Clear();
			_products = conProduct.GetAllProducts();
			foreach (var product in _products)
			{
				productsNamesToId.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}", product.Id);
				lbProducts.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
			}
		}

		private void LbProductsSelectedIndexChanged(object sender, EventArgs e)
		{
			if(btnCreateProduct.Text == "Save" || btnEditProduct.Text == "Save")
			{
				DisableAll();
				btnCreateProduct.Text = "Create";
				btnEditProduct.Text = "Edit";
			}
			else if (lbProducts.SelectedItem.Equals(null)) { }
			else
			{
				Product selectedProduct = null;
				foreach (var item in _products)
				{
					if (item.Id == productsNamesToId[lbProducts.SelectedItem.ToString()])
					{
						selectedProduct = item;
					}
				}
				hiddenId = selectedProduct.Id;
				tBProductName.Text = selectedProduct.ProductName;
				tBBuyPrice.Text = selectedProduct.BuyPrice.ToString();
				tBSellPrice.Text = selectedProduct.SellPrice.ToString();
				tBproductDescription.Text = selectedProduct.Description;
				cBProductCategory.Text = selectedProduct.Category.ToString();
				cBProductStatus.Text = selectedProduct.ProductStatus.ToString();
				manufacturerComboBox.SelectedItem = $"{selectedProduct.ManufacturerName}, {selectedProduct.ManufacturerId}";
				tbProductWidth.Text = selectedProduct.Width.ToString();
				tbProductHeight.Text = selectedProduct.Height.ToString();
				tbProductDepth.Text = selectedProduct.Depth.ToString();
				tbProductWeight.Text = selectedProduct.Weight.ToString();
			}
		}

		private void BtnSearchProductClick(object sender, EventArgs e)
		{
			lbProducts.Items.Clear();

			foreach (var product in _products)
			{
				if ($"{product.ManufacturerName} {product.ProductName}, {product.Id}".IndexOf(tBSearchProduct.Text, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					lbProducts.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
				}
			}
		}

		private void BtnCreateProductClick(object sender, EventArgs e)
		{
			bool valid = true;
			string errorstatus = "";
			if(btnCreateProduct.Text == "Create")
            {
				EnableAll();
				ClearAll();
				btnCreateProduct.Text = "Save";
            }
			else if (btnCreateProduct.Text == "Save")
            {
				if (tBProductName.Text.Equals("") || tBBuyPrice.Text.Equals("") || tBSellPrice.Text.Equals("") || tBproductDescription.Text.Equals("") || tbProductWidth.Text.Equals("") || tbProductHeight.Text.Equals("") || tbProductDepth.Text.Equals("") || tbProductWeight.Text.Equals(""))
				{
					errorstatus += "- One or more of the fields are empty.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tBProductName.Text, "^[a-zA-Z]+$"))
				{
					errorstatus += "- Please check whether you entered a valid Product name.\n\n";
					valid = false;
				}
				if (!double.TryParse(tBBuyPrice.Text, out _) || (!double.TryParse(tBSellPrice.Text, out _)))
				{
					errorstatus += "- Please check whether you entered a correct Buy or Sell price.\n\n";
					valid = false;
				}
				if (!float.TryParse(tbProductWidth.Text, out _) || !float.TryParse(tbProductHeight.Text, out _) || !float.TryParse(tbProductDepth.Text, out _) || !float.TryParse(tbProductWeight.Text, out _))
				{
					errorstatus += "- Please check whether you entered valid dimenions.\n\n";
					valid = false;
				}

				if (valid)
				{
					Enum.TryParse(cBProductCategory.SelectedItem.ToString(), out Category category);
					Enum.TryParse(cBProductStatus.SelectedItem.ToString(), out ProductStatus status);
					var manufacturerId = _manufacturersNameToId[manufacturerComboBox.SelectedItem.ToString()];
					var manufacturerName = manufacturerComboBox.SelectedItem.ToString().Split(',');
					var productName = tBProductName.Text;
					var buyPrice = Convert.ToDouble(tBBuyPrice.Text);
					var sellPrice = Convert.ToDouble(tBSellPrice.Text);
					var description = tBproductDescription.Text;
					var width = float.Parse(tbProductWidth.Text);
					var height = float.Parse(tbProductHeight.Text);
					var depth = float.Parse(tbProductDepth.Text);
					var weight = float.Parse(tbProductWeight.Text);
					if (!conProduct.CheckProduct(ProductName))
					{
						var newProduct = new Product(manufacturerId, manufacturerName[0], productName, buyPrice, sellPrice, description, category, status, width, height, depth, weight);
						conProduct.CreateProduct(newProduct);
						LoadProducts();
					}
				}
				DisableAll();
				btnCreateProduct.Text = "Create";
			}
			else
			{
				MessageBox.Show(errorstatus, "There are one or more issues with the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnAddManufacturerClick(object sender, EventArgs e)
		{
			var addManufacturer = new AddManufacturer();
			addManufacturer.ShowDialog();
		}

		private void EditProductButtonClick(object sender, EventArgs e)
		{
			bool valid = true;
			string errorstatus = "";
			if (btnEditProduct.Text == "Edit")
			{
				EnableAll();
				btnEditProduct.Text = "Save";
			}
			else if (btnEditProduct.Text == "Save")
			{
				if (tBProductName.Text.Equals("") || tBBuyPrice.Text.Equals("") || tBSellPrice.Text.Equals("") || tBproductDescription.Text.Equals("") || tbProductWidth.Text.Equals("") || tbProductHeight.Text.Equals("") || tbProductDepth.Text.Equals("") || tbProductWeight.Text.Equals(""))
				{
					errorstatus += "- One or more of the fields are empty.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tBProductName.Text, "^[a-zA-Z]+$"))
				{
					errorstatus += "- Please check whether you entered a valid Product name.\n\n";
					valid = false;
				}
				if (!double.TryParse(tBBuyPrice.Text, out _) || (!double.TryParse(tBSellPrice.Text, out _)))
				{
					errorstatus += "- Please check whether you entered a correct Buy or Sell price.\n\n";
					valid = false;
				}
				if (!float.TryParse(tbProductWidth.Text, out _) || !float.TryParse(tbProductHeight.Text, out _) || !float.TryParse(tbProductDepth.Text, out _) || !float.TryParse(tbProductWeight.Text, out _))
				{
					errorstatus += "- Please check whether you entered valid dimenions.\n\n";
					valid = false;
				}
				if (valid)
				{
					Enum.TryParse(cBProductCategory.SelectedItem.ToString(), out Category category);
					Enum.TryParse(cBProductStatus.SelectedItem.ToString(), out ProductStatus status);
					var manufacturerId = _manufacturersNameToId[manufacturerComboBox.SelectedItem.ToString()];
					var manufacturerName = manufacturerComboBox.SelectedItem.ToString().Split(',');
					var productName = tBProductName.Text;
					var buyPrice = Convert.ToDouble(tBBuyPrice.Text);
					var sellPrice = Convert.ToDouble(tBSellPrice.Text);
					var description = tBproductDescription.Text;
					var width = float.Parse(tbProductWidth.Text);
					var height = float.Parse(tbProductHeight.Text);
					var depth = float.Parse(tbProductDepth.Text);
					var weight = float.Parse(tbProductWeight.Text);
					foreach (var item in _products)
					{
						if (item.Id == hiddenId)
						{
							item.ManufacturerId = manufacturerId;
							item.ManufacturerName = manufacturerName[0];
							item.ProductName = productName;
							item.BuyPrice = buyPrice;
							item.SellPrice = sellPrice;
							item.Description = description;
							item.Category = category;
							item.ProductStatus = status;
							item.Width = width;
							item.Height = height;
							item.Depth = depth;
							item.Weight = weight;
							conProduct.UpdateProduct(item);
						}
					}
				}
				LoadProducts();
				DisableAll();
				btnEditProduct.Text = "Edit";
			}
			else
			{
				MessageBox.Show(errorstatus, "There are one or more issues with the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnViewRestocks_Click(object sender, EventArgs e)
        {
			var restocks = new RestockForm();
			restocks.ShowDialog();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			if(btnCreateProduct.Text.Equals("Create") && btnEditProduct.Text.Equals("Edit"))
            {

            }
			else
            {
				ClearAll();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DisableAll();
			btnCreateProduct.Text = "Create";
			btnEditProduct.Text = "Edit";
		}
		public void DisableAll()
        {
			tBProductName.Enabled = false;
			tBBuyPrice.Enabled = false;
			tBSellPrice.Enabled = false;
			tBproductDescription.Enabled = false;
			cBProductCategory.Enabled = false;
			cBProductStatus.Enabled = false;
			manufacturerComboBox.Enabled = false;
			tbProductWidth.Enabled = false;
			tbProductHeight.Enabled = false;
			tbProductDepth.Enabled = false;
			tbProductWeight.Enabled = false;
		}

		public void EnableAll()
        {
			tBProductName.Enabled = true;
			tBBuyPrice.Enabled = true;
			tBSellPrice.Enabled = true;
			tBproductDescription.Enabled = true;
			cBProductCategory.Enabled = true;
			cBProductStatus.Enabled = true;
			manufacturerComboBox.Enabled = true;
			tbProductWidth.Enabled = true;
			tbProductHeight.Enabled = true;
			tbProductDepth.Enabled = true;
			tbProductWeight.Enabled = true;
		}

		public void ClearAll()
        {
			tBProductName.Clear();
			tBBuyPrice.Clear();
			tBSellPrice.Clear();
			tBproductDescription.Clear();
			cBProductCategory.SelectedIndex = 0;
			cBProductStatus.SelectedIndex = 3;
			manufacturerComboBox.SelectedIndex = 0;
			tbProductWidth.Clear();
			tbProductHeight.Clear();
			tbProductDepth.Clear();
			tbProductWeight.Clear();
		}
    }
}
