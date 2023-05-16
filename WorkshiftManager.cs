using MediaBazaar;
using MediaBazzar.ShiftCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Cryptography;
using System.Globalization;
using System.Windows.Forms;

namespace MediaBazzar
{
    public class WorkshiftManager
    {
        private List<Workshift> legal;
        private List<Workshift> management;
        private List<Workshift> support;
        private List<Workshift> sales;


        public List<Workshift> Legal { get { return this.legal; } set { this.legal = value; } }
        public List<Workshift> Management { get { return this.management; } set { this.management = value; } }
        public List<Workshift> Support { get { return this.support; } set { this.support = value; } }
        public List<Workshift> Sales { get { return this.sales; } set { this.sales = value; } }


        private SQLConShiftPersonHandling conPersons = new SQLConShiftPersonHandling();

        public WorkshiftManager()
        {
            this.Legal = new List<Workshift>();
            this.Management = new List<Workshift>();
            this.Support = new List<Workshift>();
            this.Sales = new List<Workshift>();

        }

        public Workshift CreateWorkshift(string department, DateTime date, ShiftType shiftType, int maxAmount)
        {
            Workshift searchResult = SearchWorkshift(date, shiftType, department);
            if (searchResult == null)
            {
                if (maxAmount == 0)
                {
                    maxAmount = 5;
                }
                Workshift newWorkshift = new Workshift(date, shiftType, maxAmount, department);
                department = department.ToLower();
                switch (department)
                {
                    case "legal":
                        Legal.Add(newWorkshift);
                        break;
                    case "management":
                        Management.Add(newWorkshift);
                        break;
                    case "support":
                        Support.Add(newWorkshift);
                        break;
                    case "sales":
                        Sales.Add(newWorkshift);
                        break;
                    default:
                        break;
                }
                return newWorkshift;
            }
            else
            {
                return searchResult;
            }
        }

        public Workshift CreateWorkshift(string department, DateTime date, ShiftType shiftType, int maxAmount, List<ShiftPerson> persons)
        {
            Workshift searchResult = SearchWorkshift(date, shiftType, department);
            if (searchResult == null)
            {
                if (maxAmount == 0)
                {
                    maxAmount = 5;
                }
                Workshift newWorkshift = new Workshift(date, shiftType, maxAmount, department, persons);
                switch (department)
                {
                    case "legal":
                        Legal.Add(newWorkshift);
                        break;
                    case "management":
                        Management.Add(newWorkshift);
                        break;
                    case "support":
                        Support.Add(newWorkshift);
                        break;
                    case "sales":
                        Sales.Add(newWorkshift);
                        break;
                    default:
                        break;
                }
                return newWorkshift;
            }
            return null;
        }

