using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MediaBazzar.ShiftCheckers
{
    class MaxHoursCheck : Constraint
    {
        public override ConstraintType CheckConstraint(List<Workshift> workshifts, Workshift workshift, DateTime date, ShiftPerson person)
        {
            List<Workshift> CheckWorkshifts = new List<Workshift>();            

            DateTime jan1 = new DateTime(DateTime.Now.Year, 1, 1);
            int dayOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(dayOffset);
            var ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (weekNum <= 1)
            {
                weekNum -= 1;
            }
            DateTime result = firstMonday.AddDays(weekNum * 7);


            for (int i = 0; i < 7; i++)
            {
                foreach (Workshift item in workshifts.FindAll(x => x.Date == result.AddDays(i)))
                {
                   
                   CheckWorkshifts.Add(item);
                }
             
            }
            int counter = CheckWorkshifts.FindAll(Y => Y.Contains(person.Id)).Count;

            if (counter * 4 < person.MaxHours)
            {
                return ConstraintType.Success;
            }
            else
            {
                return ConstraintType.MaxHours;
            }
        }
    }
}
