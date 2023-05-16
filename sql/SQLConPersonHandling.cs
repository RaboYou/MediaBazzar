using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConPersonHandling : SQLCon
	{
		#region PersonHandling

		/// <summary>
		/// This method actually pulls a person clads object from the database
		/// </summary>
		/// <param name="userLogin">it uses user login as a parameter since logins are unique</param>
		/// <returns>a person class object or null if it </returns>
		public Person GetPerson(string userLogin)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT * FROM USERS WHERE LOGIN = '{userLogin}';");
				var sql = sb.ToString();

				var dt = SelectQuery(sql);

				if (dt.Rows.Count == 1)
				{
					var dr = dt.Rows[0];
					var id = Convert.ToInt32(dr["id"].ToString());
					var firstName = dr["first_name"].ToString();
					var lastName = dr["last_name"].ToString();
					var dateOfBirth = Convert.ToDateTime(dr["date_of_birth"].ToString());
					var nationality = (Nationality)Enum.Parse(typeof(Nationality), dr["nationality"].ToString());
					var email = dr["email"].ToString();
					var addressZipCode = dr["address_zip_code"].ToString();
					var addressCity = dr["address_city"].ToString();
					var addressStreet = dr["address_street"].ToString();
					var dateOfEmployment = Convert.ToDateTime(dr["date_of_employment"].ToString());
					var positionId = Convert.ToInt32(dr["position_id"].ToString());
					var isActive = dr["is_active"].ToString() != "False";
					var login = dr["login"].ToString();
					var gender = Convert.ToChar(dr["gender"].ToString());
					var phone = dr["contact_number"].ToString();
					var ssn = Convert.ToInt32(dr["bsn"]);
					var iceName = dr["ice_name"].ToString();
					var iceNumber = dr["ice_number"].ToString();
					var hourlyWage = Convert.ToDouble(dr["hour_wage"]);
					var user = new Person(id, firstName, lastName, dateOfBirth, nationality, email,
						addressZipCode, addressCity, addressStreet, dateOfEmployment, positionId, isActive,
						login, gender, phone, ssn, iceName, iceNumber, hourlyWage);
					return user;
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

		public List<Person> GetAllPersons()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("SELECT * FROM USERS;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var persons = new List<Person>();
					foreach (DataRow dr in dt.Rows)
					{
						var id = Convert.ToInt32(dr["id"].ToString());
						var firstName = dr["first_name"].ToString();
						var lastName = dr["last_name"].ToString();
						var dateOfBirth = Convert.ToDateTime(dr["date_of_birth"].ToString());
						var nationality = (Nationality)Enum.Parse(typeof(Nationality), dr["nationality"].ToString());
						var email = dr["email"].ToString();
						var addressZipCode = dr["address_zip_code"].ToString();
						var addressCity = dr["address_city"].ToString();
						var addressStreet = dr["address_street"].ToString();
						var dateOfEmployment = Convert.ToDateTime(dr["date_of_employment"].ToString());
						var positionId = Convert.ToInt32(dr["position_id"].ToString());
						var isActive = dr["is_active"].ToString() != "1";
						var login = dr["login"].ToString();
						var gender = Convert.ToChar(dr["gender"].ToString());
						var phone = dr["contact_number"].ToString();
						var ssn = Convert.ToInt32(dr["bsn"]);
						var iceName = dr["ice_name"].ToString();
						var iceNumber = dr["ice_number"].ToString();
						var hourlyWage = Convert.ToDouble(dr["hour_wage"]);
						var user = new Person(id, firstName, lastName, dateOfBirth, nationality, email, addressZipCode, addressCity, addressStreet, dateOfEmployment, positionId, isActive, login, gender, phone, ssn, iceName, iceNumber, hourlyWage);
						persons.Add(user);
					}
					return persons;
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

		public List<Person> SearchPersons(string name)
		{
			try
			{
				var sb = new StringBuilder();
				string[] multiName = { };
				if (name.Contains(" "))
				{
					multiName = name.Split(' ');
					sb.Append($"SELECT * FROM USERS WHERE first_name LIKE '%{multiName[0]}%' AND last_name LIKE '%{multiName[1]}%';");
				}
				else
				{
					sb.Append($"SELECT * FROM USERS WHERE first_name LIKE '%{name}%' OR last_name LIKE '%{name}%';");
				}
				
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					var persons = new List<Person>();

					foreach (DataRow dr in dt.Rows)
					{
						var id = Convert.ToInt32(dr["id"].ToString());
						var firstName = dr["first_name"].ToString();
						var lastName = dr["last_name"].ToString();
						var dateOfBirth = Convert.ToDateTime(dr["date_of_birth"].ToString());
						var nationality = (Nationality)Enum.Parse(typeof(Nationality), dr["nationality"].ToString());
						var email = dr["email"].ToString();
						var addressZipCode = dr["address_zip_code"].ToString();
						var addressCity = dr["address_city"].ToString();
						var addressStreet = dr["address_street"].ToString();
						var dateOfEmployment = Convert.ToDateTime(dr["date_of_employment"].ToString());
						var positionId = Convert.ToInt32(dr["position_id"].ToString());
						var isActive = dr["is_active"].ToString() == "1";
						var login = dr["login"].ToString();
						var gender = Convert.ToChar(dr["gender"].ToString());
						var phone = dr["contact_number"].ToString();
						var ssn = Convert.ToInt32(dr["bsn"]);
						var iceName = dr["ice_name"].ToString();
						var iceNumber = dr["ice_number"].ToString();
						var hourlyWage = Convert.ToDouble(dr["hour_wage"]);
						var user = new Person(id, firstName, lastName, dateOfBirth, nationality, email, addressZipCode, addressCity, addressStreet, dateOfEmployment, positionId, isActive, login, gender, phone, ssn, iceName, iceNumber, hourlyWage);
						persons.Add(user);
					}
					return persons;
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
		public bool CheckAccount(string username)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT login FROM users where users.login = '{username}';");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count == 0)
				{
					return false;
				}
				else
				{
					throw new Exception($"Account already exists: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true; //null;
			}
		}

		public int GetPosition(string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"select id from positions where position_name = '{input}';");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				if (dt.Rows.Count > 0)
				{
					foreach (DataRow result in dt.Rows)
					{
						return Convert.ToInt32(result["id"]);
					}
					return -1;
				}
				else
				{
					throw new Exception($"Account already exists: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1; //null;
			}
		}

		public void CreatePerson(Person person, string password)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("INSERT INTO Users (first_name, last_name, date_of_birth, nationality, email, address_zip_code, address_city, address_street, date_of_employment, position_id, is_active, login, user_password, gender, contact_number, bsn, ice_name, ice_number, hour_wage) VALUES (@first_name, @last_name, @date_of_birth, @nationality, @email, @address_zip_code, @address_city, @address_street, @date_of_employment, @position_id, @is_active, @login, @user_password, @gender, @phone, @ssn, @ice_name, @ice_number, @hour_wage);");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("@first_name", person.FirstName);
				command.Parameters.AddWithValue("@last_name", person.LastName);
				command.Parameters.AddWithValue("@date_of_birth", person.DateOfBirth);
				command.Parameters.AddWithValue("@nationality", person.Nationality.ToString());
				command.Parameters.AddWithValue("@email", person.Email);
				command.Parameters.AddWithValue("@address_zip_code", person.AddressZipCode);
				command.Parameters.AddWithValue("@address_city", person.AddressCity);
				command.Parameters.AddWithValue("@address_street", person.AddressStreet);
				command.Parameters.AddWithValue("@date_of_employment", person.DateOfEmployment);
				command.Parameters.AddWithValue("@position_id", person.PositionId);
				command.Parameters.AddWithValue("@is_active", person.IsActive);
				command.Parameters.AddWithValue("@login", person.Login);
				command.Parameters.AddWithValue("@user_password", BCrypt.Net.BCrypt.HashPassword(password));
				command.Parameters.AddWithValue("@gender", person.Gender);
				command.Parameters.AddWithValue("@phone", person.Phone);
				command.Parameters.AddWithValue("@ssn", person.Ssn);
				command.Parameters.AddWithValue("@ice_name", person.IceName);
				command.Parameters.AddWithValue("@ice_number", person.IceName);
				command.Parameters.AddWithValue("@hour_wage", person.HourlyWage);
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

		public void UpdatePerson(Person person, int index)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"UPDATE Users SET first_name = '{person.FirstName}', last_name = '{person.LastName}', date_of_birth = '{person.DateOfBirth:yyyy-MM-dd}', nationality = '{person.Nationality}', email = '{person.Email}', address_zip_code = '{person.AddressZipCode}', address_city = '{person.AddressCity}', address_street = '{person.AddressStreet}', date_of_employment = '{person.DateOfEmployment:yyyy-MM-dd}', position_id = '{person.PositionId}', is_active = '{person.IsActive}', gender = '{person.Gender}' WHERE id = '{index}'");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
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
		public void TerminatePerson(Person person, string rshort, string rlong)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("begin tran\n");
				sb.Append("INSERT INTO termination (user_id, reason_short, reason_text, termination_date) VALUES (@user_id, @reason_short, @reason_text, @termination_date);\n");
				sb.Append($"UPDATE users SET is_active = 0 WHERE id = {person.Id};\n");
				sb.Append("commit tran");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("@user_id", person.Id);
				command.Parameters.AddWithValue("@reason_short", rshort);
				command.Parameters.AddWithValue("@reason_text", rlong);
				command.Parameters.AddWithValue("@termination_date", DateTime.Now);
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

		public void ActivatePerson(Person person)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"UPDATE users SET is_active = 1 WHERE id = {person.Id}");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
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