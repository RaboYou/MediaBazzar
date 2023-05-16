using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar
{
    public class ShiftPersonManager
    {
        private List<ShiftPerson> persons;
        public List<ShiftPerson> Persons { get { return this.persons; } set { this.persons = value; } }

        public ShiftPersonManager(List<ShiftPerson> persons = null)
        {
            if (persons != null)
            {
                this.Persons = persons;
            } else
            {
                SQLConShiftPersonHandling con = new SQLConShiftPersonHandling();
                this.Persons = con.GetAllPersons();
            }
        }

        public void RefreshList()
        {
            SQLConShiftPersonHandling con = new SQLConShiftPersonHandling();
            this.Persons = con.GetAllPersons();
        }

        public ShiftPerson GetPerson(string name)
        {
            string[] names = name.Split(' ');
            string firstName = names[0];
            string lastName = names[1];
            foreach(ShiftPerson person in Persons)
            {
                if (person.FirstName == firstName && person.LastName == lastName)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
