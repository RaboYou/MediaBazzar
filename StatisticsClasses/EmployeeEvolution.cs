namespace MediaBazaar
{
	public class EmployeeEvolution
	{
		public string DepartmentName { get; set; }
		public int AmountOfEmployees { get; set; }

		public string Year { get; set; }

		public EmployeeEvolution(string departmentName, int amountOfEmployees, string year)
		{
			this.DepartmentName = departmentName;
			this.AmountOfEmployees = amountOfEmployees;
			this.Year = year;
		}
	}
}
