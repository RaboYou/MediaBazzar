using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazaar;

namespace MediaBazzar.ShiftCheckers
{
    class AlreadyAssignedToShift : Constraint
    {
        public override ConstraintType CheckConstraint(List<Workshift> workshifts, Workshift workshift, DateTime date, ShiftPerson person)
        {
            foreach(ShiftPerson index in workshift.Persons)
            {
                if (index.Id.Equals(person.Id))
                {
                    return ConstraintType.AlreadyAssigned;
                }
            }
            return ConstraintType.Success;
        }
    }
}
