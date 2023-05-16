namespace MediaBazaar
{
	public class NationalityStatistics
	{
		public string DepartmentName { get; set; }
		public string Nationality { get; set; }
		public int AmountByNationality { get; set; }

		public NationalityStatistics(string departmentName, string nationality, int amountByNationality)
		{
			this.DepartmentName = departmentName;
			this.Nationality = nationality;
			this.AmountByNationality = amountByNationality;
		}
	}
}