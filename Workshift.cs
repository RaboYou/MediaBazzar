using MediaBazzar;
using MediaBazzar.ShiftCheckers;
using System;
using System.Collections.Generic;

namespace MediaBazaar
{
    public class Workshift
    {
        private List<ShiftPerson> persons;
        private DateTime date;
        private ShiftType type;
        private int maxAmount;
        private string department;

        public List<ShiftPerson> Persons { get { return this.persons; } }
        public DateTime Date { get { return this.date; } set { this.date = value; } }
        public ShiftType Type { get { return this.type; } set { this.type = value; } }
        public int MaxAmount { get { return this.maxAmount; } set { this.maxAmount = value; } }
        public string Department { get { return this.department; } set { this.department = value; } }

        public Workshift(DateTime date, ShiftType type, int maxAmount, string department) : this(date, type, maxAmount, department, null) { }

        public Workshift(Workshift workshift)
        {
            this.Date = workshift.Date;
            this.Type = workshift.Type;
            this.MaxAmount = workshift.MaxAmount;
            this.Department = workshift.Department;
            this.persons = new List<ShiftPerson>();
            for (int i = 0; i < workshift.Persons.Count; i++)
            {
                AddPerson(workshift.Persons[i]);
            }
        }

        public Workshift(DateTime date, ShiftType type, int maxAmount, string department, List<ShiftPerson> persons = null)
        {
            this.Date = date;
            this.Type = type;
            this.MaxAmount = maxAmount;
            this.Department = department;
            if (persons != null)
            {
                this.persons = new List<ShiftPerson>();
                foreach (ShiftPerson person in persons)
                {
                    AddPerson(person);
                }
            }
            else
            {
                this.persons = new List<ShiftPerson>();
            }
        }

        public bool Contains(int id)
        {
            foreach (ShiftPerson person in this.Persons)
            {
                if (person.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddPerson(ShiftPerson person)
        {
            this.persons.Add(person);
        }

        public void RemovePerson(ShiftPerson person)
        {
            this.persons.Remove(person);
        }

        public ShiftPerson SearchPerson(string name)
        {
            foreach(ShiftPerson person in this.Persons)
            {
                string personName = person.FirstName + " " + person.LastName;
                if (name == personName)
                {
                    return person;
                }
            }
            return null;
        }
    }
}