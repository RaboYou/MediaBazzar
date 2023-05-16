namespace MediaBazzar
{
    public class ShiftPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int MaxHours { get; set; }

        public ShiftPerson(int id, string firstName, string lastName, string department, int maxHours)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Department = department;
            this.MaxHours = maxHours;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}