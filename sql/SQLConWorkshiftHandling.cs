using MediaBazzar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MediaBazaar
{
	public class SQLConWorkshiftHandling : SQLCon
	{
		
		#region WorkshiftHandling

		public List<Workshift> GetAllWorkshifts()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT wd.id, wd.work_date, wd.shift_type, wd.min_workers, d.dept_name FROM workshift_date AS wd INNER JOIN departments AS d ON wd.dept_id = d.id;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				if (dt.Rows.Count > 0)
				{
					List<Workshift> workshifts = new List<Workshift>();
					foreach (DataRow row in dt.Rows)
					{
						var sb2 = new StringBuilder();
						sb2.Append($" SELECT u.id, u.first_name, u.last_name, d.dept_name, u.part_time_factor FROM departments AS d INNER JOIN positions AS p ON d.id = p.dept_id INNER JOIN users AS u ON u.position_id = p.id INNER JOIN workshift_user AS wu ON u.id = wu.user_id WHERE wu.shift_id = {row["id"]}");
						var sql2 = sb2.ToString();
						var dt2 = SelectQuery(sql2);
						List<ShiftPerson> persons = new List<ShiftPerson>();
						if (dt2.Rows.Count > 0)
						{
							foreach (DataRow row2 in dt2.Rows)
							{
								ShiftPerson newPerson = new ShiftPerson(Convert.ToInt32(row2["id"]), row2["first_name"].ToString(), row2["last_name"].ToString(), row2["dept_name"].ToString(), Convert.ToInt32(row2["part_time_factor"]));
								persons.Add(newPerson);
							}
						}
						Workshift newWorkshift;
						switch (row["shift_type"])
						{
							case "Morning":
								newWorkshift = new Workshift(DateTime.Parse(row["work_date"].ToString()), ShiftType.Morning, Convert.ToInt32(row["min_workers"]), row["dept_name"].ToString(), persons);
								break;
							case "Afternoon":
								newWorkshift = new Workshift(DateTime.Parse(row["work_date"].ToString()), ShiftType.Afternoon, Convert.ToInt32(row["min_workers"]), row["dept_name"].ToString(), persons);
								break;
							case "Evening":
								newWorkshift = new Workshift(DateTime.Parse(row["work_date"].ToString()), ShiftType.Evening, Convert.ToInt32(row["min_workers"]), row["dept_name"].ToString(), persons);
								break;
							default:
								newWorkshift = null;
								break;
						}
						if (newWorkshift != null)
						{
							workshifts.Add(newWorkshift);
						}
					}
					return workshifts;
				}
				else
				{
					return null;
				}
			}
			catch (InvalidOperationException)
			{
				return null;
			}
		}

		public List<ShiftPerson> GetAllEmployees()
			{
				try
				{
					var sb = new StringBuilder();
					sb.Append($" SELECT DISTINCT u.id, u.first_name, u.last_name, d.dept_name, u.part_time_factor FROM departments AS d INNER JOIN positions AS p ON d.id = p.dept_id INNER JOIN users AS u ON u.position_id = p.id INNER JOIN workshift_user AS wu ON u.id = wu.user_id");
					var sql = sb.ToString();
					var dt = SelectQuery(sql);
					List<ShiftPerson> persons = new List<ShiftPerson>();

					if (dt.Rows.Count > 0)
					{
						foreach (DataRow dr in dt.Rows)
						{
						var Id = Convert.ToInt32(dr["id"]);
						var Firstname = dr["first_name"].ToString();
						var Lastname = dr["last_name"].ToString();
						var DepartmentName = dr["dept_name"].ToString();
						var MaxHours = Convert.ToInt32(dr["part_time_factor"]);
						ShiftPerson NewPerson = new ShiftPerson(Id, Firstname, Lastname, DepartmentName, MaxHours);
						persons.Add(NewPerson);
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

			public bool UpdateShift(List<int> usersForThisShift, DateTime date, int deptId, ShiftType shiftType = ShiftType.Morning)
			{
				try
				{
					var sb = new StringBuilder();
					var usersToAdd = new StringBuilder();
					var iter = 1;
					var shift = shiftType.ToString();
					foreach (var i in usersForThisShift)
					{
						usersToAdd.Append($"({iter},{i}),");
						iter++;
					}
					usersToAdd[usersToAdd.Length - 1] = ';';
					//MessageBox.Show(usersToAdd.ToString());
					sb.Append("begin tran\n");
					sb.Append("declare @WorkshiftDateId INT\n");
					sb.Append("DECLARE @myTableVariable TABLE (id INT, name INT);\n");
					sb.Append($"insert into @myTableVariable values{usersToAdd}\n");
					sb.Append("declare @AmountOfUsers INT = (select COUNT(*) from @myTableVariable);\n");
					sb.Append(
						$"if exists (select * from workshift_date where work_date = '{date:yyyy-MM-dd}' and shift_type = '{shift}')\n");
					sb.Append("begin\n");
					sb.Append(
						$"set @WorkshiftDateId = (select id from workshift_date where work_date = '{date:yyyy-MM-dd}' and shift_type = '{shift}');\n");
					sb.Append("update workshift_date set min_workers = @AmountOfUsers where id = @WorkshiftDateId;\n");
					sb.Append("delete from workshift_user where shift_id = @WorkshiftDateId;\n");
					sb.Append("declare @i INT = 1;\n");
					sb.Append("while @i <= @AmountOfUsers\n");
					sb.Append("begin\n");
					sb.Append(
						"insert into workshift_user (shift_id, user_id) values (@WorkshiftDateId, (select name from @myTableVariable where id = @i));\n");
					sb.Append("set @i = @i +1;\n");
					sb.Append("end\nend\n");
					sb.Append("else\n");
					sb.Append("begin\n");
					sb.Append(
						$"insert into workshift_date (work_date, shift_type, min_workers, dept_id) values ('{date:yyyy-MM-dd}', '{shift}', @AmountOfUsers, {deptId});\n");
					sb.Append(
						$"set @WorkshiftDateId = (select id from workshift_date where work_date = '{date:yyyy-MM-dd}' and shift_type = '{shift}');\n");
					sb.Append("set @i = 1;\n");
					sb.Append("while @i <= @AmountOfUsers\n");
					sb.Append("begin\n");
					sb.Append("insert into workshift_user (shift_id, user_id) values (@WorkshiftDateId, (select name from @myTableVariable where id = @i));\n");
					sb.Append("set @i = @i +1;");
					sb.Append("end\nend\n");
					sb.Append("commit tran");
					var sql = sb.ToString();
					OpenConnection();
					var command = Command(sql);
					command.ExecuteNonQuery();
					return true;
				}
				catch (SqlException e)
				{
					MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
				finally
				{
					CloseConnection();
				}
			}
			
			#endregion

		}
}
