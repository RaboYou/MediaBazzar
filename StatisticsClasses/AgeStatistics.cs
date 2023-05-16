namespace MediaBazaar
{
	public class AgeStatistics
	{
		public string DepartmentName { get; set; }
		public int Age { get; set; }
		public int AmountByAge { get; set; }

		public AgeStatistics(string departmentName, int age, int amountByAge)
		{
			this.DepartmentName = departmentName;
			this.Age = age;
			this.AmountByAge = amountByAge;
		}

		public AgeStatistics(int age, int amountByAge)
		{
			this.Age = age;
			this.AmountByAge = amountByAge;
		}
	}
}
