using MediaBazzar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConShiftPersonHandling : SQLCon
	{
		#region ShiftPersonHandling

		/// <summary>
		/// Queries the database for
		/// </summary>
		/// <returns></returns>
		public List<ShiftPerson> GetAllPersons()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select departments.dept_name, departments.id as dept_id, users.first_name, users.last_name, positions.position_name, users.id, users.part_time_factor from departments join positions on positions.dept_id = departments.id join users on users.position_id = positions.id where positions.is_workshift_position = 'true';");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				List<ShiftPerson> persons = new List<ShiftPerson>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						ShiftPerson newPerson = new ShiftPerson(Convert.ToInt32(dr["id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["dept_name"].ToString(), Convert.ToInt32(dr["part_time_factor"]));
						persons.Add(newPerson);
					}
					return persons;
				}
				else
				{
					throw new Exception($"Empty response, matches: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		#endregion
	}
}
