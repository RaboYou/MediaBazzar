using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using MediaBazzar.StatisticsClasses;

namespace MediaBazaar
{
	public class SQLConStatisticsHandling : SQLCon
	{
		#region StatisticsHandling

		public List<DepartmentView> GetDepartmentViewsForStatistics()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select departments.dept_name, departments.id as dept_id, users.first_name, users.last_name, positions.position_name, users.id, users.part_time_factor from departments join positions on positions.dept_id = departments.id join users on users.position_id = positions.id;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var departmentViewList = new List<DepartmentView>();
				var DepartmentNamesList = new List<string>();
				var employees = new List<EmployeeDepartmentView>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						if (!DepartmentNamesList.Contains(dr["dept_name"].ToString()))
						{
							var departmentViewClass = new DepartmentView(dr["dept_name"].ToString(), Convert.ToInt32(dr["dept_id"]));
							departmentViewList.Add(departmentViewClass);
							DepartmentNamesList.Add(dr["dept_name"].ToString());
						}
					}
					foreach (DataRow dr in dt.Rows)
					{
						foreach (var item in departmentViewList)
						{
							if (item.DepartmentName == dr["dept_name"].ToString())
							{
								item.AddEmployee(dr["first_name"].ToString(), dr["last_name"].ToString(), dr["position_name"].ToString(), Convert.ToInt32(dr["id"]));
							}
						}
					}
					return departmentViewList;
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