        public bool AddUser(string department, DateTime date, ShiftType type, ShiftPerson person)
        {
            Workshift toAddto = SearchWorkshift(date, type, department);
            if (toAddto != null)
            {
                if (toAddto.MaxAmount < toAddto.Persons.Count)
                {
                    toAddto.Persons.Add(person);
                    return true;
                }
            }
            else
            {
                if (department != "")
                {
                    Workshift newWorkshift = CreateWorkshift(department, date, type, 5);
                    if (newWorkshift != null)
                    {
                        newWorkshift.Persons.Add(person);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        // Search all workshifts bound to a person.
        public List<Workshift> GetWorkshiftsForEmployee(ShiftPerson person)
        {
            List<Workshift> toReturn = new List<Workshift>();
            switch (person.Department)
            {
                case "Legal":
                    foreach (Workshift workshift in Legal)
                    {
                        for (int i = 0; i < workshift.Persons.Count; i++)
                        {
                            if (workshift.Persons[i].FirstName == person.FirstName && workshift.Persons[i].LastName == person.LastName)
                            {
                                toReturn.Add(workshift);
                            }
                        }
                    }
                    break;
                case "Management":
                    foreach (Workshift workshift in Management)
                    {
                        for (int i = 0; i < workshift.Persons.Count; i++)
                        {
                            if (workshift.Persons[i].FirstName == person.FirstName && workshift.Persons[i].LastName == person.LastName)
                            {
                                toReturn.Add(workshift);
                            }
                        }
                    }
                    break;
                case "Support":
                    foreach (Workshift workshift in Support)
                    {
                        for (int i = 0; i < workshift.Persons.Count; i++)
                        {
                            if (workshift.Persons[i].FirstName == person.FirstName && workshift.Persons[i].LastName == person.LastName)
                            {
                                toReturn.Add(workshift);
                            }
                        }
                    }
                    break;
                case "Sales":
                    foreach (Workshift workshift in Sales)
                    {
                        for (int i = 0; i < workshift.Persons.Count; i++)
                        {
                            if (workshift.Persons[i].FirstName == person.FirstName && workshift.Persons[i].LastName == person.LastName)
                            {
                                toReturn.Add(workshift);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return toReturn;
        }

        // Search for a particular workshift on a specific date.
        public Workshift SearchWorkshift(DateTime date, ShiftType type, string department)
        {
            switch (department)
            {
                case "Legal":
                    foreach (Workshift workshift in Legal)
                    {
                        if (workshift.Date == date && workshift.Type == type)
                        {
                            return workshift;
                        }
                    }
                    break;
                case "Management":
                    foreach (Workshift workshift in Management)
                    {
                        if (workshift.Date == date && workshift.Type == type)
                        {
                            return workshift;
                        }
                    }
                    break;
                case "Support":
                    foreach (Workshift workshift in Support)
                    {
                        if (workshift.Date == date && workshift.Type == type)
                        {
                            return workshift;
                        }
                    }
                    break;
                case "Sales":
                    foreach (Workshift workshift in Sales)
                    {
                        if (workshift.Date == date && workshift.Type == type)
                        {
                            return workshift;
                        }
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        public void LoadAllWorkshifts()
        {
            SQLConWorkshiftHandling con = new SQLConWorkshiftHandling();
            List<Workshift> allWorkshifts = con.GetAllWorkshifts();
            foreach (Workshift workshift in allWorkshifts)
            {
                switch (workshift.Department)
                {
                    case "Management":
                        Management.Add(workshift);
                        break;
                    case "Legal":
                        Legal.Add(workshift);
                        break;
                    case "Support":
                        Support.Add(workshift);
                        break;
                    case "Sales":
                        Sales.Add(workshift);
                        break;
                    default:
                        break;
                }
            }
        }

        public bool AutomaticScheduler(DateTime date, int maxAmount, string department)
        {
            //Creates 7 workshifts objects, for selected week and checks if there are already shifts created for that week.
            List<ShiftPerson> AllEmployees = conPersons.GetAllPersons();
            List<Workshift> newlyAddedWorkshifts = new List<Workshift>();
            int maxCount = 21;

            for (int i = 0; i < 7; i++)
            {
                List<Workshift> dailyWorkshifts = new List<Workshift>()
                {
                    new Workshift(date.AddDays(i), ShiftType.Morning, maxAmount, department),
                    new Workshift(date.AddDays(i), ShiftType.Afternoon, maxAmount, department),
                    new Workshift(date.AddDays(i), ShiftType.Evening, maxAmount, department)
                };
                
                foreach(Workshift shift in dailyWorkshifts)
                {
                    maxCount = MakeAutomaticWorkshifts(shift, newlyAddedWorkshifts, AllEmployees, department, maxCount);
                }
            }

            if (newlyAddedWorkshifts.Count == maxCount)
            {
                switch (department)
                {
                    case "Management":
                        Management.AddRange(newlyAddedWorkshifts);
                        break;
                    case "Legal":
                        Legal.AddRange(newlyAddedWorkshifts);
                        break;
                    case "Support":
                        Support.AddRange(newlyAddedWorkshifts);
                        break;
                    case "Sales":
                        Sales.AddRange(newlyAddedWorkshifts);
                        break;
                    default:
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private int MakeAutomaticWorkshifts(Workshift workshift, List<Workshift> newlyAdded, List<ShiftPerson> allPeople, string department, int maxCount)
        {
            switch (department)
            {
                case "Management":
                    if (WorkshiftChecker(workshift, Management, newlyAdded))
                    {
                        EmployeeChecker(workshift, newlyAdded, allPeople);
                    }
                    else
                    {
                        maxCount--;
                    }
                    break;
                case "Legal":
                    if (WorkshiftChecker(workshift, Legal, newlyAdded))
                    {
                        EmployeeChecker(workshift, newlyAdded, allPeople);
                    }
                    else
                    {
                        maxCount--;
                    }
                    break;
                case "Support":
                    if (WorkshiftChecker(workshift, Support, newlyAdded))
                    {
                        EmployeeChecker(workshift, newlyAdded, allPeople);
                    }
                    else
                    {
                        maxCount--;
                    }
                    break;
                case "Sales":
                    if (WorkshiftChecker(workshift, Sales, newlyAdded))
                    {
                        EmployeeChecker(workshift, newlyAdded, allPeople);
                    }
                    else
                    {
                        maxCount--;
                    }
                    break;
                default:
                    break;
            }
            return maxCount;
        }

        public bool WorkshiftChecker(Workshift workshift, List<Workshift> listofworkshifts, List<Workshift> newlyAdded)
        {
            Workshift check = listofworkshifts.Find(X => X.Date == workshift.Date && X.Type == workshift.Type);
            if (check != null)
            {
                return false;
            }
            else
            {
                newlyAdded.Add(workshift);
                return true;
            }
        }

        public void EmployeeChecker(Workshift workshift, List<Workshift> newlyAddedWorkshifts, List<ShiftPerson> allPeople)
        {

            List<ShiftPerson> DepartmentEmployees = new List<ShiftPerson>();
            List<ShiftPerson> NotAvailableEmployees = new List<ShiftPerson>();
            for (int i = 0; i < allPeople.Count; i++)
            {
                if (allPeople[i].Department == workshift.Department)
                {
                    DepartmentEmployees.Add(allPeople[i]);
                }
            }
            int personindex = GetSeed(0, DepartmentEmployees.Count - 1);

            ConstraintManager cm = new ConstraintManager();

            List<Constraint> constraints = ConstraintFactory.CreateAutomaticConstraints();
            cm.AddConstraint(constraints);

            ConstraintType results = cm.CheckConstraints(newlyAddedWorkshifts, workshift, workshift.Date, DepartmentEmployees[personindex]);

            while ((results & ConstraintType.MaxAmount) != ConstraintType.MaxAmount)
            {
                if (results == 0)
                {
                    workshift.AddPerson(DepartmentEmployees[personindex]);
                }
                else
                {
                    if (!NotAvailableEmployees.Contains(DepartmentEmployees[personindex]))
                    {
                        NotAvailableEmployees.Add(DepartmentEmployees[personindex]);
                    }
                }
                DepartmentEmployees.RemoveAt(personindex);
                if (DepartmentEmployees.Count > 0)
                {
                    personindex = GetSeed(0, DepartmentEmployees.Count - 1);
                    results = cm.CheckConstraints(newlyAddedWorkshifts, workshift, workshift.Date, DepartmentEmployees[personindex]);
                }
                else
                {
                    if (workshift.Persons.Count < workshift.MaxAmount)
                    {
                        newlyAddedWorkshifts.Remove(workshift);
                    }
                    break;
                }
            }
        }

        private List<Workshift> CopyWorkshiftPattern(DateTime date, string department)
        {

            List<Workshift> CopyPattern = new List<Workshift>();

            switch (department)
            {
                case "Management":
                    for (int i = 0; i < 7; i++)
                    {
                        foreach (Workshift item in Management.FindAll(x => x.Date == date.AddDays(i)))
                        {
                            Workshift ToAdd = new Workshift(item);
                            CopyPattern.Add(ToAdd);
                        }
                    }
                    break;
                case "Legal":
                    for (int i = 0; i < 7; i++)
                    {
                        foreach (Workshift item in Legal.FindAll(x => x.Date == date.AddDays(i)))
                        {
                            Workshift ToAdd = new Workshift(item);
                            CopyPattern.Add(ToAdd);
                        }
                    }
                    break;
                case "Support":
                    for (int i = 0; i < 7; i++)
                    {
                        foreach (Workshift item in Support.FindAll(x => x.Date == date.AddDays(i)))
                        {
                            Workshift ToAdd = new Workshift(item);
                            CopyPattern.Add(ToAdd);
                        }
                    }
                    break;
                case "Sales":
                    for (int i = 0; i < 7; i++)
                    {
                        foreach (Workshift item in Sales.FindAll(x => x.Date == date.AddDays(i)))
                        {
                            Workshift ToAdd = new Workshift(item);
                            CopyPattern.Add(ToAdd);
                        }
                    }
                    break;
                default:
                    break;
            }
            return CopyPattern;


        }
        private void PasteWorkshiftPattern(double daystoadd, string department, List<Workshift> Pattern)
        {

            switch (department)
            {
                case "Management":
                    for (int i = 0; i < Pattern.Count; i++)
                    {
                        Pattern[i].Date = Pattern[i].Date.AddDays(daystoadd);
                        WorkshiftChecker(Pattern[i],Management,Management);
                       //Management.Add(Pattern[i]);
                    }
                    break;
                case "Legal":
                    for (int i = 0; i < Pattern.Count; i++)
                    {
                        Pattern[i].Date = Pattern[i].Date.AddDays(daystoadd);
                        WorkshiftChecker(Pattern[i], Legal, Legal);
                        //Legal.Add(Pattern[i]);
                    }
                    break;
                case "Support":
                    for (int i = 0; i < Pattern.Count; i++)
                    {
                        Pattern[i].Date = Pattern[i].Date.AddDays(daystoadd);
                        WorkshiftChecker(Pattern[i], Support, Support);
                        //Support.Add(Pattern[i]);

                    }
                    break;
                case "Sales":
                    for (int i = 0; i < Pattern.Count; i++)
                    {
                        Pattern[i].Date = Pattern[i].Date.AddDays(daystoadd);
                        WorkshiftChecker(Pattern[i], Sales,Sales);
                        //Sales.Add(Pattern[i]);
                    }
                    break;
                default:
                    break;
            }
        }

        public void CopyWeek(DateTime selectedWeek, DateTime weekToPaste, DateTime date, string department)
        {
            PasteWorkshiftPattern(weekToPaste.Subtract(selectedWeek).TotalDays, department, CopyWorkshiftPattern(date, department));
        }

        private int GetSeed(int min, int max)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                int scale = int.MaxValue;
                while (scale == int.MaxValue)
                {
                    byte[] newBytes = new byte[4];
                    rng.GetBytes(newBytes);
                    scale = BitConverter.ToInt32(newBytes, 0);
                }

                int result = ((int)(min + (max - min) * (scale / (double)int.MaxValue)));
                if (result < 0)
                {
                    return Math.Abs(result);
                }
                else
                {
                    return result;
                }
            }
        }

        public void ReplaceWorkshift(Workshift workshift, Workshift toReplace, string department)
        {
            department = department.ToLower();
            List<Workshift> target = null;
            switch (department)
            {
                case "management":
                    target = Management;
                    break;
                case "legal":
                    target = Legal;
                    break;
                case "support":
                    target = Support;
                    break;
                case "sales":
                    target = Sales;
                    break;
            }
            foreach(Workshift check in target)
            {
                if (workshift == check)
                {
                    int index = target.IndexOf(check);
                    target.RemoveAt(index);
                    target.Insert(index, toReplace);
                    return;
                }
            }
        }
        public DateTime GetFirstDayOfWeek(int weekNumber)
        {
            DateTime jan1 = new DateTime(DateTime.Now.Year, 1, 1);
            int dayOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(dayOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstMonday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (firstWeek <= 1)
            {
                weekNumber -= 1;
            }

            DateTime result = firstMonday.AddDays(weekNumber * 7);
            return result;
        }

    }
}