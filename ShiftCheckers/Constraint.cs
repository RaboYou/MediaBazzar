using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.ShiftCheckers
{
    abstract class Constraint
    {
        public abstract ConstraintType CheckConstraint(List<Workshift> workshifts, Workshift workshift, DateTime date, ShiftPerson person);
    }
}
