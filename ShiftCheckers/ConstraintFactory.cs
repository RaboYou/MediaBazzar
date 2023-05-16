using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.ShiftCheckers
{
    class ConstraintFactory
    {
        public static List<Constraint> CreateConstraints(bool ignoreMaxAmount, bool maxHours)
        {
            List<Constraint> constraints = new List<Constraint>();
            if (!ignoreMaxAmount)
            {
                Constraint maxAmountCheck = new MaxAmountCheck();
                constraints.Add(maxAmountCheck);
            }
            if (!maxHours)
            {
                Constraint maxHoursCheck = new MaxHoursCheck();
                constraints.Add(maxHoursCheck);
            }

            Constraint alreadyAssignedToShift = new AlreadyAssignedToShift();
            constraints.Add(alreadyAssignedToShift);

            return constraints;
        }

        public static List<Constraint> CreateAutomaticConstraints()
        {
            List<Constraint> constraints = new List<Constraint>();

            Constraint maxAmountCheck = new MaxAmountCheck();
            constraints.Add(maxAmountCheck);

            Constraint maxHoursCheck = new MaxHoursCheck();
            constraints.Add(maxHoursCheck);

            Constraint maxDailyShiftsCheck = new MaxDailyShiftsCheck();
            constraints.Add(maxDailyShiftsCheck);

            Constraint alreadyAssignedToShift = new AlreadyAssignedToShift();
            constraints.Add(alreadyAssignedToShift);

            return constraints;
        }
    }
}
