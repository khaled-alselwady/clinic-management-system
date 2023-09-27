using ClinicSystem_BusinessLayer_;
using ClinicSystem_WindowsForms_.MedicalRecordsForms;
using ClinicSystem_WindowsForms_.PaymentForms;
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
    public partial class frmAddEditAppointment : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _AppointmentID;
        private clsAppointment _Appointment;

        private bool isInitial = true;

        public frmAddEditAppointment(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;

            if (_AppointmentID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

        }

        private void _FillComboStatus()
        {
            DataView dvStatus = clsAppointmentStatus.GetAllStatusName();

            for (int i = 0; i < dvStatus.Count; i++)
            {
                comboStatus.Items.Add(dvStatus[i]["Status"]);
            }

        }

        private void _FillFieldWithData()
        {
            numaricPatientID.Value = _Appointment.PatientID;
            ucShowPatientDetails.LoadData(_Appointment.PatientID);

            numaricDoctor.Value = _Appointment.DoctorID;
            ucShowDoctorDetails.LoadData(_Appointment.DoctorID);

            dtpAppointmentDate.Value = _Appointment.AppointmentDateTime;
            dtpAppointmentTime.Value = _Appointment.AppointmentDateTime;

            if (_Appointment.MedicalRecordID != -1)
            {
                lblMedicalRecordID.Text = _Appointment.MedicalRecordID.ToString();
                btnAddNewMedicalRecord.Visible = false;
            }
            else
            {
                lblMedicalRecordID.Text = "";
                btnAddNewMedicalRecord.Visible = true;
            }

            if (_Appointment.PaymentID != -1)
            {
                lblPaymentID.Text = _Appointment.PaymentID.ToString();
                btnPay.Visible = false;
            }
            else
            {
                lblPaymentID.Text = "";
                btnPay.Visible = true;
            }

            comboStatus.SelectedIndex = comboStatus.FindString(clsAppointmentStatus.FindStatus(_Appointment.StatusID).Status);

            btnAddNewMedicalRecord.Enabled = (comboStatus.Text == "Completed");
        }

        private void _LoadData()
        {
            _FillComboStatus();

            if (_Mode == enMode.AddNew)
            {
                _Appointment = new clsAppointment();

                lblMode.Text = "Add New Appointment";

                comboStatus.Items.Insert(0, "Select Status");
                comboStatus.SelectedIndex = 0;

                ucShowDoctorDetails.UpdateNameOfGroupBox("Doctor Details");
            }

            else
            {
                _Appointment = clsAppointment.FindAppointment(_AppointmentID);

                if (_Appointment == null)
                {
                    MessageBox.Show("This Appointment is not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                lblMode.Text = "Update Appointment";
                _FillFieldWithData();
            }

        }

        private bool _IsDoctorFree()
        {
            DataView dv = clsAppointment.GetAllAppointments();

            int AppointmentID = -1;
            int DoctorID = -1;
            DateTime Date = DateTime.Now;
            string Status = string.Empty;

            DateTime DateTimeFromDateTimePicker = new DateTime(dtpAppointmentDate.Value.Year,
                dtpAppointmentDate.Value.Month, dtpAppointmentDate.Value.Day,
                dtpAppointmentTime.Value.Hour, dtpAppointmentTime.Value.Minute,
                dtpAppointmentTime.Value.Second, dtpAppointmentTime.Value.Millisecond);

            for (int i = 0; i < dv.Count; i++)
            {
                DoctorID = Convert.ToInt32(dv[i]["DoctorID"]);
                Date = Convert.ToDateTime(dv[i]["AppointmentDateTime"]);
                Status = Convert.ToString(dv[i]["Status"]);
                AppointmentID = Convert.ToInt32(dv[i]["AppointmentID"]);

                if ((_Appointment.DoctorID == (int)numaricDoctor.Value && _Appointment.AppointmentDateTime == DateTimeFromDateTimePicker))
                {
                    continue;
                }

                if ((DoctorID == (int)numaricDoctor.Value) &&
                    (Date == DateTimeFromDateTimePicker) &&
                    (Status != "Canceled" && Status != "Completed" && Status != "NoShow"))
                {
                    return false;
                }
            }

            return true;
        }

        private bool _IsDataCorrect()
        {
            if (!clsPatient.IsPatientExists((int)numaricPatientID.Value))
            {
                MessageBox.Show($"There is no patient with ID = {(int)numaricPatientID.Value}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!clsDoctor.IsDoctorExists((int)numaricDoctor.Value))
            {
                MessageBox.Show($"There is no doctor with ID = {(int)numaricDoctor.Value}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (comboStatus.Text == "Select Status")
            {
                MessageBox.Show("Select the status first!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (dtpAppointmentDate.Value < DateTime.Now)
            {
                MessageBox.Show("The Appointment date should be after today's date!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            DateTime DateTimeFromDateTimePicker = new DateTime(dtpAppointmentDate.Value.Year,
                dtpAppointmentDate.Value.Month, dtpAppointmentDate.Value.Day,
                dtpAppointmentTime.Value.Hour, dtpAppointmentTime.Value.Minute,
                dtpAppointmentTime.Value.Second, dtpAppointmentTime.Value.Millisecond);

            string MyStatus = "";

            if (_Mode != enMode.AddNew)
            {
                MyStatus = clsAppointmentStatus.FindStatus(_Appointment.StatusID).Status;
            }


            if ((_Mode == enMode.AddNew) ||
                (_Mode == enMode.Update && (_Appointment.DoctorID != (int)numaricDoctor.Value || _Appointment.AppointmentDateTime != DateTimeFromDateTimePicker || ((comboStatus.Text == "Confirmed" && comboStatus.Text != MyStatus) || (comboStatus.Text == "Pending" && comboStatus.Text != MyStatus) || (comboStatus.Text == "Rescheduled" && comboStatus.Text != MyStatus)))))
            {

                if (!_IsDoctorFree())
                {
                    MessageBox.Show("Sorry, the selected doctor already has an appointment scheduled at that time." +
                                                    "Please choose a different time slot or select a different doctor.", "Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

            }

            return true;
        }

        private void _SavedAppointmentInDatabase()
        {
            if (_Appointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Appointment";
                this._Mode = enMode.Update;

                _Appointment._Mode = clsAppointment.enMode.Update;
            }

            else
            {
                MessageBox.Show("Appointment Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillAppointmentWithData()
        {
            _Appointment.PatientID = (int)numaricPatientID.Value;

            _Appointment.DoctorID = (int)numaricDoctor.Value;

            _Appointment.StatusID = clsAppointmentStatus.FindStatus(comboStatus.Text).StatusID;

            _Appointment.AppointmentDateTime = new DateTime(dtpAppointmentDate.Value.Year,
                                                            dtpAppointmentDate.Value.Month, dtpAppointmentDate.Value.Day,
                                                            dtpAppointmentTime.Value.Hour, dtpAppointmentTime.Value.Minute,
                                                            dtpAppointmentTime.Value.Second, dtpAppointmentTime.Value.Millisecond);

            _Appointment.MedicalRecordID = string.IsNullOrWhiteSpace(lblMedicalRecordID.Text) ? -1 : int.Parse(lblMedicalRecordID.Text);

            _Appointment.PaymentID = string.IsNullOrWhiteSpace(lblPaymentID.Text) ? -1 : int.Parse(lblPaymentID.Text);
        }

        private void _ShowPaymentIDFromfrmAddEditPayment(int PaymentID)
        {
            lblPaymentID.Text = PaymentID.ToString();

            if (int.TryParse(lblPaymentID.Text, out int ID))
            {
                btnPay.Visible = false;
            }
        }

        private void _ShowMedicalRecordIDFromfrmAddEditPayment(int MedicalRecordID)
        {
            lblMedicalRecordID.Text = MedicalRecordID.ToString();

            if (int.TryParse(lblMedicalRecordID.Text, out int ID))
            {
                btnAddNewMedicalRecord.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paneltitle_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmAddEditAppointment_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void comboStatus_DropDown(object sender, EventArgs e)
        {
            if (isInitial)
            {
                comboStatus.Items.Remove("Select Status");
                comboStatus.SelectedIndex = 0;
                isInitial = false;
            }
        }

        private void lblMode_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numaricPatientID_ValueChanged(object sender, EventArgs e)
        {
            ucShowPatientDetails.LoadData((int)numaricPatientID.Value);
        }

        private void numaricDoctor_ValueChanged(object sender, EventArgs e)
        {
            ucShowDoctorDetails.LoadData((int)numaricDoctor.Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }
            else
            {
                _FillAppointmentWithData();
                _SavedAppointmentInDatabase();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmAddEditPayment AddNewPayment = new frmAddEditPayment(-1);
            AddNewPayment.DataBack += _ShowPaymentIDFromfrmAddEditPayment; // Subscribe to the event
            AddNewPayment.ShowDialog();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddNewMedicalRecord.Enabled = (comboStatus.Text == "Completed");
        }

        private void btnAddNewMedicalRecord_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalRecord AddNewMedicalRecord = new frmAddEditMedicalRecord(-1);
            AddNewMedicalRecord.DataBack += _ShowMedicalRecordIDFromfrmAddEditPayment; // Subscribe to the event
            AddNewMedicalRecord.ShowDialog();
        }
    }
}
