using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsPerson
    {
        public enum enPersonMode { AddNew, Update }
        public enPersonMode PersonMode = enPersonMode.AddNew;

        public int PersonID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = string.Empty;
            this.DateOfBirth = new DateTime();
            this.Gender = Char.MinValue;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;

            this.PersonMode = enPersonMode.AddNew;
        }
        protected clsPerson(int personID, string name, DateTime dateOfBirth, char gender,
                          string phoneNumber, string email, string address)
        {
            this.PersonID = personID;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;

            this.PersonMode = enPersonMode.Update;
        }


        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccessLayer.AddNewPerson(this.Name, this.DateOfBirth, this.Gender,
                                                                  this.PhoneNumber, this.Email, this.Address);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonDataAccessLayer.UpdatePerson(this.PersonID, this.Name, this.DateOfBirth, this.Gender,
                                                         this.PhoneNumber, this.Email, this.Address);
        }
        public virtual bool Save()
        {
            switch (this.PersonMode)
            {
                case enPersonMode.AddNew:
                    return _AddNewPerson();

                case enPersonMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson FindPerson(int PersonID)
        {
            string Name = "", PhoneNumber = "", Email = "", Address = "";
            DateTime DateOfBirth = new DateTime();
            char Gender = 'A';

            if (clsPersonDataAccessLayer.GetPersonInfo(PersonID, ref Name, ref DateOfBirth, ref Gender,
                                                       ref PhoneNumber, ref Email, ref Address))
            {
                return new clsPerson(PersonID, Name, DateOfBirth, Gender, PhoneNumber, Email, Address);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccessLayer.DeletePerson(PersonID);
        }

        public static bool IsPersonExists(int PersonID)
        {
            return clsPersonDataAccessLayer.IsPersonExists(PersonID);
        }

    }
}
