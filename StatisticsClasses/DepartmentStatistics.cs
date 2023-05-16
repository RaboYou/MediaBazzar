using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.StatisticsClasses
{

	public class DepartmentStatistics
	{
		public string DepartmentName { get; set; }
		public decimal AmountByDepartment { get; set; }

		public DepartmentStatistics(string departmentName, decimal amountByDepartment)
		{
			this.DepartmentName = departmentName;
			this.AmountByDepartment = amountByDepartment;
		}

	}
}
