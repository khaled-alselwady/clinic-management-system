using ClinicSystem_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem_BusinessLayer_
{
    public class clsPayment
    {
        public enum enMode { AddNew, Update }
        public enMode _Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public string AdditionalNotes { get; set; }

        public clsPayment()
        {
            this.PaymentID = -1;
            this.PaymentDate = DateTime.MinValue;
            this.PaymentMethod = string.Empty;
            this.AdditionalNotes = string.Empty;
            this.AmountPaid = 0;

            this._Mode = enMode.AddNew;
        }

        private clsPayment(int PaymentID, DateTime PaymentDate, string PaymentMethod,
                           Decimal AmountPaid, string AdditionalNotes)
        {
            this.PaymentID = PaymentID;
            this.PaymentDate = PaymentDate;
            this.PaymentMethod = PaymentMethod;
            this.AmountPaid = AmountPaid;
            this.AdditionalNotes = AdditionalNotes;

            this._Mode = enMode.Update;
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentDataAccessLayer.AddNewPayment(this.PaymentDate,
                this.PaymentMethod, this.AmountPaid, this.AdditionalNotes);

            return (this.PaymentID != -1);
        }
        private bool _UpdatePayment()
        {
            return clsPaymentDataAccessLayer.UpdatePayment(this.PaymentID, this.PaymentDate,
                this.PaymentMethod, this.AmountPaid, this.AdditionalNotes);
        }
        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    return _AddNewPayment();

                case enMode.Update:
                    return _UpdatePayment();
            }

            return false;
        }

        public static clsPayment FindPayment(int PaymentID)
        {
            DateTime PaymentDate = DateTime.MinValue;
            string PaymentMethod = "", AdditionalNotes = "";
            decimal AmountPaid = 0;

            if (clsPaymentDataAccessLayer.GetPaymentInfo(PaymentID, ref PaymentDate,
                ref PaymentMethod, ref AmountPaid, ref AdditionalNotes))
            {
                return new clsPayment(PaymentID, PaymentDate, PaymentMethod, AmountPaid, AdditionalNotes);
            }

            return null;
        }


        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentDataAccessLayer.DeletePayment(PaymentID);
        }

        public static bool IsPaymentExists(int PaymentID)
        {
            return clsPaymentDataAccessLayer.IsPaymentExists(PaymentID);
        }

        public static DataView GetAllPayments()
        {
            return clsPaymentDataAccessLayer.GetAllPayments();
        }

        public static DataView GetAllPaymentsOfSpecificPatient(int PatientID)
        {
            return clsPaymentDataAccessLayer.GetAllPaymentsOfSpecificPatient(PatientID);
        }

        public static DataView SearchPaymentsContainByPaymentID(string Contain)
        {
            return clsPaymentDataAccessLayer.SearchPaymentsContainByPaymentID(Contain);
        }

        public static DataView SearchPaymentsContainByPaymentMethod(string Contain)
        {
            return clsPaymentDataAccessLayer.SearchPaymentsContainByPaymentMethod(Contain);
        }
    }
}
