using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.ShiftCheckers
{
    class ConstraintManager
    {
        private List<Constraint> constraints;

        public ConstraintManager()
        {
            this.constraints = new List<Constraint>();
        }

        public void AddConstraint(List<Constraint> constraint)
        {
            this.constraints.AddRange(constraint);
        }

        public ConstraintType CheckConstraints(List<Workshift> workshifts, Workshift workshift, DateTime date, ShiftPerson persons)
        {
            ConstraintType results = ConstraintType.Success; 
            foreach(Constraint constraint in constraints)
            {
                results |= constraint.CheckConstraint(workshifts, workshift, date, persons);
            }
            return results;
        }
    }
}