		public List<AgeStatistics> GetAgeStatistics(string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"select dept_name, Age, count(Age) as AmountByAge from ages WHERE dept_name = '{input}' GROUP BY dept_name, Age");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var ageStatisticsList = new List<AgeStatistics>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var departmentName = dr["dept_name"].ToString();
						var age = Convert.ToInt32(dr["Age"]);
						var amountByAge = Convert.ToInt32(dr["AmountByAge"]);
						var ageStatistics = new AgeStatistics(departmentName, age, amountByAge);
						ageStatisticsList.Add(ageStatistics);
					}
					return ageStatisticsList;
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

		public List<AgeStatistics> GetAgeStatisticsOverall()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select Age, count(Age) as AmountByAge from agesOverall group by Age;");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var ageStatisticsList = new List<AgeStatistics>();
				const string DepartmentName = "Overall";

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var age = Convert.ToInt32(dr["Age"]);
						var amountByAge = Convert.ToInt32(dr["AmountByAge"]);
						var ageStatistics = new AgeStatistics(DepartmentName, age, amountByAge);
						ageStatisticsList.Add(ageStatistics);
					}
					return ageStatisticsList;
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

		public List<GenderStatistics> GetGenderStatistics(string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"select dept_name, gender, AmountByGender as AmountByGender from genders WHERE dept_name = '{input}' Group By dept_name, gender, AmountByGender");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var genderStatisticsList = new List<GenderStatistics>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var DepartmentName = dr["dept_name"].ToString();
						var gender = dr["gender"].ToString();
						var amountByGender = Convert.ToInt32(dr["AmountByGender"]);
						var genderStatistics = new GenderStatistics(DepartmentName, gender, amountByGender);
						genderStatisticsList.Add(genderStatistics);
					}
					return genderStatisticsList;
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

		public List<GenderStatistics> GetGenderStatisticsOverall()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select gender, AmountByGender as AmountByGender from gendersOverall Group by gender,AmountByGender");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var genderStatisticsList = new List<GenderStatistics>();
				const string departmentName = "Overall";

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var gender = dr["gender"].ToString();
						var amountByGender = Convert.ToInt32(dr["AmountByGender"]);
						var genderStatistics = new GenderStatistics(departmentName, gender, amountByGender);
						genderStatisticsList.Add(genderStatistics);
					}
					return genderStatisticsList;
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

		public List<NationalityStatistics> GetNationalityStatistics(string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"select dept_name, nationality, AmountBYNationality as AmountByNationality from nationality WHERE dept_name = '{input}' group by dept_name, nationality, AmountByNationality");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var nationalityStatisticsList = new List<NationalityStatistics>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var DepartmentName = dr["dept_name"].ToString();
						var nationality = dr["nationality"].ToString();
						var amountByNationality = Convert.ToInt32(dr["AmountByNationality"]);
						var nationalityStatistics = new NationalityStatistics(DepartmentName, nationality, amountByNationality);
						nationalityStatisticsList.Add(nationalityStatistics);
					}
					return nationalityStatisticsList;
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

		public List<NationalityStatistics> GetNationalityStatisticsOverall()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select nationality, AmountByNationality from nationalityOverall group by nationality,AmountByNationality");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var nationalityStatisticsList = new List<NationalityStatistics>();
				const string DepartmentName = "Overall";

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var nationality = dr["nationality"].ToString();
						var amountByNationality = Convert.ToInt32(dr["AmountByNationality"]);
						var nationalityStatistics = new NationalityStatistics(DepartmentName, nationality, amountByNationality);
						nationalityStatisticsList.Add(nationalityStatistics);
					}
					return nationalityStatisticsList;
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

		public List<CityStatistics> GetCityStatistics(string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"select dept_name, address_city, AmountByCity as AmountByCity from city WHERE dept_name = '{input}' group by dept_name, address_city, AmountByCity");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var cityStatisticsList = new List<CityStatistics>();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var DepartmentName = dr["dept_name"].ToString();
						var city = dr["address_city"].ToString();
						var amountByCity = Convert.ToInt32(dr["AmountByCity"]);
						var cityStatistics = new CityStatistics(DepartmentName, city, amountByCity);
						cityStatisticsList.Add(cityStatistics);
					}
					return cityStatisticsList;
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

		public List<CityStatistics> GetCityStatisticsOverall()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append("select address_city, AmountByCity as AmountByCity from cityOverall group by address_city, AmountByCity");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var cityStatisticsList = new List<CityStatistics>();
				const string DepartmentName = "Overall";

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var city = dr["address_city"].ToString();
						var amountByCity = Convert.ToInt32(dr["AmountByCity"]);
						var cityStatistics = new CityStatistics(DepartmentName, city, amountByCity);
						cityStatisticsList.Add(cityStatistics);
					}
					return cityStatisticsList;
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

		public List<ProductPopularity> GetProductPopularity(string startDate, string endDate, string input)
		{
			try
			{
				var sb = new StringBuilder();

				sb.Append(
					$"select product_name, quantity, order_date from productPopularity WHERE order_date >= '{startDate}' AND order_date <= '{endDate}' AND product_name = '{input}' group by product_name, quantity, order_date");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var productPopularityList = new List<ProductPopularity>();
				string productName;
				int quantity;
				DateTime date;

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						productName = dr["product_name"].ToString();
						quantity = Convert.ToInt32(dr["quantity"]);
						date = Convert.ToDateTime(dr["order_date"]);
						var productPopularity = new ProductPopularity(productName, quantity, date);
						productPopularityList.Add(productPopularity);
					}
			
					return productPopularityList;
				}
				if (dt.Rows.Count == 0)
				{
					MessageBox.Show("No data about product in this time range");
					return productPopularityList;
				}
				throw new Exception($"Empty response, matches: {dt.Rows.Count}");
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public EmployeeEvolution GetEmployeeEvolution(string year, string date, string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(
					$"SELECT dept_name, Count(date_of_employment) as '{year}' from employeeEvolutionPerDepartment WHERE date_of_employment < '{date}' AND dept_name = '{input}' GROUP BY dept_name");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var employeeStatisticsList = new List<EmployeeEvolution>();
				var Year = year;
				string departmentName;
				int amountOfEmployees;

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						departmentName = dr["dept_name"].ToString();
						amountOfEmployees = Convert.ToInt32(dr[year]);
						var employeeEvolution = new EmployeeEvolution(departmentName, amountOfEmployees, Year);
						employeeStatisticsList.Add(employeeEvolution);
					}
					return employeeStatisticsList[0];
				}
				else if (dt.Rows.Count == 0)
				{
					departmentName = input;
					amountOfEmployees = 0;
					var employeeEvolution = new EmployeeEvolution(departmentName, amountOfEmployees, Year);
					employeeStatisticsList.Add(employeeEvolution);
					return employeeStatisticsList[0];
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

		public EmployeeEvolution GetEmployeeEvolutionOverall(string year, string date)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append(
					$"Select COUNT(date_of_employment) as '{year}' from employeeEvolutionOverall WHERE date_of_employment < '{date}'");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var employeeStatisticsList = new List<EmployeeEvolution>();
				const string departmentName = "Overall";
				var Year = year;
				int amountOfEmployees;

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						amountOfEmployees = Convert.ToInt32(dr[year]);
						var employeeStatistics = new EmployeeEvolution(departmentName, amountOfEmployees, Year);
						employeeStatisticsList.Add(employeeStatistics);
					}

					return employeeStatisticsList[0];
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

		public List<Turnover> GetTurnover(string startDate, string endDate,string input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT product_name, Turnover, order_date from Turnover WHERE product_name = '{input}' AND order_date >= '{startDate}' AND order_date <= '{endDate}'");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var turnoverList = new List<Turnover>();
				string productName;
				int turnover;
				DateTime date;
				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						productName = dr["product_name"].ToString();
						turnover = Convert.ToInt32(dr["Turnover"]);
						date = Convert.ToDateTime(dr["order_date"]);
						var Turnover = new Turnover(productName, turnover, date);
						turnoverList.Add(Turnover);
					}

					return turnoverList;
				}
				else if (dt.Rows.Count == 0)
				{
					MessageBox.Show("No data about product");
					return turnoverList;
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
		
		public List<ProductEvolution> GetProductEvolution(int input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT quantity, date_of_procurement, product_name FROM stock JOIN products ON products.id = stock.product_id WHERE manufacturer_id = '{input}'");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var productStatisticsList = new List<ProductEvolution>();
				string productName;
				DateTime dateOfProcurement;
				int Quantity;

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						dateOfProcurement = Convert.ToDateTime(dr["date_of_procurement"]);
						Quantity = Convert.ToInt32(dr["quantity"]);
						productName = dr["product_name"].ToString();
						var productStatistics = new ProductEvolution(productName, Quantity, dateOfProcurement.Year.ToString());
						productStatisticsList.Add(productStatistics);
					}
					return productStatisticsList;
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
		public List<ProductEvolution> GetTop5ProductEvolution(int input)
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT TOP(5) quantity, date_of_procurement, product_name FROM stock JOIN products ON products.id = stock.product_id WHERE manufacturer_id = '{input}' ORDER BY quantity desc");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var productStatisticsList = new List<ProductEvolution>();
				string productName;
				DateTime dateOfProcurement;
				int Quantity;

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						dateOfProcurement = Convert.ToDateTime(dr["date_of_procurement"]);
						Quantity = Convert.ToInt32(dr["quantity"]);
						productName = dr["product_name"].ToString();
						var productStatistics = new ProductEvolution(productName, Quantity, dateOfProcurement.Year.ToString());
						productStatisticsList.Add(productStatistics);
					}
					return productStatisticsList;
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

		public List<DepartmentStatistics> GetDepartmentOverview()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"Select Sum(users) as AmountPerDepartment, dept_name From departmentOverview Group by dept_name");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var departmentOverviewList = new List<DepartmentStatistics>();
				decimal totalAmount = 0;

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						var DepartmentName = dr["dept_name"].ToString();
						var amountByDepartment = Convert.ToDecimal(dr["AmountPerDepartment"]) ;
						var departmentOverview = new DepartmentStatistics(DepartmentName, amountByDepartment);
						departmentOverviewList.Add(departmentOverview);
					}

					for (int i = 0; i < departmentOverviewList.Count; i++)
					{
						totalAmount = totalAmount + departmentOverviewList[i].AmountByDepartment;
					}
					for (int i = 0; i < departmentOverviewList.Count; i++)
					{
						departmentOverviewList[i].AmountByDepartment = Math.Round(departmentOverviewList[i].AmountByDepartment * 100 / totalAmount,2);
					}
					return departmentOverviewList;
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

		public DateTime GetFirstDateOfEmployment()
		{
			try
			{
				var sb = new StringBuilder();
				sb.Append($"SELECT MIN(date_of_employment) AS FirstEmployee FROM users");
				var sql = sb.ToString();
				var dt = SelectQuery(sql);
				var date = DateTime.Now;
				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						date = Convert.ToDateTime(dr["FirstEmployee"]);
					}
					return date;
				}
				else
				{
					throw new Exception($"Empty response, matches: {dt.Rows.Count}");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString(), "Wrong db output", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return DateTime.Now;
			}
		}
		#endregion
	}
}
