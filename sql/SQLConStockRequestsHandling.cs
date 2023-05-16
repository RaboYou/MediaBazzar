using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConStockRequestsHandling : SQLCon
	{
		#region StockRequestsHandling

		public void CreateRestockRequest(Restock restock)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("begin tran\n");
				sb.Append("INSERT INTO order_request(order_date, user_id) VALUES (@order_date, @user_id);\n");
				sb.Append("INSERT INTO order_request_position(product_id, order_request_id, quantity, is_open) VALUES(@product_id, (SELECT MAX(id) AS id FROM order_request), @quantity, @is_open);");
				sb.Append("commit tran");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("@order_date", DateTime.Now);
				command.Parameters.AddWithValue("@user_id", restock.person.Id);
				command.Parameters.AddWithValue("@product_id", restock.product.Id);
				command.Parameters.AddWithValue("@quantity", restock.quantity);
				command.Parameters.AddWithValue("@is_open", 1);
				command.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//return null;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//return null;
			}
			finally
			{
				CloseConnection();
			}
		}


		public List<Restock> GetAllRestockRequests()
        {
			try
			{
				var sb = new StringBuilder();
				sb.Append("SELECT o.order_date, op.*, p.product_name, p.sell_price, p.buy_price, p.category FROM order_request AS o INNER JOIN order_request_position AS op ON o.id = op.order_request_id INNER JOIN products AS p ON op.product_id = p.id WHERE is_open = 1;\n");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var restocks = new List<Restock>();

					foreach (DataRow dr in dt.Rows)
					{
						var orderrequestId = Convert.ToInt32(dr["order_request_id"].ToString());
						var quantity = Convert.ToInt32(dr["quantity"].ToString());
						var isopen = Convert.ToBoolean(dr["is_open"].ToString());

						var productName = dr["product_name"].ToString();
						var buyPrice = Convert.ToDouble(dr["buy_price"].ToString());
						var sellPrice = Convert.ToDouble(dr["sell_price"].ToString());
						var category = (Category)Enum.Parse(typeof(Category), dr["category"].ToString().Replace(' ', '_'));



						var restock = new Restock(orderrequestId, productName, buyPrice, sellPrice, category, isopen, quantity);
						restocks.Add(restock);
					}
					return restocks;
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

		public List<Restock> GetAllConfirmedRestockRequests()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("SELECT o.order_date, op.*, p.product_name, p.sell_price, p.buy_price, p.category FROM order_request AS o INNER JOIN order_request_position AS op ON o.id = op.order_request_id INNER JOIN products AS p ON op.product_id = p.id WHERE is_open = 0;\n");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var confirmedrestocks = new List<Restock>();

					foreach (DataRow dr in dt.Rows)
					{
						var orderrequestId = Convert.ToInt32(dr["order_request_id"].ToString());
						var quantity = Convert.ToInt32(dr["quantity"].ToString());
						var isopen = Convert.ToBoolean(dr["is_open"].ToString());

						var productName = dr["product_name"].ToString();
						var buyPrice = Convert.ToDouble(dr["buy_price"].ToString());
						var sellPrice = Convert.ToDouble(dr["sell_price"].ToString());
						var category = (Category)Enum.Parse(typeof(Category), dr["category"].ToString().Replace(' ', '_'));



						var restock = new Restock(orderrequestId, productName, buyPrice, sellPrice, category, isopen, quantity);
						confirmedrestocks.Add(restock);
					}
					return confirmedrestocks;
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

		public void UpdateRestock(Restock restock)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("UPDATE order_request_position set is_open = @IsOpen WHERE order_request_id = @orderId;");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("IsOpen", restock.IsOpen);
				command.Parameters.AddWithValue("orderId", restock.orderrequestId);
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
