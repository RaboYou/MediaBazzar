namespace MediaBazaar
{
	public class GenderStatistics
	{
		public string DepartmentName { get; set; }
		public string Gender { get; set; }
		public int AmountByGender { get; set; }

		public GenderStatistics(string departmentName, string gender, int amountByGender)
		{
			this.DepartmentName = departmentName;
			this.Gender = gender;
			this.AmountByGender = amountByGender;
		}

		public GenderStatistics(string gender, int amountByGender)
		{
			this.Gender = gender;
			this.AmountByGender = amountByGender;
		}
	}
}
