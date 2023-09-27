using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsDoctor : clsPerson
    {

        public enum enDoctorMode { AddNew, Update }
        public enDoctorMode DoctorMode = enDoctorMode.AddNew;

        public static clsPerson _Person;

        public int DoctorID { get; set; }
        public string Specialization { get; set; }


        public clsDoctor() : base()
        {
            this.DoctorID = -1;
            this.Specialization = string.Empty;
            this.DoctorMode = enDoctorMode.AddNew;

            base.PersonMode = clsPerson.enPersonMode.AddNew;
        }

        private clsDoctor(int doctorID, string specialization, int personID, string name, DateTime dateOfBirth,
                          char gender, string phoneNumber, string email, string address) :
                          base(personID, name, dateOfBirth, gender, phoneNumber, email, address)
        {
            this.DoctorID = doctorID;
            this.Specialization = specialization;
            this.DoctorMode = enDoctorMode.Update;

            base.PersonMode = clsPerson.enPersonMode.Update;
        }


        private bool _AddNewDoctor()
        {
            if (base.Save())
            {
                if (base.PersonID != -1)
                {
                    this.DoctorID = clsDoctorDataAccessLayer.AddNewDoctor(base.PersonID, this.Specialization);
                }
            }

            return (this.DoctorID != -1);
        }
        private bool _UpdateDoctor()
        {
            if (base.Save())
            {
                return clsDoctorDataAccessLayer.UpdateDoctor(this.DoctorID, base.PersonID, this.Specialization);
            }

            return false;
        }
        public override bool Save()
        {
            switch (this.DoctorMode)
            {

                case enDoctorMode.AddNew:
                    return _AddNewDoctor();

                case enDoctorMode.Update:
                    return _UpdateDoctor();
            }

            return false;
        }

        private static int _GetPersonIDByDoctorID(int doctorID)
        {
            return clsDoctorDataAccessLayer.GetPersonIDByDoctorID(doctorID);
        }

        public static clsDoctor FindDoctor(int DoctorID)
        {
            int PersonID = -1;
            string Specialization = string.Empty;

            if (clsDoctorDataAccessLayer.GetDoctorInfo(DoctorID, ref PersonID, ref Specialization))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsDoctor(DoctorID, Specialization, _Person.PersonID, _Person.Name, _Person.DateOfBirth, _Person.Gender,
                                          _Person.PhoneNumber, _Person.Email, _Person.Address);
                }
            }

            return null;
        }

        public static bool DeleteDoctor(int DoctorID)
        {
            int PersonID = _GetPersonIDByDoctorID(DoctorID);

            if (PersonID != -1)
            {

                if (clsDoctorDataAccessLayer.DeleteDoctor(DoctorID))
                {
                    return clsPerson.DeletePerson(PersonID);
                }

            }

            return false;
        }

        public static bool IsDoctorExists(int DoctorID)
        {
            return clsDoctorDataAccessLayer.IsDoctorExists(DoctorID);
        }

        public static DataView GetAllDoctors()
        {
            return clsDoctorDataAccessLayer.GetAllDoctors();
        }

        public static DataView SearchDoctorsContainByDoctorID(string Contain)
        {
            return clsDoctorDataAccessLayer.SearchDoctorsContainByDoctorID(Contain);
        }

        public static DataView SearchDoctorsContainByName(string Contain)
        {
            return clsDoctorDataAccessLayer.SearchDoctorsContainByName(Contain);
        }

        public static int GetTotalDoctors()
        {
            return clsDoctorDataAccessLayer.GetTotalDoctors();
        }

    }
}
