using System.Collections.Generic;

namespace MediaBazaar
{
	/// <summary>
	/// Used for TreeView
	/// </summary>
	public class UserDepartmentViewClass
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Position { get; set; }

		public int UserId { get; }

		public UserDepartmentViewClass(string firstName, string lastName, string position, int userId)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Position = position;
			this.UserId = userId;
		}
	}

	/// <summary>
	/// Used for treeview data structure
	/// </summary>
	public class DepartmentView
	{
		public string DepartmentName { get; set; }

		public int DeptId { get; set; }

		public List<UserDepartmentViewClass> Employees { get; set; }

		public DepartmentView(string departmentName, int deptId)
		{
			this.DepartmentName = departmentName;
			this.DeptId = deptId;
			this.Employees = new List<UserDepartmentViewClass>();
		}

		public DepartmentView(string departmentName, int deptId, List<UserDepartmentViewClass> employees)
		{
			this.DepartmentName = departmentName;
			this.DeptId = deptId;
			this.Employees = employees;
		}

		public void AddEmployee(string firstName, string lastName, string position, int id)
		{
			var employee = new UserDepartmentViewClass(firstName, lastName, position, id);
			this.Employees.Add(employee);
		}

		public Dictionary<string, int> NameListPerDepartment()
		{
			var employeeDict = new Dictionary<string, int>();
			foreach (var item in this.Employees)
			{
				employeeDict.Add($"{item.FirstName} {item.LastName}, {item.Position}", item.UserId);
			}

			return employeeDict;
		}

		public Dictionary<int, string> IdListPerDepartment()
		{
			var employeeDict = new Dictionary<int, string>();
			foreach (var item in this.Employees)
			{
				employeeDict.Add(item.UserId, $"{item.FirstName} {item.LastName}, {item.Position}");
			}

			return employeeDict;
		}
	}
}
