using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConManufacturersHandling : SQLCon
	{
		#region ManufacturersHandling
		public void CreateManufacturer(Manufacturer manufacturer)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(
					"INSERT INTO manufacturers (man_name, address, country) VALUES (@manName, @manAdress, @manCountry);");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("manName", manufacturer.ManName);
				command.Parameters.AddWithValue("manAdress", manufacturer.ManAdress);
				command.Parameters.AddWithValue("manCountry", manufacturer.ManCountry);
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

		public bool CheckManufacturer(string manName)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT man_name FROM manufacturers where manufacturers.man_name = '{manName}';");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count == 0)
				{
					return false;
				}
				else
				{
					throw new Exception($"Manufacturer already exists: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true; //null;
			}
		}

		public List<Manufacturer> GetAllManufacturers()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("SELECT * FROM manufacturers;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var manufacturers = new List<Manufacturer>();

					foreach (DataRow dr in dt.Rows)
					{
						var id = Convert.ToInt32(dr["id"].ToString());
						var manName = dr["man_name"].ToString();
						var manAdress = dr["address"].ToString();
						var manCountry = (ManCountry)Enum.Parse(typeof(ManCountry), dr["country"].ToString().ToUpper().Replace(' ', '_'));
						var Objectmanufacturers = new Manufacturer(id, manName, manAdress, manCountry);
						manufacturers.Add(Objectmanufacturers);
					}
					return manufacturers;
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

		public List<Manufacturer> SearchManufacturers(string name)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT * FROM manufacturers WHERE man_name LIKE '%{name}%';;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var manufacturers = new List<Manufacturer>();
					foreach (DataRow dr in dt.Rows)
					{
						var id = Convert.ToInt32(dr["id"].ToString());
						var manname = dr["man_name"].ToString();
						var manAdress = dr["address"].ToString();
						var manCountry = (ManCountry)Enum.Parse(typeof(ManCountry), dr["country"].ToString().ToUpper().Replace(' ', '_'));
						var Objectmanufacturers = new Manufacturer(id, manname, manAdress, manCountry);
						manufacturers.Add(Objectmanufacturers);
					}
					return manufacturers;
				}
				else
				{
					return null;
					//throw new Exception($"Wrong amount of matches: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public void UpdateManufacturer(Manufacturer manufacturer)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(
					"update manufacturers set man_name = @manName, address = @manAddress, country = @manCountry where id = @id;");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("@id", manufacturer.ManId);
				command.Parameters.AddWithValue("@manName", manufacturer.ManName);
				command.Parameters.AddWithValue("@manAddress", manufacturer.ManAdress);
				command.Parameters.AddWithValue("@manCountry", manufacturer.ManCountry);
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
