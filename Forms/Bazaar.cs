using MediaBazzar;
using MediaBazzar.EmployeeChanges;
using MediaBazzar.Forms;
using MediaBazzar.ShiftCheckers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediaBazaar
{
	public partial class Bazaar : Form
	{
		private SQLConPersonHandling con = new SQLConPersonHandling();
		private SQLConChangeRequestHandling conCR = new SQLConChangeRequestHandling();
		private Person person;
		private WorkshiftManager manager = new WorkshiftManager();
		private ShiftPersonManager spmanager = new ShiftPersonManager();
		private ChangeRequestManager crmanager;
		private Dictionary<string, int> translatorFromNameToId;
		private List<Person> persons = new List<Person>();
		private int selectedYearWeekNumber;
		private int selectedWeekNumber;
		private int selectedYearNumber;
		private List<ListBox> allWorkshiftBoxes;

		public Bazaar(Person personFromLogin)
		{
			InitializeComponent();
			allWorkshiftBoxes = ListWorkshiftListBoxes();
			PopulateTreeview();
			manager.LoadAllWorkshifts();

			person = personFromLogin;
			userNameLabel.Text = person.GetName();

			if (conCR.GetAllChangeRequests(con.GetAllPersons()) != null)
			{
				crmanager = new ChangeRequestManager(conCR.GetAllChangeRequests(con.GetAllPersons()));
			}
			else
			{
				crmanager = new ChangeRequestManager();
			}

			dtpCurrentDateOfBirth.Format = DateTimePickerFormat.Custom;
			dtpChangedDateOfBirth.Format = DateTimePickerFormat.Custom;
			dtpCurrentDateOfBirth.CustomFormat = "dd/MM/yyyy";
			dtpChangedDateOfBirth.CustomFormat = "dd/MM/yyyy";
			LoadChangeRequests();

			selectedWeekNumber = DateTools.DateToWeekNumber(DateTime.Now);
			selectedYearNumber = DateTime.Now.Year;
			selectedYearWeekNumber = selectedWeekNumber;
			lblWeekNumber.Text = $"{selectedWeekNumber}";
			lblYearNumber.Text = $"{selectedYearNumber}";
			//currentDeptView = departmentViews[1].DeptId;
			nudCopyWeek.Value = selectedWeekNumber;


			foreach (var nat in Enum.GetNames(typeof(Nationality)))
			{
				cbNationality.Items.Add(nat);
			}
			LoadDepartments();
			LoadEmployeeCombobox();
		}

		private List<ListBox> ListWorkshiftListBoxes()
		{
			List<ListBox> lists = new List<ListBox>();
			lists.Add(lbMondayMorning);
			lists.Add(lbMondayAfternoon);
			lists.Add(lbMondayEvening);

			lists.Add(lbTuesdayMorning);
			lists.Add(lbTuesdayAfternoon);
			lists.Add(lbTuesdayEvening);

			lists.Add(lbWednesdayMorning);
			lists.Add(lbWednesdayAfternoon);
			lists.Add(lbWednesdayEvening);

			lists.Add(lbThursdayMorning);
			lists.Add(lbThursdayAfternoon);
			lists.Add(lbThursdayEvening);

			lists.Add(lbFridayMorning);
			lists.Add(lbFridayAfternoon);
			lists.Add(lbFridayEvening);

			lists.Add(lbSaturdayMorning);
			lists.Add(lbSaturdayAfternoon);
			lists.Add(lbSaturdayEvening);

			lists.Add(lbSundayMorning);
			lists.Add(lbSundayAfternoon);
			lists.Add(lbSundayEvening);

			return lists;
		}

		#region UserHandlerTab

		private void BtnCreateUserClick(object sender, EventArgs e)
		{
			var valid = true;
			var status = "";
			if (tbFirstName.Text.Equals("") || tbLastName.Text.Equals("") || cbNationality.SelectedItem == null || tbEmail.Text.Equals("") || tbAddress.Text.Equals("") || tbZipCode.Text.Equals("") || tbCity.Text.Equals("") || cbPositions.SelectedItem == null || cbGender.SelectedItem == null || tbSSN.Text.Equals("") || tbIceName.Text.Equals("") || tbIceNumber.Text.Equals("") || tbHourlyWage.Text.Equals("") || tbPassword.Text.Equals(""))
			{
				status += "- One or more of the fields are empty\n\n";
				valid = false;
			}
			if (!Regex.IsMatch(tbFirstName.Text, @"^[a-zA-Z]+$"))
			{
				status += "- First name only accepts alphabetical characters.\n\n";
				valid = false;
			}
			if (!Regex.IsMatch(tbLastName.Text, @"^[a-zA-Z]+$"))
			{
				status += "- Last name only accepts alphabetical characters.\n\n";
				valid = false;
			}
			if (!Regex.IsMatch(tbHourlyWage.Text, @"^\d+([,.][\d][\d])?$"))
			{
				status += "- Hourly wage must be a number\n\n";
				valid = false;
			}
			else if (Regex.IsMatch(tbHourlyWage.Text, @"[.]"))
			{
				status += "- Hourly wage uses a comma, not a dot. Ex: 5,12\n\n";
				valid = false;
			}
			if (!Regex.IsMatch(tbEmail.Text, @"@\w+[.]+\w+"))
			{
				status += "- Email is not valid\n\n";
				valid = false;
			}
			if (!Regex.IsMatch(tbZipCode.Text, @"^\d{4}[A-Z]{2}$"))
			{
				if (tbZipCode.Text.Equals(""))
				{
					status += "- Zipcode is not a valid format: \n\tFormat: 1234AB\n\tInput: Empty";
				}
				else
				{
					status += "- Zipcode is not a valid format: \n\tFormat: 1234AB\n\tInput: " + tbZipCode.Text + "";
				}
				valid = false;
			}
			if (valid)
			{
				var login = tbFirstName.Text.Substring(0, 3).ToLower() + tbLastName.Text.Substring(0, 3).ToLower();
				Enum.TryParse(cbNationality.SelectedItem.ToString(), out Nationality nat);
				if (!con.CheckAccount(login))
				{
					var newPerson = new Person(tbFirstName.Text, tbLastName.Text, birthDatePicker.Value, nat, tbEmail.Text, tbZipCode.Text, tbCity.Text, tbAddress.Text, DateTime.Now, con.GetPosition(cbPositions.Text), true, login, Convert.ToChar(cbGender.Text), tbPhone.Text, Convert.ToInt32(tbSSN.Text), tbIceName.Text, tbIceNumber.Text, Convert.ToDouble(tbHourlyWage.Text));
					con.CreatePerson(newPerson, tbPassword.Text);
					UpdateList();
				}
			}
			else
			{
				MessageBox.Show(status, "There are one or more issues with the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LbEmployeesSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbEmployees.SelectedItem.Equals(null)) { }
			else
			{
				birthDatePicker.CustomFormat = "dd/MM/yyyy";

				var selectedPerson = SearchSelectedPerson();
				UpdateInfo(selectedPerson);
			}
		}

		public void UpdateInfo(Person selectedPerson)
		{
			tbFirstName.Text = selectedPerson.FirstName;
			tbLastName.Text = selectedPerson.LastName;
			cbNationality.Text = selectedPerson.Nationality.ToString();
			birthDatePicker.Value = selectedPerson.DateOfBirth;
			tbEmail.Text = selectedPerson.Email;
			tbAddress.Text = selectedPerson.AddressStreet;
			tbCity.Text = selectedPerson.AddressCity;
			tbZipCode.Text = selectedPerson.AddressZipCode;
			tbStatus.Text = selectedPerson.IsActive.ToString();
			tbPhone.Text = selectedPerson.Phone;
			tbHourlyWage.Text = selectedPerson.HourlyWage.ToString();
			tbIceName.Text = selectedPerson.IceName;
			tbIceNumber.Text = selectedPerson.IcePhone;
			tbSSN.Text = selectedPerson.Ssn.ToString();
			switch (selectedPerson.Gender.ToString())
			{
				case "M":
					cbGender.SelectedIndex = 0;
					break;
				case "F":
					cbGender.SelectedIndex = 1;
					break;
				case "N":
					cbGender.SelectedIndex = 2;
					break;
				default:
					break;
			}
			lblSelectedEmpName.Text = selectedPerson.FirstName + " " + selectedPerson.LastName;
		}

		private void Bazaar_Load(object sender, EventArgs e)
		{
			birthDatePicker.Format = DateTimePickerFormat.Custom;
			birthDatePicker.CustomFormat = "dd/MM/yyyy";

			cbPositions.SelectedIndex = 0;

			translatorFromNameToId = new Dictionary<string, int>();
			UpdateList();
		}

		private void BtnSearchEmployeeClick(object sender, EventArgs e)
		{
			lbEmployees.Items.Clear();
			if (con.SearchPersons(tbSearch.Text) != null)
			{
				translatorFromNameToId.Clear();
				foreach (var result in con.SearchPersons(tbSearch.Text))
				{
					translatorFromNameToId.Add(result.NameForPrinting(), result.Id);
					lbEmployees.Items.Add(result.NameForPrinting());
				}
			}
			else
			{
				lbEmployees.Items.Add("No employees found with that name");
			}
		}

		private void BtnUpdateClick(object sender, EventArgs e)
		{
			try
			{
				var valid = true;
				var status = "";
				if (tbFirstName.Text.Equals("") || tbLastName.Text.Equals("") || cbNationality.SelectedItem == null || tbEmail.Text.Equals("") || tbAddress.Text.Equals("") || tbZipCode.Text.Equals("") || tbCity.Text.Equals("") || cbGender.SelectedItem == null || tbSSN.Text.Equals("") || tbIceName.Text.Equals("") || tbIceNumber.Text.Equals("") || tbHourlyWage.Text.Equals(""))
				{
					status += "- One or more of the fields are empty\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbFirstName.Text, @"^[a-zA-Z ]+$"))
				{
					status += "- First name only accepts alphabetical characters.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbLastName.Text, @"^[a-zA-Z ]+$"))
				{
					status += "- Last name only accepts alphabetical characters.\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbHourlyWage.Text, @"^\d+([,.][\d][\d])?$"))
				{
					status += "- Hourly wage must be a number\n\n";
					valid = false;
				}
				else if (Regex.IsMatch(tbHourlyWage.Text, @"[.]"))
				{
					status += "- Hourly wage uses a comma, not a dot. Ex: 5,12\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbEmail.Text, @"@\w+[.]+\w+"))
				{
					status += "- Email is not valid\n\n";
					valid = false;
				}
				if (!Regex.IsMatch(tbZipCode.Text, @"^\d{4}[A-Z]{2}$"))
				{
					if (tbZipCode.Text.Equals(""))
					{
						status += "- Zipcode is not a valid format: \n\tFormat: 1234AB\n\tInput: Empty";
					}
					else
					{
						status += "- Zipcode is not a valid format: \n\tFormat: 1234AB\n\tInput: " + tbZipCode.Text + "";
					}
					valid = false;
				}
				if (valid)
				{
					var name = lblSelectedEmpName.Text.Split(' ');
					var login = name[0].Substring(0, 3).ToLower() + name[1].Substring(0, 3).ToLower();
					var toEdit = con.GetPerson(login);
					Enum.TryParse(cbNationality.SelectedItem.ToString(), out Nationality nat);
					var isActive = Convert.ToBoolean(tbStatus.Text);
					var edited = new Person(tbFirstName.Text, tbLastName.Text, DateTime.Parse(birthDatePicker.Text), nat, tbEmail.Text, tbZipCode.Text, tbCity.Text, tbAddress.Text, toEdit.DateOfEmployment, toEdit.PositionId, isActive, login, Convert.ToChar(cbGender.Text), tbPhone.Text, Convert.ToInt32(tbSSN.Text), tbIceName.Text, tbIceNumber.Text, Convert.ToDouble(tbHourlyWage.Text));
					con.UpdatePerson(edited, toEdit.Id);
					UpdateList();
				}
				else
				{
					MessageBox.Show(status, "There are one or more issues with the input", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (ArgumentNullException ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void UpdateList()
		{
			lbEmployees.Items.Clear();
			persons = con.GetAllPersons();
			translatorFromNameToId.Clear();
			foreach (var person in persons)
			{
				translatorFromNameToId.Add(person.NameForPrinting(), person.Id);
				lbEmployees.Items.Add(person.NameForPrinting());
			}
		}

		private void BtnSetInactiveClick(object sender, EventArgs e)
		{
			var selectedPerson = SearchSelectedPerson();
			var changeStatus = new FireForm(selectedPerson);
			changeStatus.ShowDialog();
			UpdateInfo(selectedPerson);
		}

		public Person SearchSelectedPerson()
		{
			foreach (var person in persons)
			{
				if (person.Id == translatorFromNameToId[lbEmployees.SelectedItem.ToString()])
				{
					return person;
				}
			}
			return null;
		}

		private void BtnSetActiveClick(object sender, EventArgs e)
		{
			var selectedPerson = SearchSelectedPerson();
			if (!selectedPerson.IsActive)
			{
				selectedPerson.IsActive = true;
				con.ActivatePerson(selectedPerson);
				tbStatus.Text = "True";
				MessageBox.Show("Employee " + selectedPerson.FirstName + " " + selectedPerson.LastName + " has been set to active.");
			}
			else
			{
				MessageBox.Show("Nothing to change. Employee is already active.");
			}
		}

		#endregion

		#region Workshifts


		private void PopulateTreeview()
		{
			shiftworkersTreeView.BeginUpdate();
			shiftworkersTreeView.Nodes.Clear();

			shiftworkersTreeView.Nodes.Add("Management");
			shiftworkersTreeView.Nodes.Add("Legal");
			shiftworkersTreeView.Nodes.Add("Support");
			shiftworkersTreeView.Nodes.Add("Sales");

			foreach (ShiftPerson person in spmanager.Persons)
			{
				for (int i = 0; i < shiftworkersTreeView.Nodes.Count; i++)
				{
					var view = shiftworkersTreeView.Nodes[i];
					if (view.ToString().Contains(person.Department))
					{
						view.Nodes.Add(person.FirstName + " " + person.LastName);
						foreach (TreeNode node in view.Nodes)
						{
							node.ContextMenuStrip = nodeContextMenu;
						}
					}
				}
			}
			shiftworkersTreeView.EndUpdate();
			shiftworkersTreeView.ExpandAll();
		}

		private void FillWorkshiftBoxes()
		{
			if (ckbEmployeeToggle.Checked)
			{
				FillWorkshiftBoxesByEmployee();
			}
			else
			{
				ClearWorkshiftBoxes();
				LoadLabels();
				LoadWorkshifts(GetDepartmentWorkshifts());
			}
		}

		private List<Workshift> GetDepartmentWorkshifts()
		{
			string department;
			if (cbDepartment.SelectedIndex < 0)
			{
				department = "Management";
			}
			else
			{
				department = cbDepartment.SelectedItem.ToString();
			}

			switch (department)
			{
				case "Management":
				default:
					return manager.Management;
				case "Legal":
					return manager.Legal;
				case "Support":
					return manager.Support;
				case "Sales":
					return manager.Sales;
			}
		}

		public void LoadWorkshifts(List<Workshift> workshifts)
		{
			foreach (Workshift workshift in workshifts)
			{
				int day = 0;
				int type = 0;
				DateTime firstDayOfWeek = manager.GetFirstDayOfWeek(selectedWeekNumber);
				for (int i = 0; i < 7; i++)
				{
					DateTime dayOfWeek = firstDayOfWeek.AddDays(i);

					if (workshift.Date == dayOfWeek)
					{
						switch (workshift.Date.DayOfWeek)
						{
							case DayOfWeek.Monday:
								day = 0;
								break;
							case DayOfWeek.Tuesday:
								day = 3;
								break;
							case DayOfWeek.Wednesday:
								day = 6;
								break;
							case DayOfWeek.Thursday:
								day = 9;
								break;
							case DayOfWeek.Friday:
								day = 12;
								break;
							case DayOfWeek.Saturday:
								day = 15;
								break;
							case DayOfWeek.Sunday:
								day = 18;
								break;
						}

						switch (workshift.Type)
						{
							case ShiftType.Morning:
								type = 0;
								break;
							case ShiftType.Afternoon:
								type = 1;
								break;
							case ShiftType.Evening:
								type = 2;
								break;
						}

						if (workshift.Persons.Count <= 4)
						{
							foreach (ShiftPerson person in workshift.Persons)
							{
								allWorkshiftBoxes[day + type].Items.Add(person.FirstName + " " + person.LastName);
							}
						}
						else
						{
							allWorkshiftBoxes[day + type].Items.Add($"Assigned: {workshift.Persons.Count}");
							allWorkshiftBoxes[day + type].Items.Add($"Maximum: {workshift.MaxAmount}");
						}
					}
				}
			}
		}

		public void LoadLabels()
		{
			lblWeekNumber.Text = selectedYearWeekNumber.ToString();
			lblYearNumber.Text = selectedYearNumber.ToString();
			DateTime firstDay = manager.GetFirstDayOfWeek(selectedWeekNumber);
			lblMonday.Text = "Monday\n" + firstDay.ToShortDateString();
			lblTuesday.Text = "Tuesday\n" + firstDay.AddDays(1).ToShortDateString();
			lblWednesday.Text = "Wednesday\n" + firstDay.AddDays(2).ToShortDateString();
			lblThursday.Text = "Thursday\n" + firstDay.AddDays(3).ToShortDateString();
			lblFriday.Text = "Friday\n" + firstDay.AddDays(4).ToShortDateString();
			lblSaturday.Text = "Saturday\n" + firstDay.AddDays(5).ToShortDateString();
			lblSunday.Text = "Sunday\n" + firstDay.AddDays(6).ToShortDateString();
			nudCopyWeek.Value = selectedWeekNumber;
		}

		private void ClearWorkshiftBoxes()
		{
			foreach (ListBox lb in allWorkshiftBoxes)
			{
				lb.Items.Clear();
			}
		}

		private void btnNextWeek_Click(object sender, EventArgs e)
		{
			CalculateWeekNumber(true, 1);
			FillWorkshiftBoxes();
		}

		private void btnPreviousWeek_Click(object sender, EventArgs e)
		{
			CalculateWeekNumber(false, 1);
			FillWorkshiftBoxes();
		}

		private void btnSkipNextWeek_Click(object sender, EventArgs e)
		{
			int amountToSkip = Convert.ToInt32(nudSkipNextWeeks.Value);
			CalculateWeekNumber(true, amountToSkip);
			FillWorkshiftBoxes();
		}

		private void btnSkipPreviousWeek_Click(object sender, EventArgs e)
		{
			int amountToSkip = Convert.ToInt32(nudSkipPreviousWeeks.Value);
			CalculateWeekNumber(false, amountToSkip);
			FillWorkshiftBoxes();
		}

		// This is relative to the current week. 
		public void CalculateWeekNumber(bool forward, int amountToChange)
		{
			if (forward)
			{
				selectedWeekNumber += amountToChange;
				selectedYearWeekNumber += amountToChange;
				if (selectedYearWeekNumber > 52)
				{
					CalculateYearNumber();
					selectedYearWeekNumber -= 52;
				}
			}
			else
			{
				selectedWeekNumber -= amountToChange;
				selectedYearWeekNumber -= amountToChange;
				if (selectedYearWeekNumber < 1)
				{
					CalculateYearNumber();
					selectedYearWeekNumber += 52;
				}
			}
		}

		public void CalculateYearNumber()
		{
			// Past year
			if (selectedYearWeekNumber - 52 / 52 < 0)
			{
				selectedYearNumber--;
			}
			// Future year
			else if (selectedYearWeekNumber + 52 / 52 > 1)
			{
				selectedYearNumber++;
			}
			// This year
			else
			{
				return;
			}
		}

		private void LoadDepartments()
		{
			cbDepartment.Items.Add("Management");
			cbDepartment.Items.Add("Legal");
			cbDepartment.Items.Add("Support");
			cbDepartment.Items.Add("Sales");
			cbDepartment.SelectedIndex = 0;
		}

		private void LoadEmployeeCombobox()
		{
			cbEmployee.Items.Clear();
			foreach (ShiftPerson person in spmanager.Persons)
			{
				if (person.Department == cbDepartment.SelectedItem.ToString())
				{
					cbEmployee.Items.Add(person.FirstName + " " + person.LastName);
				}
			}
		}

		private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillWorkshiftBoxes();
			LoadEmployeeCombobox();
		}


		private void shiftworkersTreeView_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				shiftworkersTreeView.SelectedNode = shiftworkersTreeView.GetNodeAt(e.X, e.Y);
			}
		}

		protected void shiftworkersTreeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				TreeNode node = (TreeNode)e.Item;
				DoDragDrop(node.FullPath.ToString(), DragDropEffects.Move);
			}
		}

		private void workshiftListBox_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(string)))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void workshiftListBox_DragOver(object sender, DragEventArgs e)
		{
			Point targetPoint = shiftworkersTreeView.PointToClient(new Point(e.X, e.Y));
			shiftworkersTreeView.SelectedNode = shiftworkersTreeView.GetNodeAt(targetPoint);
		}

		private void workshiftListBox_DoubleClick(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;

			// Getting necessary data to create or search for a workshift
			ShiftType type = CheckListbox(listBox);
			DateTime date = GetDateByListbox(listBox);

			Workshift toPass = manager.SearchWorkshift(date, type, cbDepartment.Text);

			if (toPass != null)
			{
				Workshift savedToPass = new Workshift(toPass);
				WorkshiftDetails newForm = new WorkshiftDetails(toPass);
				newForm.ShowDialog();

				if (CheckForOverlap(toPass))
				{
					manager.ReplaceWorkshift(toPass, savedToPass, cbDepartment.Text);
					MessageBox.Show("There was some overlap with the edited workshift and another.\nThe changes that have been made have been undone.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//MessageBox.Show(toPass.Persons.Count.ToString());
				FillWorkshiftBoxes();
			}
		}

		private bool CheckForOverlap(Workshift workshift)
		{
			foreach (Workshift check in GetDepartmentWorkshifts())
			{
				if (workshift.Date == check.Date && workshift.Type == check.Type && workshift != check)
				{
					return true;
				}
			}
			return false;
		}

		private void workshiftListBox_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				ListBox listBox = (ListBox)sender;
				string getData = e.Data.GetData(typeof(string)).ToString();
				if (getData != null)
				{
					// userInfo[0] = department
					// userInfo[1] = employee name
					string[] userInfo = getData.Split('\\');

					if (CheckDepartment(userInfo[0]))
					{
						// Add constraint checking methods
						ConstraintManager cm = new ConstraintManager();
						List<Constraint> constraints = ConstraintFactory.CreateConstraints(cbIgnoreDailyShifts.Checked, cbMaxHours.Checked);
						cm.AddConstraint(constraints);

						// Getting necessary data to create or search for a workshift
						ShiftType type = CheckListbox(listBox);
						DateTime date = GetDateByListbox(listBox);

						// The CreateWorkshift method also searches for a duplicate
						Workshift toAddToOrCreate = manager.CreateWorkshift(cbDepartment.Text, date, type, Convert.ToInt32(nudMaxAmount.Value));
						List<Workshift> depWorkshifts = GetDepartmentWorkshifts();

						// Adding the person
						ShiftPerson toAdd = spmanager.GetPerson(userInfo[1]);
						ConstraintType results = cm.CheckConstraints(depWorkshifts, toAddToOrCreate, date, toAdd);
						if (results == 0)
						{
							toAddToOrCreate.AddPerson(toAdd);
							FillWorkshiftBoxes();
						}
						else
						{
							string message = "";
							if ((results & ConstraintType.MaxAmount) == ConstraintType.MaxAmount)
							{
								message += $"The shift is already fully filled.\n";
							}
							if ((results & ConstraintType.MaxHours) == ConstraintType.MaxHours)
							{
								message += $"{userInfo[1]} already reached their maximum hours of the week.\n";
							}
							if ((results & ConstraintType.DailyLimit) == ConstraintType.DailyLimit)
							{
								message += $"{userInfo[1]} is already scheduled twice today.\n";
							}
							if ((results & ConstraintType.AlreadyAssigned) == ConstraintType.AlreadyAssigned)
							{
								message += $"{userInfo[1]} is already assigned.\n";
							}
							MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("This user cannot be assigned to the workshift of a different department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btScheduleWeek_Click(object sender, EventArgs e)
		{
			/*Workshift test = new Workshift(DateTime.Now, ShiftType.Morning, 5, "Management");
			manager.EmployeeChecker(test);
			MessageBox.Show(test.Persons[2].FirstName + " " + test.Persons[2].LastName);*/

			if (!manager.AutomaticScheduler(manager.GetFirstDayOfWeek(selectedWeekNumber).Date, Convert.ToInt32(nudMaxAmount.Value), cbDepartment.Text))
			{
				MessageBox.Show("Not all workshifts could be filled. The automatic scheduling was cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			FillWorkshiftBoxes();
			//MessageBox.Show(manager.GetSeed(0,15).ToString());
		}

		private ShiftType CheckListbox(ListBox box)
		{
			if (box.Name.Contains("Morning"))
			{
				return ShiftType.Morning;
			}
			else if (box.Name.Contains("Afternoon"))
			{
				return ShiftType.Afternoon;
			}
			else
			{
				return ShiftType.Evening;
			}
		}

		private bool CheckDepartment(string value)
		{
			if (cbDepartment.SelectedIndex >= 0)
			{
				if (cbDepartment.SelectedItem.ToString() == value)
				{
					return true;
				}
			}
			return false;
		}

		private DateTime GetDateByListbox(ListBox box)
		{
			int offset = 0;
			if (allWorkshiftBoxes.Contains(box))
			{
				int index = allWorkshiftBoxes.IndexOf(box);
				switch (index)
				{
					case 0:
					case 1:
					case 2:
					default:
						offset = 0;
						break;
					case 3:
					case 4:
					case 5:
						offset = 1;
						break;
					case 6:
					case 7:
					case 8:
						offset = 2;
						break;
					case 9:
					case 10:
					case 11:
						offset = 3;
						break;
					case 12:
					case 13:
					case 14:
						offset = 4;
						break;
					case 15:
					case 16:
					case 17:
						offset = 5;
						break;
					case 18:
					case 19:
					case 20:
						offset = 6;
						break;
				}
			}
			DateTime firstDay = manager.GetFirstDayOfWeek(selectedWeekNumber);
			return firstDay.AddDays(offset);
		}

		#endregion

		private void nodeContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			try
			{
				ToolStripItem item = e.ClickedItem;
				switch (item.Name)
				{
					case "menuItemPersonalPlanning":
						if (shiftworkersTreeView.SelectedNode != null)
						{
							string department = shiftworkersTreeView.SelectedNode.Parent.Text;
							string employee = shiftworkersTreeView.SelectedNode.Text;
							cbDepartment.SelectedItem = department;
							cbEmployee.SelectedItem = employee;
							ckbEmployeeToggle.Checked = true;
						}
						break;
					case "menuItemPersonalInfo":
						string selectedEmployee = shiftworkersTreeView.SelectedNode.Text;
						tabs.SelectedIndex = 0;
						tbSearch.Text = selectedEmployee;
						BtnSearchEmployeeClick(sender, e);
						lbEmployees.SelectedIndex = 0;
						break;
					default:
						throw new Exception("Selected item does not exist.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillWorkshiftBoxesByEmployee();
		}

		private void ckbEmployeeToggle_CheckedChanged(object sender, EventArgs e)
		{
			bool isChecked = ckbEmployeeToggle.Checked;
			if (isChecked)
			{
				cbEmployee.Enabled = true;
			}
			else
			{
				cbEmployee.Enabled = false;
			}
			FillWorkshiftBoxes();
		}

		private void FillWorkshiftBoxesByEmployee()
		{
			if (cbEmployee.SelectedIndex >= 0)
			{
				ShiftPerson selectedPerson = spmanager.GetPerson(cbEmployee.Text);
				List<Workshift> employeeShifts = manager.GetWorkshiftsForEmployee(selectedPerson);
				ClearWorkshiftBoxes();
				LoadLabels();
				LoadWorkshifts(employeeShifts);
			}
		}

		#region ChangeRequests
		private void LoadChangeRequests()
		{
			lbChangeRequests.Items.Clear();
			lbAcceptedRequests.Items.Clear();
			lbDeclinedRequests.Items.Clear();

			foreach(ChangeRequest request in crmanager.Requests)
			{
				if (request.Accepted == 'T')
				{
					lbAcceptedRequests.Items.Add($"{request.Person.FirstName} {request.Person.LastName}, {request.Id}");
				}
				else if (request.Accepted == 'F')
				{
					lbDeclinedRequests.Items.Add($"{request.Person.FirstName} {request.Person.LastName}, {request.Id}");
				}
				else
				{
					lbChangeRequests.Items.Add($"{request.Person.FirstName} {request.Person.LastName}, {request.Id}");
				}
			}
		}

		private void changeRequestListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			if (lb.SelectedIndex >= 0)
			{
				// Retrieving the ChangeRequest object
				string[] selectedItem = lb.SelectedItem.ToString().Split(' ');
				int index = Convert.ToInt32(selectedItem[2]);
				ChangeRequest retreivedRequest = crmanager.SearchRequest(index);

				// Update current info group box.
				gbChangeRequest.Text = $"Selected change request: {retreivedRequest.Id}";
				tbCurrentFirstName.Text = retreivedRequest.Person.FirstName;
				tbCurrentLastName.Text = retreivedRequest.Person.LastName;
				dtpCurrentDateOfBirth.Value = retreivedRequest.Person.DateOfBirth;
				tbCurrentNationality.Text = retreivedRequest.Person.Nationality.ToString();
				tbCurrentEmail.Text = retreivedRequest.Person.Email;
				tbCurrentZipCode.Text = retreivedRequest.Person.AddressZipCode;
				tbCurrentCity.Text = retreivedRequest.Person.AddressCity;
				tbCurrentStreet.Text = retreivedRequest.Person.AddressStreet;
				tbCurrentGender.Text = retreivedRequest.Person.Gender.ToString();
				tbCurrentBSN.Text = retreivedRequest.Person.Ssn.ToString();
				tbCurrentIceName.Text = retreivedRequest.Person.IceName;
				tbCurrentIceNumber.Text = retreivedRequest.Person.IcePhone.ToString();
				tbCurrentPhoneNumber.Text = retreivedRequest.Person.Phone.ToString();

				// Update changed info group box
				tbChangedFirstName.Text = retreivedRequest.FirstName;
				tbChangedLastName.Text = retreivedRequest.LastName;
				dtpChangedDateOfBirth.Value = retreivedRequest.DateOfBirth;
				tbChangedNationality.Text = retreivedRequest.Nationality.ToString();
				tbChangedEmail.Text = retreivedRequest.Email;
				tbChangedZipCode.Text = retreivedRequest.AddressZipCode;
				tbChangedCity.Text = retreivedRequest.AddressCity;
				tbChangedStreet.Text = retreivedRequest.AddressStreet;
				tbChangedGender.Text = retreivedRequest.Gender.ToString();
				tbChangedBSN.Text = retreivedRequest.Bsn.ToString();
				tbChangedIceName.Text = retreivedRequest.IceName;
				tbChangedIceNumber.Text = retreivedRequest.IceNumber.ToString();
				tbChangedPhoneNumber.Text = retreivedRequest.PhoneNumber.ToString();

				CheckChangeRequestChanges(tbCurrentFirstName, tbChangedFirstName, retreivedRequest.FirstName, retreivedRequest.Person.FirstName);
				CheckChangeRequestChanges(tbCurrentLastName, tbChangedLastName, retreivedRequest.LastName, retreivedRequest.Person.LastName);
				CheckChangeRequestChanges(dtpCurrentDateOfBirth, dtpChangedDateOfBirth, retreivedRequest.DateOfBirth, retreivedRequest.Person.DateOfBirth);
				CheckChangeRequestChanges(tbCurrentNationality, tbChangedNationality, retreivedRequest.Nationality, retreivedRequest.Person.Nationality);
				CheckChangeRequestChanges(tbCurrentEmail, tbChangedEmail, retreivedRequest.Email, retreivedRequest.Person.Email);
				CheckChangeRequestChanges(tbCurrentZipCode, tbChangedZipCode, retreivedRequest.AddressZipCode, retreivedRequest.Person.AddressZipCode);
				CheckChangeRequestChanges(tbCurrentCity, tbChangedCity, retreivedRequest.AddressCity, retreivedRequest.Person.AddressCity);
				CheckChangeRequestChanges(tbCurrentStreet, tbChangedStreet, retreivedRequest.AddressStreet, retreivedRequest.Person.AddressStreet);
				CheckChangeRequestChanges(tbCurrentGender, tbChangedGender, retreivedRequest.Gender, retreivedRequest.Person.Gender);
				CheckChangeRequestChanges(tbCurrentBSN, tbChangedBSN, retreivedRequest.Bsn, retreivedRequest.Person.Ssn);
				CheckChangeRequestChanges(tbCurrentIceName, tbChangedIceName, retreivedRequest.IceName, retreivedRequest.Person.IceName);
				CheckChangeRequestChanges(tbCurrentIceNumber, tbChangedIceNumber, retreivedRequest.IceNumber, retreivedRequest.Person.IcePhone);
				CheckChangeRequestChanges(tbCurrentPhoneNumber, tbChangedPhoneNumber, retreivedRequest.PhoneNumber, retreivedRequest.Person.Phone);
			}
		}

		private void CheckChangeRequestChanges(object component1, object component2, object variable1, object variable2)
		{
			Control control1 = (Control)component1;
			Control control2 = (Control)component2;
			if (variable1.ToString() != variable2.ToString())
			{
				control1.Enabled = true;
				control1.BackColor = Color.LightCoral;
				control2.Enabled = true;
				control2.BackColor = Color.LightCoral;
			}
			else
			{
				control1.Enabled = false;
				control1.BackColor = Color.White;
				control2.Enabled = false;
				control2.BackColor = Color.White;
			}
		}
		#endregion

		private void btnAcceptChange_Click(object sender, EventArgs e)
		{
			ListBox toChange = FindSelectedChangeListBox();
			if (toChange != null)
			{
				if (toChange.SelectedIndex >= 0)
				{
					// Retrieving the ChangeRequest object
					string[] selectedItem = toChange.SelectedItem.ToString().Split(' ');
					int index = Convert.ToInt32(selectedItem[2]);
					ChangeRequest retreivedRequest = crmanager.SearchRequest(index);
					retreivedRequest.Accept();
					conCR.AcceptChangeRequest(retreivedRequest);
					Person newPerson = new Person(retreivedRequest.FirstName, retreivedRequest.LastName, retreivedRequest.DateOfBirth, retreivedRequest.Nationality, retreivedRequest.Email, retreivedRequest.AddressZipCode, retreivedRequest.AddressCity, retreivedRequest.AddressStreet, retreivedRequest.Person.DateOfEmployment, retreivedRequest.Person.PositionId, retreivedRequest.Person.IsActive, retreivedRequest.Person.Login, retreivedRequest.Gender, retreivedRequest.PhoneNumber, retreivedRequest.Bsn, retreivedRequest.IceName, retreivedRequest.IceNumber, retreivedRequest.Person.HourlyWage);
					con.UpdatePerson(newPerson, retreivedRequest.Person.Id);
					spmanager.RefreshList();
					LoadChangeRequests();
					UpdateList();
					PopulateTreeview();
				}
			}
		}

		private void btnDeclineChange_Click(object sender, EventArgs e)
		{
			ListBox toChange = FindSelectedChangeListBox();
			if (toChange != null)
			{
				if (toChange.SelectedIndex >= 0)
				{
					// Retrieving the ChangeRequest object
					string[] selectedItem = toChange.SelectedItem.ToString().Split(' ');
					int index = Convert.ToInt32(selectedItem[2]);
					ChangeRequest retreivedRequest = crmanager.SearchRequest(index);
					retreivedRequest.Decline();
					LoadChangeRequests();
				}
			}
		}

		private ListBox FindSelectedChangeListBox()
		{
			ListBox toChange = null;
			if (lbChangeRequests.SelectedIndex >= 0)
			{
				toChange = lbChangeRequests;
			}
			else if (lbAcceptedRequests.SelectedIndex >= 0)
			{
				toChange = lbAcceptedRequests;
			}
			else if (lbDeclinedRequests.SelectedIndex >= 0)
			{
				toChange = lbDeclinedRequests;
			}
			return toChange;
		}

		private void btnCopyWeek_Click(object sender, EventArgs e)
		{
			int amountToSkip = Convert.ToInt32(nudCopyWeek.Value) - Convert.ToInt32(lblWeekNumber.Text);
			if (amountToSkip > 0)
			{
				manager.CopyWeek(manager.GetFirstDayOfWeek(selectedWeekNumber), manager.GetFirstDayOfWeek(Convert.ToInt32(nudCopyWeek.Value)), manager.GetFirstDayOfWeek(selectedWeekNumber), cbDepartment.Text);
				CalculateWeekNumber(true, amountToSkip);
				FillWorkshiftBoxes();
				MessageBox.Show("Week copied successfully");

			}
			else
			{
				MessageBox.Show("You cannot plan for the past weeks");
			}
		}
	}
}


