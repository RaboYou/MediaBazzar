using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConProductHandling : SQLCon
	{
		#region ProductHandling

		public void CreateProduct(Product product)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(
					"INSERT INTO Products (manufacturer_id, product_name, buy_price, sell_price, description, category, product_status, width, height, depth, weight) VALUES (@manufacturerId, @productName, @buyPrice, @sellPrice, @description,  @category, @productStatus, @width, @height, @depth, @weight);");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("manufacturerId", product.ManufacturerId);
				command.Parameters.AddWithValue("productName", product.ProductName);
				command.Parameters.AddWithValue("buyPrice", product.BuyPrice);
				command.Parameters.AddWithValue("sellPrice", product.SellPrice);
				command.Parameters.AddWithValue("description", product.Description);
				command.Parameters.AddWithValue("category", product.Category.ToString());
				command.Parameters.AddWithValue("productStatus", product.ProductStatus.ToString());
				command.Parameters.AddWithValue("width", product.Width);
				command.Parameters.AddWithValue("height", product.Height);
				command.Parameters.AddWithValue("depth", product.Depth);
				command.Parameters.AddWithValue("weight", product.Weight);
				command.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				CloseConnection();
			}
		}

		public bool CheckProduct(string productName)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT product_name FROM products where products.product_name = '{productName}';");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count == 0)
				{
					return false;
				}
				else
				{
					throw new Exception($"Product already exists: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true; //null;
			}
		}

		public List<Product> GetAllProducts()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select products.id, manufacturers.man_name, products.manufacturer_id, products.product_name, products.buy_price, products.sell_price, products.description, products.category, products.product_status, products.width, products.height, products.depth, products.weight from products join manufacturers on products.manufacturer_id = manufacturers.id ORDER BY products.id;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var products = new List<Product>();

					foreach (DataRow dr in dt.Rows)
					{
						//DataRow dr = dt.Rows[0];
						var id = Convert.ToInt32(dr["id"].ToString());
						var manufacturerId = Convert.ToInt32(dr["manufacturer_id"].ToString());
						var manufacturerName = dr["man_name"].ToString();
						var productName = dr["product_name"].ToString();
						var buyPrice = Convert.ToDouble(dr["buy_price"].ToString());
						var sellPrice = Convert.ToDouble(dr["sell_price"].ToString());
						var description = dr["description"].ToString();
						var category = (Category)Enum.Parse(typeof(Category), dr["category"].ToString().Replace(' ', '_'));
						var productStatus = (ProductStatus)Enum.Parse(typeof(ProductStatus), dr["product_status"].ToString().Replace(' ', '_'));
						var width = float.Parse(dr["width"].ToString());
						var height = float.Parse(dr["height"].ToString());
						var depth = float.Parse(dr["depth"].ToString());
						var weight = float.Parse(dr["weight"].ToString());
						var product = new Product(id, manufacturerId, manufacturerName, productName, buyPrice, sellPrice, description, category, productStatus, width, height, depth, weight);
						products.Add(product);
					}
					return products;
				}
				else
				{
					throw new Exception($"Wrong amount of matches: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<Product> GetAllCriticalProducts()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select p.id, manufacturers.man_name, p.manufacturer_id, p.product_name, p.buy_price, p.sell_price, p.description, p.category, p.product_status, p.width, p.height, p.depth, p.weight from products as p join manufacturers on p.manufacturer_id = manufacturers.id INNER JOIN shelf_stock AS s ON p.id = s.product_id WHERE s.quantity <= 10;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var products = new List<Product>();

					foreach (DataRow dr in dt.Rows)
					{
						var id = Convert.ToInt32(dr["id"].ToString());
						var manufacturerId = Convert.ToInt32(dr["manufacturer_id"].ToString());
						var manufacturerName = dr["man_name"].ToString();
						var productName = dr["product_name"].ToString();
						var buyPrice = Convert.ToDouble(dr["buy_price"].ToString());
						var sellPrice = Convert.ToDouble(dr["sell_price"].ToString());
						var description = dr["description"].ToString();
						var category = (Category)Enum.Parse(typeof(Category), dr["category"].ToString().Replace(' ', '_'));
						var productStatus = (ProductStatus)Enum.Parse(typeof(ProductStatus), dr["product_status"].ToString().Replace(' ', '_'));
						var width = float.Parse(dr["width"].ToString());
						var height = float.Parse(dr["height"].ToString());
						var depth = float.Parse(dr["depth"].ToString());
						var weight = float.Parse(dr["weight"].ToString());
						var product = new Product(id, manufacturerId, manufacturerName, productName, buyPrice, sellPrice, description, category, productStatus, width, height, depth, weight);
						products.Add(product);
					}
					return products;
				}
				else
				{
					throw new Exception($"Wrong amount of matches: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public void UpdateProduct(Product product)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(
					"update Products set manufacturer_id = @manufacturerId, product_name = @productName, buy_price = @buyPrice, sell_price = @sellPrice, description = @description, category = @category, product_status= @productStatus, width = @width, height = @height, depth = @depth, weight = @weight where id = @id;");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("id", product.Id);
				command.Parameters.AddWithValue("manufacturerId", product.ManufacturerId);
				command.Parameters.AddWithValue("productName", product.ProductName);
				command.Parameters.AddWithValue("buyPrice", product.BuyPrice);
				command.Parameters.AddWithValue("sellPrice", product.SellPrice);
				command.Parameters.AddWithValue("description", product.Description);
				command.Parameters.AddWithValue("category", product.Category.ToString());
				command.Parameters.AddWithValue("productStatus", product.ProductStatus.ToString());
				command.Parameters.AddWithValue("width", product.Width);
				command.Parameters.AddWithValue("height", product.Height);
				command.Parameters.AddWithValue("depth", product.Depth);
				command.Parameters.AddWithValue("weight", product.Weight);
				command.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				CloseConnection();
			}
		}

		#endregion
	}
}
