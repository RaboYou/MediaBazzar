using System;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConLogin : SQLCon
	{
		private SQLConPersonHandling con = new SQLConPersonHandling();

		#region Login

		/// <summary>
		/// This method checks if the password is correct and is the account active in the database
		/// uses BCrypt to verify if the hashed password is matching
		/// </summary>
		/// <param name="userName">Takes user name from the textbox</param>
		/// <param name="password">Takes password from the textbox and compares it with the hashed password from the database</param>
		/// <returns>person class object or null if it catches an exception</returns>
		public Person CheckPassword(string userName, string password)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT * FROM users WHERE LOGIN = '{userName}';");
				var sql = sb.ToString();
				var dt = con.SelectQuery(sql);

				if (dt.Rows.Count == 1)
				{
					var dr = dt.Rows[0];
					var hashedPassword = dr["user_password"].ToString();

					if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
					{
						var person = con.GetPerson(userName);
						if (person.IsActive)
						{
							return person;
						}
						else
						{
							throw new Exception("Account inactive");
						}
					}
					else
					{
						throw new Exception("Wrong password");
					}
				}
				else
				{
					throw new ArgumentException($"Wrong amount of matches: {dt.Rows.Count}");
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("User does not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>
		/// This method pulls access level of a person, access level indicates which form will be opened next
		/// there are 4 levels of access from 1 to 4, TBD which is which
		/// </summary>
		/// <param name="id">persons id is taken as a parameter for query</param>
		/// <returns>access level as an int from 1 to 4, if something goes wrong it returns -1 as an error</returns>
		public int GetPersonAccessLevel(int id)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT positions.access_level FROM users join positions on positions.id = users.position_id where users.id = '{id}';");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				if (dt.Rows.Count == 1)
				{
					var dr = dt.Rows[0];
					var accessLevel = Convert.ToInt32(dr["access_level"].ToString());
					return accessLevel;
				}
				else
				{
					throw new Exception($"Wrong amount of matches: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1; //null;
			}
		}
		#endregion
	}
}
