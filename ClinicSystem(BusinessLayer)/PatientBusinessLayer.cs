using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsPatient : clsPerson
    {
        public enum enPatientMode { AddNew, Update }
        public enPatientMode PatientMode = enPatientMode.AddNew;

        public int PatientID { get; set; }

        private static clsPerson _Person;

        public clsPatient() : base()
        {
            this.PatientID = -1;
            this.PatientMode = enPatientMode.AddNew;
            base.PersonMode = clsPerson.enPersonMode.AddNew;
        }
        private clsPatient(int PatientID, int personID, string name, DateTime dateOfBirth, char gender,
                           string phoneNumber, string email, string address) :
                           base(personID, name, dateOfBirth, gender, phoneNumber, email, address)
        {
            this.PatientID = PatientID;
            this.PatientMode = enPatientMode.Update;
            base.PersonMode = clsPerson.enPersonMode.Update;
        }


        private bool _AddNewPatient()
        {
            if (base.Save())
            {
                if (base.PersonID != -1)
                {
                    this.PatientID = clsPatientsDataAccessLayer.AddNewPatient(base.PersonID);
                }
            }

            return (this.PatientID != -1);
        }
        private bool _UpdatePatient()
        {
            return base.Save();
        }
        public override bool Save()
        {
            switch (this.PatientMode)
            {
                case enPatientMode.AddNew:
                    return _AddNewPatient();

                case enPatientMode.Update:
                    return _UpdatePatient();
            }

            return false;
        }

        private static int _GetPersonIDByPatientID(int PatientID)
        {
            return clsPatientsDataAccessLayer.GetPersonIDByPatientID(PatientID);
        }


        public static clsPatient FindPatient(int PatientID)
        {
            int PersonID = -1;

            if (clsPatientsDataAccessLayer.GetPatientInfo(PatientID, ref PersonID))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsPatient(PatientID, _Person.PersonID, _Person.Name, _Person.DateOfBirth, _Person.Gender,
                                          _Person.PhoneNumber, _Person.Email, _Person.Address);
                }
            }

            return null;
        }

        public static bool DeletePatient(int PatientID)
        {
            int PersonID = _GetPersonIDByPatientID(PatientID);

            if (PersonID != -1)
            {

                if (clsPatientsDataAccessLayer.DeletePatient(PatientID))
                {
                    return clsPerson.DeletePerson(PersonID);
                }

            }

            return false;
        }

        public static bool IsPatientExists(int PatientID)
        {
            return clsPatientsDataAccessLayer.IsPatientExists(PatientID);
        }

        public static DataView GetAllPatients()
        {
            return clsPatientsDataAccessLayer.GetAllPatients();
        }

        public static DataView SearchPatientsContainByPatientID(string Contain)
        {
            return clsPatientsDataAccessLayer.SearchPatientsContainByPatientID(Contain);
        }
        public static DataView SearchPatientsContainByName(string Contain)
        {
            return clsPatientsDataAccessLayer.SearchPatientsContainByName(Contain);
        }

        public static int GetTotalPatients()
        {
            return clsPatientsDataAccessLayer.GetTotalPatients();
        }
    }
}
