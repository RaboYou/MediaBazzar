using MediaBazzar;
using MediaBazzar.EmployeeChanges;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConChangeRequestHandling : SQLCon
	{

		#region ChangeRequestHandling

		public List<ChangeRequest> GetAllChangeRequests(List<Person> allPersons)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("SELECT * FROM users_change_requests");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);

				if (dt.Rows.Count > 0)
				{
					List<ChangeRequest> allRequests = new List<ChangeRequest>();
					foreach (DataRow dr in dt.Rows)
					{
						Person toAdd = null;
						foreach(Person person in allPersons)
						{
							if (person.Id == Convert.ToInt32(dr["user_id"]))
							{
								toAdd = person;
							}
						}

						var id = Convert.ToInt32(dr["id"].ToString());
						var firstName = dr["first_name"].ToString();
						var lastName = dr["last_name"].ToString();
						var dateOfBirth = Convert.ToDateTime(dr["date_of_birth"].ToString());
						var nationality = (Nationality)Enum.Parse(typeof(Nationality), dr["nationality"].ToString());
						var email = dr["email"].ToString();
						var addressZipCode = dr["address_zip_code"].ToString();
						var addressCity = dr["address_city"].ToString();
						var addressStreet = dr["address_street"].ToString();
						var gender = Convert.ToChar(dr["gender"].ToString());
						var phone = dr["contact_number"].ToString();
						var bsn = Convert.ToInt32(dr["bsn"]);
						var iceName = dr["ice_name"].ToString();
						var iceNumber = dr["ice_number"].ToString();
						char accepted = Convert.ToChar(dr["accepted"]);
						if (accepted != 'F' && accepted != 'T' && accepted != 'N')
						{
							accepted = 'N';
						}

						ChangeRequest newRequest = new ChangeRequest(toAdd, id, firstName, lastName, dateOfBirth, nationality, email, addressZipCode, addressCity, addressStreet, gender, bsn, iceName, iceNumber, phone, accepted);
						allRequests.Add(newRequest);
					}
					return allRequests;
				}
				return null;
			}
			catch (InvalidOperationException)
			{
				return null;
			}
		}

		public void AcceptChangeRequest(ChangeRequest request)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("UPDATE users_change_requests SET accepted = 'T' WHERE id = @id;");
				var sql = sb.ToString();
				OpenConnection();
				var command = Command(sql);
				command.Parameters.AddWithValue("id", request.Id);
				command.ExecuteNonQuery();
			}
			catch (InvalidOperationException)
			{
				return;
			}
		}

		#endregion
	}
}
