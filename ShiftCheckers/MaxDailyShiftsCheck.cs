using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.ShiftCheckers
{
    class MaxDailyShiftsCheck : Constraint
    {

        public override ConstraintType CheckConstraint(List<Workshift> workshifts, Workshift workshift, DateTime date, ShiftPerson person)
        {
            List<Workshift> CheckWorkshifts = new List<Workshift>();
            CheckWorkshifts.AddRange(workshifts.FindAll(X => X.Date == date));
            int counter;
            counter = CheckWorkshifts.FindAll(Y => Y.Contains(person.Id)).Count;
            if (counter < 2)
            {
                return ConstraintType.Success;
            }
            else
            {
                return ConstraintType.DailyLimit;
            }
        } 
    }
}
