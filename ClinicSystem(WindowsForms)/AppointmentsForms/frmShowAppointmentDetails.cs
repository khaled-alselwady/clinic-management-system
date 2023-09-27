using ClinicSystem_BusinessLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_.AppointmentsForms
{
    public partial class frmShowAppointmentDetails : Form
    {
        private int _AppointmentID;
        private clsAppointment _Appointment;

        public frmShowAppointmentDetails(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
        }

        private void _LoadMedicalRecordData(int MedicalRecordID)
        {
            clsMedicalRecord MedicalRecord = clsMedicalRecord.FindMedicalRecord(MedicalRecordID);

            if (MedicalRecord != null)
            {
                lblMedicalRecordID.Text = MedicalRecord.MedicalRecordID.ToString();
                lblVisitDescription.Text = MedicalRecord.VisitDescription.ToString();
                lblDiagnosis.Text = MedicalRecord.Diagnosis.ToString();
            }
        }

        private void _LoadPaymentData(int PaymentID)
        {
            clsPayment Payment = clsPayment.FindPayment(PaymentID);

            if (Payment != null)
            {
                lblPaymentID.Text = Payment.PaymentID.ToString();
                lblPaymentDate.Text = Payment.PaymentDate.ToString("yyyy-MM-dd");
                lblPaymentMethod.Text = Payment.PaymentMethod.ToString();
                lblPaymentAmount.Text = Payment.AmountPaid.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmShowAppointmentDetails_Load(object sender, EventArgs e)
        {
            _Appointment = clsAppointment.FindAppointment(_AppointmentID);

            if (_Appointment != null)
            {
                ucShowPatientDetails.LoadData(_Appointment.PatientID);
                ucShowDoctorDetails.LoadData(_Appointment.DoctorID);
                _LoadMedicalRecordData(_Appointment.MedicalRecordID);
                _LoadPaymentData(_Appointment.PaymentID);
            }

        }
    }
}
