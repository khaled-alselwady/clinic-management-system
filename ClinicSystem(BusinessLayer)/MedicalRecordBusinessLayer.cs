using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsMedicalRecord
    {
        public enum enMode { AddNew, Update }
        public enMode _Mode = enMode.AddNew;

        public int MedicalRecordID { get; set; }
        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }

        public clsMedicalRecord()
        {
            this.MedicalRecordID = -1;
            this.VisitDescription = string.Empty;
            this.Diagnosis = string.Empty;
            this.AdditionalNotes = string.Empty;

            this._Mode = enMode.AddNew;
        }

        private clsMedicalRecord(int medicalRecordID, string visitDescription,
                                 string diagnosis, string additionalNotes)
        {
            this.MedicalRecordID = medicalRecordID;
            this.VisitDescription = visitDescription;
            this.Diagnosis = diagnosis;
            this.AdditionalNotes = additionalNotes;

            this._Mode = enMode.Update;
        }

        private bool _AddNewMedicalRecord()
        {
            this.MedicalRecordID = clsMedicalRecordDataAccessLayer.AddNewMedicalRecord(this.VisitDescription,
                                   this.Diagnosis, this.AdditionalNotes);

            return (this.MedicalRecordID != -1);
        }
        private bool _UpdateMedicalRecord()
        {
            return clsMedicalRecordDataAccessLayer.UpdateMedicalRecord(this.MedicalRecordID,
                   this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
        }
        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    return this._AddNewMedicalRecord();

                case enMode.Update:
                    return this._UpdateMedicalRecord();
            }

            return false;
        }

        public static clsMedicalRecord FindMedicalRecord(int medicalRecordID)
        {
            string VisitDescription = "", Diagnosis = "", AdditionalNotes = "";

            if (clsMedicalRecordDataAccessLayer.GetMedicalRecordInfo(medicalRecordID, ref VisitDescription, ref Diagnosis, ref AdditionalNotes))
            {
                return new clsMedicalRecord(medicalRecordID, VisitDescription, Diagnosis, AdditionalNotes);
            }

            return null;
        }

        public static bool DeleteMedicalRecord(int MedicalRecordID)
        {
            return clsMedicalRecordDataAccessLayer.DeleteMedicalRecord(MedicalRecordID);
        }

        public static bool IsMedicalRecordExists(int MedicalRecordID)
        {
            return clsMedicalRecordDataAccessLayer.IsMedicalRecordExists(MedicalRecordID);
        }

        public static DataView GetAllMedicalRecords()
        {
            return clsMedicalRecordDataAccessLayer.GetAllMedicalRecords();
        }

        public static DataView GetAllMedicalRecordsOfSpecificPatient(int PatientID)
        {
            return clsMedicalRecordDataAccessLayer.GetAllMedicalRecordsOfSpecificPatient(PatientID);
        }
    }
}
