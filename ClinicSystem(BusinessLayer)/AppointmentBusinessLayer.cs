using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsAppointment
    {
        public enum enMode { AddNew, Update }
        public enMode _Mode = enMode.AddNew;

        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public short StatusID { get; set; }
        public int MedicalRecordID { get; set; }
        public int PaymentID { get; set; }

        public clsAppointment()
        {
            this.AppointmentID = -1;
            this.PatientID = -1;
            this.DoctorID = -1;
            this.AppointmentDateTime = DateTime.MinValue;
            this.StatusID = -1;
            this.MedicalRecordID = -1;
            this.PaymentID = -1;

            this._Mode = enMode.AddNew;
        }

        public clsAppointment(int appointmentID, int patientID, int doctorID, DateTime appointmentDateTime,
             short statusID, int medicalRecordID, int paymentID)
        {
            this.AppointmentID = appointmentID;
            this.PatientID = patientID;
            this.DoctorID = doctorID;
            this.AppointmentDateTime = appointmentDateTime;
            this.StatusID = statusID;
            this.MedicalRecordID = medicalRecordID;
            this.PaymentID = paymentID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentID = clsAppointmentDataAccessLayer.AddNewAppointment(this.PatientID,
                this.DoctorID, this.AppointmentDateTime, this.StatusID, this.MedicalRecordID, this.PaymentID);

            return (this.AppointmentID != -1);
        }
        private bool _UpdateAppointment()
        {
            return clsAppointmentDataAccessLayer.UpdateAppointment(this.AppointmentID, this.PatientID,
                this.DoctorID, this.AppointmentDateTime, this.StatusID, this.MedicalRecordID, this.PaymentID);
        }
        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    return _AddNewAppointment();

                case enMode.Update:
                    return _UpdateAppointment();
            }

            return false;
        }

        public static clsAppointment FindAppointment(int AppointmentID)
        {
            int PatientID = -1, DoctorID = -1, MedicalRecordID = -1, PaymentID = -1;
            short StatusID = -1;
            DateTime AppointmentDateTime = DateTime.MinValue;

            if (clsAppointmentDataAccessLayer.GetAppointmentInfo(AppointmentID, ref PatientID, ref DoctorID,
                ref AppointmentDateTime, ref StatusID, ref MedicalRecordID, ref PaymentID))
            {
                return new clsAppointment(AppointmentID, PatientID, DoctorID, AppointmentDateTime,
                    StatusID, MedicalRecordID, PaymentID);
            }

            return null;
        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            return clsAppointmentDataAccessLayer.DeleteAppointment(AppointmentID);
        }

        public static bool IsAppointmentExists(int AppointmentID)
        {
            return clsAppointmentDataAccessLayer.IsAppointmentExists(AppointmentID);
        }

        public static DataView GetAllAppointments()
        {
            return clsAppointmentDataAccessLayer.GetAllAppointments();
        }

        public static DataView SearchAppointmentsContainByAppointmentID(string Contain)
        {
            return clsAppointmentDataAccessLayer.SearchAppointmentsContainByAppointmentID(Contain);
        }

        public static DataView SearchAppointmentsContainByPatientID(string Contain)
        {
            return clsAppointmentDataAccessLayer.SearchAppointmentsContainByPatientID(Contain);
        }

        public static DataView SearchAppointmentsContainByDoctorID(string Contain)
        {
            return clsAppointmentDataAccessLayer.SearchAppointmentsContainByDoctorID(Contain);
        }

        public static int GetTotalAppointments()
        {
            return clsAppointmentDataAccessLayer.GetTotalAppointments();
        }

    }
}
