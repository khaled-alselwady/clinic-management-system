using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsPrescription
    {
        public enum enMode { AddNew, Update }
        public enMode _Mode = enMode.AddNew;

        public int PrescriptionID { get; set; }
        public int MedicalRecordID { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SpecialInstructions { get; set; }

        public clsPrescription()
        {
            this.PrescriptionID = -1;
            this.MedicalRecordID = -1;
            this.MedicationName = string.Empty;
            this.Dosage = string.Empty;
            this.Frequency = string.Empty;
            this.StartDate = DateTime.MinValue;
            this.EndDate = DateTime.MinValue;
            this.SpecialInstructions = string.Empty;

            this._Mode = enMode.AddNew;
        }

        private clsPrescription(int prescriptionID, int medicalRecordID, string medicationName,
                                string dosage, string frequency, DateTime startDate, DateTime endDate,
                                string specialInstructions)
        {
            this.PrescriptionID = prescriptionID;
            this.MedicalRecordID = medicalRecordID;
            this.MedicationName = medicationName;
            this.Dosage = dosage;
            this.Frequency = frequency;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SpecialInstructions = specialInstructions;

            this._Mode = enMode.Update;
        }

        private bool _AddNewPrescription()
        {
            this.PrescriptionID = clsPrescriptionDataAccessLayer.AddNewPrescription(this.MedicalRecordID,
                this.MedicationName, this.Dosage, this.Frequency, this.StartDate, this.EndDate, this.SpecialInstructions);

            return (this.PrescriptionID != -1);
        }
        private bool _UpdatePrescription()
        {
            return clsPrescriptionDataAccessLayer.UpdatePrescription(this.PrescriptionID, this.MedicalRecordID,
                this.MedicationName, this.Dosage, this.Frequency, this.StartDate, this.EndDate, this.SpecialInstructions);
        }
        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    return _AddNewPrescription();

                case enMode.Update:
                    return _UpdatePrescription();
            }

            return false;
        }

        public static clsPrescription FindPrescription(int PrescriptionID)
        {
            int MedicalRecordID = -1;
            string MedicationName = "", Dosage = "", Frequency = "", SpecialInstructions = "";
            DateTime StartDate = DateTime.MinValue, EndDate = DateTime.MinValue;

            if (clsPrescriptionDataAccessLayer.GetPrescriptionInfo(PrescriptionID, ref MedicalRecordID,
                ref MedicationName, ref Dosage, ref Frequency, ref StartDate, ref EndDate, ref SpecialInstructions))
            {
                return new clsPrescription(PrescriptionID, MedicalRecordID, MedicationName, Dosage,
                    Frequency, StartDate, EndDate, SpecialInstructions);
            }

            return null;
        }

        public static bool DeletePrescription(int PrescriptionID)
        {
            return clsPrescriptionDataAccessLayer.DeletePrescription(PrescriptionID);
        }

        public static bool IsPrescriptionExists(int PrescriptionID)
        {
            return clsPrescriptionDataAccessLayer.IsPrescriptionExists(PrescriptionID);
        }

        public static DataView GetAllPrescriptions()
        {
            return clsPrescriptionDataAccessLayer.GetAllPrescriptions();
        }

        public static DataView GetAllPrescriptionsOfSpecificPatient(int PatientID)
        {
            return clsPrescriptionDataAccessLayer.GetAllPrescriptionsOfSpecificPatient(PatientID);
        }
    }
}
