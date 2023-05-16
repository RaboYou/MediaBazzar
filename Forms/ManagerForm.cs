using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using MediaBazzar.StatisticsClasses;

namespace MediaBazaar
{
	public partial class ManagerForm : Form
	{
		private SQLConStatisticsHandling con = new SQLConStatisticsHandling();
		private SQLConProductHandling conProducts = new SQLConProductHandling();
		private Dictionary<string, int> departmentNameToId = new Dictionary<string, int>();
		private Dictionary<string, int> translatorFromNameToId;
		private List<Product> allProducts;
		private Dictionary<string, string> evolutionYear = new Dictionary<string, string>();
		private List<DepartmentView> departmentViews = new List<DepartmentView>();

		public ManagerForm()
		{
			InitializeComponent();
			PopulateEmployeeListBoxes();
			PopulateProductsListBoxes();
			PopulateEvolutionDictionary();
			GraphFont();
		}

		private void PopulateEmployeeListBoxes()
		{

			lbDepartmentAge.Items.Clear();
			departmentNameToId.Clear();
			departmentViews = con.GetDepartmentViewsForStatistics();

			foreach (var item in departmentViews)
			{
				lbDepartmentAge.Items.Add(item.DepartmentName);
				lbDepartmentCity.Items.Add(item.DepartmentName);
				lbDepartmentGender.Items.Add(item.DepartmentName);
				lbDepartmentNationality.Items.Add(item.DepartmentName);
				lbEvolutionOfEmployees.Items.Add(item.DepartmentName);
				departmentNameToId.Add(item.DepartmentName, item.DeptId);
			}
			lbDepartmentAge.Items.Add("Overall");
			lbDepartmentCity.Items.Add("Overall");
			lbDepartmentGender.Items.Add("Overall");
			lbDepartmentNationality.Items.Add("Overall");
			lbEvolutionOfEmployees.Items.Add("Overall");
			lbDepartmentOverview.Items.Add("Overall");
		}
		private void PopulateProductsListBoxes()
		{
			allProducts = conProducts.GetAllProducts();
			translatorFromNameToId = new Dictionary<string, int>();
			lbProductsPopularity.Items.Clear();
			lbProductsTurnover.Items.Clear();
			foreach (Product product in allProducts)
			{
				translatorFromNameToId.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}", product.Id);
				lbProductsPopularity.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
				lbProductsTurnover.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
				lbProductEvolution.Items.Add($"{product.ManufacturerName} {product.ProductName}, {product.Id}");
			}
		}
		private void PopulateEvolutionDictionary()
		{
			DateTime firstdate = con.GetFirstDateOfEmployment();
			int diff = DateTime.Now.Year - firstdate.Year;

			for (int i = 0; i <= diff; i++)
			{
				DateTime date = new DateTime(firstdate.Year + i, 1, 1);
				DateTime filterdate = date.AddYears(1);
				evolutionYear.Add(date.Year.ToString(), filterdate.ToString("u").Substring(0, 10));
			}
		}
		private void lbDepartmentAge_SelectedIndexChanged(object sender, EventArgs e)
		{

			List<AgeStatistics> ageStatisticsList = new List<AgeStatistics>();
			ageStatisticsList.Clear();
			lblCityDepartment.Visible = false;
			ChartEmployee.Visible = true;
			ChartCity.Visible = false;
			ChartEmployee.Series.Clear();
			ChartEmployee.Titles.Clear();
			ChartEmployee.ChartAreas[0].RecalculateAxesScale();
			ChartEmployee.Titles.Add(GraphTitle("Age Distribution Chart"));
			ChartEmployee.ChartAreas[0].AxisX.Title = "Age of employee";
			ChartEmployee.ChartAreas[0].AxisY.Title = "Amount of employees";


			if (lbDepartmentAge.SelectedItem.ToString() == "Overall")
			{
				ageStatisticsList = con.GetAgeStatisticsOverall();
			}
			else
			{
				ageStatisticsList = con.GetAgeStatistics(lbDepartmentAge.SelectedItem.ToString());
			}

			foreach (var item in ageStatisticsList)
			{
				if (ChartEmployee.Series.FindByName(item.DepartmentName) is null)
				{
					ChartEmployee.Series.Add(item.DepartmentName);
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Age, item.AmountByAge);

				}
				else
				{
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Age, item.AmountByAge);

				}
			}
		}
		private void lbDepartmentGender_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<GenderStatistics> genderStatisticsList = new List<GenderStatistics>();
			ChartEmployee.Visible = true;
			ChartCity.Visible = false;
			lblCityDepartment.Visible = false;
			genderStatisticsList.Clear();
			ChartEmployee.Series.Clear();
			ChartEmployee.Titles.Clear();
			ChartEmployee.ChartAreas[0].RecalculateAxesScale();
			ChartEmployee.Titles.Add(GraphTitle("Gender Distribution Chart"));
			ChartEmployee.ChartAreas[0].AxisX.Title = "Gender";
			ChartEmployee.ChartAreas[0].AxisY.Title = "Amount of employees";


			if (lbDepartmentGender.SelectedItem.ToString() == "Overall")
			{
				genderStatisticsList = con.GetGenderStatisticsOverall();
			}
			else
			{
				genderStatisticsList = con.GetGenderStatistics(lbDepartmentGender.SelectedItem.ToString());
			}

			foreach (var item in genderStatisticsList)
			{
				if (ChartEmployee.Series.FindByName(item.DepartmentName) is null)
				{
					ChartEmployee.Series.Add(item.DepartmentName);
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Gender, item.AmountByGender);
				}
				else
				{
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Gender, item.AmountByGender);
				}
			}
		}
		private void lbDepartmentNationality_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<NationalityStatistics> nationalityStatisticsList = new List<NationalityStatistics>();
			ChartEmployee.Visible = true;
			ChartCity.Visible = false;
			lblCityDepartment.Visible = false;
			nationalityStatisticsList.Clear();
			ChartEmployee.Series.Clear();
			ChartEmployee.Titles.Clear();
			ChartEmployee.ChartAreas[0].RecalculateAxesScale();
			ChartEmployee.Titles.Add(GraphTitle("Nationality Distribution Chart"));
			ChartEmployee.ChartAreas[0].AxisX.Title = "Nationality";
			ChartEmployee.ChartAreas[0].AxisY.Title = "Amount of employees";

			if (lbDepartmentNationality.SelectedItem.ToString() == "Overall")
			{
				nationalityStatisticsList = con.GetNationalityStatisticsOverall();
			}
			else
			{
				nationalityStatisticsList = con.GetNationalityStatistics(lbDepartmentNationality.SelectedItem.ToString());
			}

			foreach (var item in nationalityStatisticsList)
			{
				if (ChartEmployee.Series.FindByName(item.DepartmentName) is null)
				{
					ChartEmployee.Series.Add(item.DepartmentName);
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Nationality, item.AmountByNationality);
				}
				else
				{
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Nationality, item.AmountByNationality);
				}
			}
		}
		private void lbDepartmentCity_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<CityStatistics> cityStatisticsList = new List<CityStatistics>();
			ChartCity.Series.Clear();
			ChartCity.Titles.Clear();

			lblCityDepartment.Visible = true;
			ChartEmployee.Visible = false;
			ChartCity.Visible = true;
			ChartCity.Titles.Add(GraphTitle("City Distribution Chart"));



			if (lbDepartmentCity.SelectedItem.ToString() == "Overall")
			{
				cityStatisticsList = con.GetCityStatisticsOverall();
				lblCityDepartment.Text = "Overall";

			}
			else
			{
				cityStatisticsList = con.GetCityStatistics(lbDepartmentCity.SelectedItem.ToString());
				lblCityDepartment.Text = lbDepartmentCity.SelectedItem.ToString();

			}

			foreach (var item in cityStatisticsList)
			{
				if (ChartCity.Series.FindByName(item.DepartmentName) is null)
				{
					ChartCity.Series.Add(item.DepartmentName);
					ChartCity.Series[item.DepartmentName].Points.AddXY(item.City, item.AmountByCity);
					ChartCity.Series[item.DepartmentName].ChartType = SeriesChartType.Pie;
					ChartCity.Series[item.DepartmentName].IsValueShownAsLabel = true;

				}
				else
				{
					ChartCity.Series[item.DepartmentName].Points.AddXY(item.City, item.AmountByCity);
					ChartCity.Series[item.DepartmentName].ChartType = SeriesChartType.Pie;
					ChartCity.Series[item.DepartmentName].IsValueShownAsLabel = true;

				}
			}
		}
		private void lbEvolutionofEmployees_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<EmployeeEvolution> employeeEvolutionList = new List<EmployeeEvolution>();
			ChartEmployee.Visible = true;
			ChartCity.Visible = false;
			lblCityDepartment.Visible = false;
			ChartEmployee.Series.Clear();
			ChartEmployee.Titles.Clear();
			ChartEmployee.ChartAreas[0].RecalculateAxesScale();
			ChartEmployee.Titles.Add(GraphTitle("Employee Evolution Chart"));
			ChartEmployee.ChartAreas[0].AxisX.Title = "Year";
			ChartEmployee.ChartAreas[0].AxisY.Title = "Amount of employees";

			if (lbEvolutionOfEmployees.SelectedItem.ToString() == "Overall")
			{
				foreach (var item in evolutionYear)
				{
					employeeEvolutionList.Add(con.GetEmployeeEvolutionOverall(item.Key, item.Value));
				}
			}
			else
			{
				foreach (var item in evolutionYear)
				{
					EmployeeEvolution itemToAdd = con.GetEmployeeEvolution(item.Key, item.Value, lbEvolutionOfEmployees.SelectedItem.ToString());
					if (itemToAdd.AmountOfEmployees > 1)
					{
						employeeEvolutionList.Add(itemToAdd);
					}
				}
			}

			foreach (var item in employeeEvolutionList)
			{
				if (ChartEmployee.Series.FindByName(item.DepartmentName) is null)
				{
					ChartEmployee.Series.Add(item.DepartmentName);
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Year, item.AmountOfEmployees);
				}
				else
				{
					ChartEmployee.Series[item.DepartmentName].Points.AddXY(item.Year, item.AmountOfEmployees);
				}
			}
			employeeEvolutionList.Clear();
		}

		private void lbDepartmentOverview_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<DepartmentStatistics> departmentOverviewList = new List<DepartmentStatistics>();
			ChartCity.Series.Clear();
			ChartCity.Titles.Clear();
			lblCityDepartment.Visible = true;
			lblCityDepartment.Text = "All values are shown in [%]";
			ChartEmployee.Visible = false;
			ChartCity.Visible = true;
			ChartCity.Titles.Add(GraphTitle("Department Overview Chart"));
			ChartCity.Series.Add(0.ToString());
			ChartCity.Series[0].ChartType = SeriesChartType.Pie;
			ChartCity.Series[0].IsValueShownAsLabel = true;
			departmentOverviewList = con.GetDepartmentOverview();

			foreach (var item in departmentOverviewList)
			{
				ChartCity.Series[0].Points.AddXY(item.DepartmentName, item.AmountByDepartment);
			}


		}
		private void lbProductsPopularity_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<ProductPopularity> productPopularityList = new List<ProductPopularity>();
			ChartEmployee.Visible = true;
			ChartCity.Visible = false;
			lblCityDepartment.Visible = false;
			productPopularityList.Clear();
			ChartPopularity.Series.Clear();
			ChartPopularity.Titles.Clear();
			ChartPopularity.ChartAreas[0].RecalculateAxesScale();
			ChartPopularity.Titles.Add(GraphTitle("Product popularity Chart"));
			ChartPopularity.ChartAreas[0].AxisY.Title = "Amount of product sold";
			//ChartPopularity.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
			Product selectedProduct = null;

			foreach (var item in allProducts)
			{
				if (item.Id == translatorFromNameToId[lbProductsPopularity.SelectedItem.ToString()])
				{
					selectedProduct = item;
				}
			}

			productPopularityList = con.GetProductPopularity(dateTimePickerPopularityStart.Value.Date.ToString("u").Remove(10), dateTimePickerPopularityEnd.Value.Date.ToString("u").Remove(10), selectedProduct.ProductName);

			if (productPopularityList != null)
			{
				foreach (var item in productPopularityList)
				{
					if (ChartPopularity.Series.FindByName(item.ProductName) is null)
					{
						ChartPopularity.Series.Add(item.ProductName);
						ChartPopularity.Series[item.ProductName].Points.AddXY(item.Date.ToString("Y"), item.Quantity);
					}
					else
					{
						ChartPopularity.Series[item.ProductName].Points.AddXY(item.Date.ToString("Y"), item.Quantity);
					}
				}
			}
		}
		private void lbProductsTurnover_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Turnover> turnoverList = new List<Turnover>();
			turnoverList.Clear();
			ChartTurnover.Series.Clear();
			ChartTurnover.Titles.Clear();
			lblCityDepartment.Visible = false;
			ChartTurnover.ChartAreas[0].RecalculateAxesScale();
			ChartTurnover.Titles.Add(GraphTitle("Turnover Chart"));
			ChartTurnover.ChartAreas[0].AxisX.Title = "Product";
			ChartTurnover.ChartAreas[0].AxisY.Title = "Turnover[$]";
			//ChartTurnover.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
			Product selectedProduct = null;

			foreach (var item in allProducts)
			{
				if (item.Id == translatorFromNameToId[lbProductsTurnover.SelectedItem.ToString()])
				{
					selectedProduct = item;
				}
			}
			turnoverList = con.GetTurnover(dateTimePickerTurnoverStartDate.Value.Date.ToString("u").Remove(10), dateTimePickerTurnoverEndDate.Value.Date.ToString("u").Remove(10), selectedProduct.ProductName);

			if (turnoverList != null)
			{
				foreach (var item in turnoverList)
				{
					if (ChartTurnover.Series.FindByName(item.ProductName) is null)
					{
						ChartTurnover.Series.Add(item.ProductName);
						ChartTurnover.Series[item.ProductName].Points.AddXY(item.Date.ToString("Y"), item.TurnoverAmount);
					}
					else
					{
						ChartTurnover.Series[item.ProductName].Points.AddXY(item.Date.ToString("Y"), item.TurnoverAmount);
					}
				}
			}
		}
		private void lbProductEvolution_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<ProductEvolution> productEvolutionList = new List<ProductEvolution>();
			ChartProductEvolution.Series.Clear();
			ChartProductEvolution.Titles.Clear();
			btnTop5.Visible = true;
			lblCityDepartment.Visible = false;
			ChartProductEvolution.ChartAreas[0].RecalculateAxesScale();
			ChartProductEvolution.Titles.Add(GraphTitle("Product Evolution Chart"));
			ChartProductEvolution.ChartAreas[0].AxisX.Title = "Year";
			ChartProductEvolution.ChartAreas[0].AxisY.Title = "Amount of product in stock";
			ChartProductEvolution.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
			Product selectedProduct = null;
			foreach (var item in allProducts)
			{
				if (item.Id == translatorFromNameToId[lbProductEvolution.SelectedItem.ToString()])
				{
					selectedProduct = item;
				}

			}
			productEvolutionList = con.GetProductEvolution(selectedProduct.ManufacturerId);

			if (productEvolutionList != null)
			{
				foreach (var item in productEvolutionList)
				{
					if (ChartProductEvolution.Series.FindByName(item.ProductName) is null)
					{
						ChartProductEvolution.Series.Add(item.ProductName);
						ChartProductEvolution.Series[item.ProductName].Points.AddXY(item.Year, item.Quantity);
					}
					else if (ChartProductEvolution.Series.Contains(ChartProductEvolution.Series.FindByName(item.ProductName)) == false)
					{
						MessageBox.Show("No data about product");
					}

				}
				productEvolutionList.Clear();
			}
		}
		private void btnTop5_Click(object sender, EventArgs e)
		{
			List<ProductEvolution> productEvolutionList = new List<ProductEvolution>();
			ChartProductEvolution.Series.Clear();
			ChartProductEvolution.ChartAreas[0].RecalculateAxesScale();

			Product selectedProduct = null;
			foreach (var item in allProducts)
			{
				if (item.Id == translatorFromNameToId[lbProductEvolution.SelectedItem.ToString()])
				{
					selectedProduct = item;
				}

			}
			productEvolutionList = con.GetTop5ProductEvolution(selectedProduct.ManufacturerId);

			if (productEvolutionList != null)
			{
				foreach (var item in productEvolutionList)
				{
					if (ChartProductEvolution.Series.FindByName(item.ProductName) is null)
					{
						ChartProductEvolution.Series.Add(item.ProductName);
						ChartProductEvolution.Series[item.ProductName].Points.AddXY(item.Year, item.Quantity);
					}
					else if (ChartProductEvolution.Series.Contains(ChartProductEvolution.Series.FindByName(item.ProductName)) == false)
					{
						MessageBox.Show("No data about product");
					}

				}
				productEvolutionList.Clear();
			}
		}

		private Title GraphTitle(string title)
		{
			var chartTitle = new Title(title, 0, new Font("Arial", 16), Color.FromName("Black"));
			return chartTitle;
		}
		private void GraphFont()
		{
			var axisFont = new Font("Arial", 14);
			ChartEmployee.ChartAreas[0].AxisX.TitleFont = axisFont;
			ChartEmployee.ChartAreas[0].AxisY.TitleFont = axisFont;
			ChartProductEvolution.ChartAreas[0].AxisY.TitleFont = axisFont;
			ChartProductEvolution.ChartAreas[0].AxisX.TitleFont = axisFont;
			ChartPopularity.ChartAreas[0].AxisY.TitleFont = axisFont;
			ChartPopularity.ChartAreas[0].AxisX.TitleFont = axisFont;
			ChartTurnover.ChartAreas[0].AxisY.TitleFont = axisFont;
			ChartTurnover.ChartAreas[0].AxisX.TitleFont = axisFont;
		}


	}
}

