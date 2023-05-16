namespace MediaBazaar
{
	public class CityStatistics
	{
		public string DepartmentName { get; set; }
		public string City { get; set; }
		public int AmountByCity { get; set; }

		public CityStatistics(string departmentName, string city, int amountByCity)
		{
			this.DepartmentName = departmentName;
			this.City = city;
			this.AmountByCity = amountByCity;
		}

		public CityStatistics(string city, int amountByCity)
		{
			this.City = city;
			this.AmountByCity = amountByCity;
		}
	}
}
