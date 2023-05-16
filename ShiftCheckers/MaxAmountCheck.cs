using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.ShiftCheckers
{
    class MaxAmountCheck : Constraint
    {
        public override ConstraintType CheckConstraint(List<Workshift> workshifts, Workshift workshift, DateTime date, ShiftPerson person)
        {
            if (workshift.Persons.Count + 1 <= workshift.MaxAmount)
            {
                return ConstraintType.Success;
            }
            return ConstraintType.MaxAmount;
        }

    }
}
