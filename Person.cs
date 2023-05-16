using System;

namespace MediaBazaar
{
	/// <summary>
	/// this class handles user data and it reflects the users table in the database
	/// there are few parameters which are read only such as:
	/// id, because it's assigned by the database and there is no reason to change it within the program
	/// DateOfBirth, for obvious reasons,
	/// and DateOfEmployment since it suppose to reflect the date of the first employment
	/// history of employment might be implemented later, since the design of the database anticipates such scenario
	/// </summary>
	public class Person
	{
		public int Id { get; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Nationality Nationality { get; set; }
		public string Email { get; set; }
		public string AddressZipCode { get; set; }
		public string AddressCity { get; set; }
		public string AddressStreet { get; set; }
		public DateTime DateOfEmployment { get; }
		public int PositionId { get; set; }
		public bool IsActive { get; set; }
		public string Login { get; set; }
		public char Gender { get; set; }
		public string Phone { get; set; }
		public int Ssn { get; set; }
		public string IceName { get; set; }
		public string IcePhone { get; set; }
		public double HourlyWage { get; set; }

		/// <summary>
		/// Constructor for the newly created users without id given by the database
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="dateOfBirth"></param>
		/// <param name="nationality"></param>
		/// <param name="email"></param>
		/// <param name="addressZipCode"></param>
		/// <param name="addressCity"></param>
		/// <param name="addressStreet"></param>
		/// <param name="dateOfEmployment"></param>
		/// <param name="positionId"></param>
		/// <param name="isActive"></param>
		/// <param name="login"></param>
		/// <param name="gender"></param>
		public Person(string firstName, string lastName, DateTime dateOfBirth, Nationality nationality, string email, string addressZipCode, string addressCity, string addressStreet, DateTime dateOfEmployment, int positionId, bool isActive, string login, char gender, string phone, int ssn, string iceName, string icePhone, double hourlyWage)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.DateOfBirth = dateOfBirth;
			this.Nationality = nationality;
			this.Email = email;
			this.AddressZipCode = addressZipCode;
			this.AddressCity = addressCity;
			this.AddressStreet = addressStreet;
			this.DateOfEmployment = dateOfEmployment;
			this.PositionId = positionId;
			this.IsActive = isActive;
			this.Login = login;
			this.Gender = gender;
			this.Phone = phone;
			this.Ssn = ssn;
			this.IceName = iceName;
			this.IcePhone = icePhone;
			this.HourlyWage = hourlyWage;
		}

		/// <summary>
		/// Constructor for the users imported from the database with given id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="dateOfBirth"></param>
		/// <param name="nationality"></param>
		/// <param name="email"></param>
		/// <param name="addressZipCode"></param>
		/// <param name="addressCity"></param>
		/// <param name="addressStreet"></param>
		/// <param name="dateOfEmployment"></param>
		/// <param name="positionId"></param>
		/// <param name="isActive"></param>
		/// <param name="login"></param>
		/// <param name="gender"></param>
		public Person(int id, string firstName, string lastName, DateTime dateOfBirth, Nationality nationality, string email, string addressZipCode, string addressCity, string addressStreet, DateTime dateOfEmployment, int positionId, bool isActive, string login, char gender, string phone, int ssn, string iceName, string icePhone, double hourlyWage)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.DateOfBirth = dateOfBirth;
			this.Nationality = nationality;
			this.Email = email;
			this.AddressZipCode = addressZipCode;
			this.AddressCity = addressCity;
			this.AddressStreet = addressStreet;
			this.DateOfEmployment = dateOfEmployment;
			this.PositionId = positionId;
			this.IsActive = isActive;
			this.Login = login;
			this.Gender = gender;
			this.Phone = phone;
			this.Ssn = ssn;
			this.IceName = iceName;
			this.IcePhone = icePhone;
			this.HourlyWage = hourlyWage;
		}

		/// <summary>
		/// simple method which returns full name of the person
		/// </summary>
		/// <returns>full name of the person</returns>
		public string GetName()
		{
			return this.FirstName + " " + this.LastName;
		}

		public string NameForPrinting()
		{
			return $"{this.FirstName} {this.LastName}, {this.Id}";
		}
	}
}
