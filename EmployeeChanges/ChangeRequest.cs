using MediaBazaar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzar.EmployeeChanges
{
    public class ChangeRequest
    {
        private readonly Person person;
        private readonly int id;
        private readonly string firstName;
        private readonly string lastName;
        private readonly DateTime dateOfBirth;
        private readonly Nationality nationality;
        private readonly string email;
        private readonly string addressZipCode;
        private readonly string addressCity;
        private readonly string addressStreet;
        private readonly char gender;
        private readonly int bsn;
        private readonly string iceName;
        private readonly string iceNumber;
        private readonly string phoneNumber;
        private char accepted;

        public Person Person { get { return this.person; } }
        public int Id { get { return this.id; } }
        public string FirstName { get { return this.firstName; } }
        public string LastName { get { return this.lastName; } }
        public DateTime DateOfBirth { get { return this.dateOfBirth; } }
        public Nationality Nationality { get { return this.nationality; } }
        public string Email { get { return this.email; } }
        public string AddressZipCode { get { return this.addressZipCode; } }
        public string AddressCity { get { return this.addressCity; } }
        public string AddressStreet { get { return this.addressStreet; } }
        public char Gender { get { return this.gender; } }
        public int Bsn { get { return this.bsn; } }
        public string IceName { get { return this.iceName; } }
        public string IceNumber { get { return this.iceNumber; } }
        public string PhoneNumber { get { return this.phoneNumber; } }
        public char Accepted { get { return this.accepted; } }

        public ChangeRequest(Person person, int id, string firstName, string lastName, DateTime dateOfBirth, Nationality nationality, string email, string addressZipCode, string addressCity, string addressStreet, char gender, int bsn, string iceName, string iceNumber, string phoneNumber, char accepted)
        {
            this.person = person;
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.nationality = nationality;
            this.email = email;
            this.addressZipCode = addressZipCode;
            this.addressCity = addressCity;
            this.addressStreet = addressStreet;
            this.gender = gender;
            this.bsn = bsn;
            this.iceName = iceName;
            this.iceNumber = iceNumber;
            this.phoneNumber = phoneNumber;
            this.accepted = accepted;
        }

        public bool Accept()
        {
            if (this.accepted == 'N')
            {
                this.accepted = 'T';
                return true;
            }
            return false;
        }

        public bool Decline()
        {
            if (this.accepted == 'N')
            {
                this.accepted = 'F';
                return true;
            }
            return false;
        }
    }
}
