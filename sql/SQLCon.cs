using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MediaBazaar
{
	/// <summary>
	/// This class handles SQL server queries
	/// </summary>
	/// <remarks>
	/// All SQL queries should be here
	/// </remarks>
	public class SQLCon
	{
		/// <summary>
		/// credentials for the server, I know that they should be in separate file and be kept on gitignore file, but it's just for now
		/// </summary>
		private const string DataSource = "mssql.fhict.local";
		private const string UserID = "dbi472712_test";
		private const string Password = "Horseradish666";
		private const string InitialCatalog = "dbi472712_test";
		private SqlConnectionStringBuilder builder;
		private SqlConnection sqlConnection;

		/// <summary>
		/// constructor for the connection, it uses ConnectionStringbuilder for MySQL, because it looks nicer
		/// </summary>
		/// <remarks>
		/// It creates something like this:
		/// "Server=studmysql01.fhict.local;Uid=dbi465395;Database=dbi465395;Pwd=Michael;");
		/// </remarks>
		public SQLCon()
		{
			this.builder = new SqlConnectionStringBuilder
			{
				DataSource = DataSource,
				UserID = UserID,
				Password = Password,
				InitialCatalog = InitialCatalog
			};
		}

		#region Common

		public void OpenConnection()
		{
			this.sqlConnection = new SqlConnection(this.builder.ConnectionString);
			this.sqlConnection.Open();
		}

		public void CloseConnection()
		{
			this.sqlConnection.Close();
		}

		public SqlCommand Command(string query)
		{
			var cmd = new SqlCommand(query, this.sqlConnection);
			return cmd;
		}

		public DataTable SelectQuery(string sql)
		{
			using var connection = new SqlConnection(this.builder.ConnectionString);
			//MessageBox.Show("Some text", "Some title", MessageBoxButtons.OK, MessageBoxIcon.Error);

			try
			{
				using var command = new SqlCommand(sql, connection);
				connection.Open();
				var da = new SqlDataAdapter(command);
				var dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (SqlException e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
			finally
			{
				connection.Close();
			}
		}

		#endregion
	}
}