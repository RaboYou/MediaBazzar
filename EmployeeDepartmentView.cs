using System.Collections.Generic;

namespace MediaBazaar
{
	/// <summary>
	/// Used for TreeView, contains employee first name, last name, position and user ID
	/// </summary>
	public class EmployeeDepartmentView
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Position { get; set; }
		public int UserId { get; }
		public int PartTimeFactor { get; set; }
		public Dictionary<int, bool> IsFullyPlanned { get; set; }

		/// <summary>
		/// Constructor for employee entry
		/// </summary>
		/// <param name="firstName">Employee first name</param>
		/// <param name="lastName">Employee last name</param>
		/// <param name="position">Employee position</param>
		/// <param name="userId">Employee ID the as it is in the database</param>
		/// <param name="partTimeFactor">Employee work time</param>
		public EmployeeDepartmentView(string firstName, string lastName, string position, int userId, int partTimeFactor)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Position = position;
			this.UserId = userId;
			this.PartTimeFactor = partTimeFactor;
			this.IsFullyPlanned = new Dictionary<int, bool>();
		}

		/// <summary>
		/// This method keeps consisted naming between dictionaries and database
		/// </summary>
		/// <returns>string with following First name last name, position</returns>
		public string NameForPrinting()
		{
			return $"{this.FirstName} {this.LastName}, {this.Position}";
		}
	}
}
