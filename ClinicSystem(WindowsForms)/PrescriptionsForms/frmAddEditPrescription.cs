using ClinicSystem_BusinessLayer_;
using ClinicSystem_WindowsForms_.MedicalRecordsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_.PrescriptionsForms
{
    public partial class frmAddEditPrescription : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _PrescriptionID;
        private int _MedicalRecordID;
        private clsPrescription _Prescription;

        public frmAddEditPrescription(int PrescriptionID, int MedicalRecordID)
        {
            InitializeComponent();

            _PrescriptionID = PrescriptionID;
            _MedicalRecordID = MedicalRecordID;

            if (_PrescriptionID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private void _FillFieldWithData()
        {
            txtPrescriptionID.Text = _Prescription.PrescriptionID.ToString();
            txtMedicalRecordID.Text = _Prescription.MedicalRecordID.ToString();
            txtMedicationName.Text = _Prescription.MedicationName;
            txtDosage.Text = _Prescription.Dosage;
            txtFrequency.Text = _Prescription.Frequency;
            dtpStart.Value = _Prescription.StartDate;
            dtpEnd.Value = _Prescription.EndDate;
            txtSpecialInstructions.Text = _Prescription.SpecialInstructions;
        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                _Prescription = new clsPrescription();

                lblMode.Text = "Add New Prescription";

                return;
            }

            else
            {
                _Prescription = clsPrescription.FindPrescription(_PrescriptionID);

                lblMode.Text = "Update Prescription";

                _FillFieldWithData();
            }

        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtMedicationName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtDosage.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtFrequency.Text.Trim()))
            {
                MessageBox.Show("The input string is not in a valid format.",
                  "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpEnd.Value < dtpStart.Value)
            {
                MessageBox.Show("The end date should be after the start date!", "Date Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void _FillPrescriptionWithData()
        {
            _Prescription.MedicalRecordID = _MedicalRecordID;
            _Prescription.MedicationName = txtMedicationName.Text.Trim();
            _Prescription.Dosage = txtDosage.Text.Trim();
            _Prescription.Frequency = txtFrequency.Text.Trim();
            _Prescription.SpecialInstructions = txtSpecialInstructions.Text.Trim();
            _Prescription.StartDate = dtpStart.Value;
            _Prescription.EndDate = dtpEnd.Value;
        }

        private void _SavePrescription()
        {
            if (_Prescription.Save())
            {
                MessageBox.Show("Prescription Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Prescription";
                this._Mode = enMode.Update;

                _Prescription._Mode = clsPrescription.enMode.Update;

                txtPrescriptionID.Text = _Prescription.PrescriptionID.ToString();
                txtMedicalRecordID.Text = _Prescription.MedicalRecordID.ToString();
            }
            else
            {
                MessageBox.Show("Prescription Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmAddEditPrescription_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }
            else
            {
                _FillPrescriptionWithData();
                _SavePrescription();
            }
        }

        private void btnShowAllMedicalRecords_Click(object sender, EventArgs e)
        {
            frmShowAllMedicalRecords showAllMedicalRecords = new frmShowAllMedicalRecords();
            showAllMedicalRecords.ShowDialog();
        }

        private void btnShowAllPrescriptions_Click(object sender, EventArgs e)
        {
            frmShowAllPrescriptions ShowAllPrescriptions = new frmShowAllPrescriptions();
            ShowAllPrescriptions.ShowDialog();
        }
    }
}
