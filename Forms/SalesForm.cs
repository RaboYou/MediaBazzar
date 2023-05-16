using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaBazaar
{
	public partial class SalesForm : Form
	{
		private SQLConProductHandling con = new SQLConProductHandling();
		private SQLConStockRequestsHandling conStockHandling = new SQLConStockRequestsHandling();
		private bool search = false;
		private Person activeUser;
		private Dictionary<string, int> translatorFromNameToId;
		private List<Product> allProducts;
		private List<Product> productsCritical = new List<Product>();

		public SalesForm(Person person)
		{
			InitializeComponent();
			this.activeUser = person;
		}

		private void SalesForm_Load(object sender, EventArgs e)
		{
			LoadProducts();
			LoadRestock();
		}

		private void BtnLogoutClick(object sender, EventArgs e)
		{
			this.Close();
		}

		public void LoadProducts()
		{
			allProducts = con.GetAllProducts();
			translatorFromNameToId = new Dictionary<string, int>();
			lbShelf.Items.Clear();
			foreach (var product in allProducts)
			{
				translatorFromNameToId.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}", product.Id);
				lbShelf.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
			}
		}
		public void LoadRestock()
		{
			lbRestock.Items.Clear();
			foreach (var product in con.GetAllCriticalProducts())
			{
				lbRestock.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
				productsCritical.Add(product);
			}
		}

		public void LoadSearchResults(string input)
		{
			lbShelf.Items.Clear();
			foreach (var product in allProducts)
			{
				if ($"{product.ManufacturerName} {product.ProductName}, {product.Id}".IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					lbShelf.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
				}
			}
		}

		private void LbShelfSelectedIndexChanged(object sender, EventArgs e)
		{
			Product selectedProduct = null;
			foreach (var item in allProducts)
			{
				if (item.Id == translatorFromNameToId[lbShelf.SelectedItem.ToString()])
				{
					selectedProduct = item;
				}
			}
			lblDProductName.Text = selectedProduct.ProductName;
			lblDBuyPrice.Text = "€" + selectedProduct.BuyPrice.ToString();
			lblDSellPrice.Text = "€" + selectedProduct.SellPrice.ToString();
			lblDCategory.Text = selectedProduct.Category.ToString().Replace('_', ' ');
		}

		private void BtnSearchClick(object sender, EventArgs e)
		{
			if (search)
			{
				LoadSearchResults(tbSearch.Text);
			}
			else
			{
				LoadProducts();
			}
		}

		private void TbSearchTextChanged(object sender, EventArgs e)
		{
			search = !tbSearch.Text.Equals("");
		}

		private void LbRestockSelectedIndexChanged(object sender, EventArgs e)
		{
			Product selectedProduct = null;
			foreach (var item in allProducts)
			{
				if (item.Id == translatorFromNameToId[lbRestock.SelectedItem.ToString()])
				{
					selectedProduct = item;
				}
			}
			lblDProductName.Text = selectedProduct.ProductName;
			lblDBuyPrice.Text = "€" + selectedProduct.BuyPrice.ToString();
			lblDSellPrice.Text = "€" + selectedProduct.SellPrice.ToString();
			lblDCategory.Text = selectedProduct.Category.ToString().Replace('_', ' ');
		}

		private void BtnRequestRestockClick(object sender, EventArgs e)
		{
			if (Regex.IsMatch(tbQuantity.Text, "^[0-9]+$"))
			{
				Product selectedProduct = null;
				foreach (var item in allProducts)
				{
					if (item.Id == translatorFromNameToId[lbRestock.SelectedItem.ToString()])
					{
						selectedProduct = item;
					}
				}
				var NewRestock = new Restock(Convert.ToInt32(tbQuantity.Text), activeUser, selectedProduct);

				conStockHandling.CreateRestockRequest(NewRestock);
			}
			else
			{
				MessageBox.Show("The quantity that was entered, is not a whole number!");
			}
		}
	}
}
