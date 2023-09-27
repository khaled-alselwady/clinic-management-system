using ClinicSystem_DataAccessLayer_;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsUser : clsPerson
    {
        public enum enUserMode { AddNew, Update }
        public enUserMode UserMode = enUserMode.AddNew;

        public enum enPermissions
        {
            All = -1,
            Patients = 1,
            Doctors = 2,
            Appointments = 4,
            Payments = 8,
            Users = 16 
        }

        private static clsPerson _Person;

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }

        public clsUser() : base()
        {
            this.UserID = -1;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = 0;
            this.UserMode = enUserMode.AddNew;

            base.PersonMode = clsPerson.enPersonMode.AddNew;
        }

        private clsUser(int userID, string username, string password, int permissions, int personID, string name,
                        DateTime dateOfBirth, char gender, string phoneNumber, string email, string address) :
                        base(personID, name, dateOfBirth, gender, phoneNumber, email, address)
        {
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
            this.Permissions = permissions;
            this.UserMode = enUserMode.Update;

            base.PersonMode = clsPerson.enPersonMode.Update;
        }

        private bool _AddNewUser()
        {
            if (!IsUserExists(this.Username) && base.Save())
            {
                if (base.PersonID != -1)
                {
                    this.UserID = clsUserDataAccessLayer.AddNewUser(this.Username, this.Password, this.Permissions, base.PersonID);
                }
            }

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            clsUser _User = clsUser.FindUser(this.UserID);
            if (_User.Username != this.Username)
            {
                if (IsUserExists(this.Username))
                {
                    return false;
                }
            }


            if (base.Save())
            {
                return clsUserDataAccessLayer.UpdateUser(this.UserID, this.Username, this.Password, this.Permissions, base.PersonID);
            }

            return false;
        }
        public override bool Save()
        {
            switch (this.UserMode)
            {
                case enUserMode.AddNew:
                    return _AddNewUser();

                case enUserMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        private static int _GetPersonIDByUserID(int UserID)
        {
            return clsUserDataAccessLayer.GetPersonIDByUserID(UserID);
        }

        public static clsUser FindUser(int userID)
        {
            string Username = "", Password = "";
            int Permissions = 0, PersonID = -1;

            if (clsUserDataAccessLayer.GetUserInfo(userID, ref Username, ref Password, ref Permissions, ref PersonID))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsUser(userID, Username, Password, Permissions, _Person.PersonID, _Person.Name,
                      _Person.DateOfBirth, _Person.Gender, _Person.PhoneNumber, _Person.Email, _Person.Address);
                }
            }

            return null;
        }

        public static clsUser FindUser(string Username)
        {
            string Password = "";
            int UserID = -1, Permissions = 0, PersonID = -1;

            if (clsUserDataAccessLayer.GetUserInfo(Username, ref UserID, ref Password, ref Permissions, ref PersonID))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsUser(UserID, Username, Password, Permissions, _Person.PersonID, _Person.Name,
                      _Person.DateOfBirth, _Person.Gender, _Person.PhoneNumber, _Person.Email, _Person.Address);
                }
            }

            return null;
        }

        public static clsUser FindUser(string Username, string Password)
        {
            int UserID = -1, Permissions = 0, PersonID = -1;

            if (clsUserDataAccessLayer.GetUserInfo(Username, Password, ref UserID, ref Permissions, ref PersonID))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsUser(UserID, Username, Password, Permissions, _Person.PersonID, _Person.Name,
                      _Person.DateOfBirth, _Person.Gender, _Person.PhoneNumber, _Person.Email, _Person.Address);
                }
            }

            return null;
        }

        public static bool DeleteUser(int userID)
        {
            int PersonID = _GetPersonIDByUserID(userID);

            if (PersonID != -1)
            {

                if (clsUserDataAccessLayer.DeleteUser(userID))
                {
                    return clsPerson.DeletePerson(PersonID);
                }

            }

            return false;
        }

        public static bool IsUserExists(int userID)
        {
            return clsUserDataAccessLayer.IsUserExists(userID);
        }

        public static bool IsUserExists(string Username)
        {
            return clsUserDataAccessLayer.IsUserExists(Username);
        }

        public static bool IsUserExists(string Username, string Password)
        {
            return clsUserDataAccessLayer.IsUserExists(Username, Password);
        }

        public static DataView GetAllUsers()
        {
            return clsUserDataAccessLayer.GetAllUsers();
        }

        public static DataView SearchUsersContainByUserID(string Contain)
        {
            return clsUserDataAccessLayer.SearchUsersContainByUserID(Contain);
        }

        public static DataView SearchUsersContainByUsername(string Contain)
        {
            return clsUserDataAccessLayer.SearchUsersContainByUsername(Contain);
        }

        public static int GetTotalUsers()
        {
            return clsUserDataAccessLayer.GetTotalUsers();
        }

    }
}
