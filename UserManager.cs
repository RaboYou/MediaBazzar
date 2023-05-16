using System.Collections.Generic;

namespace MediaBazzar
{
    public class UserManager
    {
        private List<Person> persons = new List<Person>();

        public UserManager()
        {
            //persons.Add(person);
        }

        /*public void AddUser(string firstName, string lastName, DateTime date, Nationality nat, string email, string address)
        {
            Person person = new Person(firstName, lastName, date, nat, email, address);
            NewUserEntry(firstName, lastName, date, nat, email, address);
            persons.Add(person);
        }

        public void DeleteUser(string firstName, string lastName)
        {
            foreach (Person person in persons)
            {
                if (person.FirstName.Equals(firstName) && person.LastName.Equals(lastName))
                {
                    persons.Remove(person);
                }
            }
        }

        public void NewUserEntry(string firstName, string lastName, DateTime date, Nationality nat, string email, string address)
        {
            MySqlConnection con = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi465395;Database=dbi465395;Pwd=Michael;");
            string sql = "INSERT INTO Users (firstName, lastName, birthDay, nationality, email, address, status) VALUES (@firstName, @lastName, @birthday, @nationality, @email, @address, @status)";
            MySqlCommand command = new MySqlCommand(sql, con);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@birthDay", date);
            command.Parameters.AddWithValue("@nationality", nat);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@status", "ACTIVE");

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        public Person[] GetAllPersons()
        {
            return persons.ToArray();
        }*/
    }
}
