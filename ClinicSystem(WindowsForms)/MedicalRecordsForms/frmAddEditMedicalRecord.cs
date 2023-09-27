using ClinicSystem_BusinessLayer_;
using ClinicSystem_WindowsForms_.PrescriptionsForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_.MedicalRecordsForms
{
    public partial class frmAddEditMedicalRecord : Form
    {

        public delegate void DataBackEventHandler(int MedicalRecordID);

        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _MedicalRecordID;
        private clsMedicalRecord _MedicalRecord;

        private ToolTip toolTip1;

        public frmAddEditMedicalRecord(int MedicalRecordID)
        {
            InitializeComponent();

            _MedicalRecordID = MedicalRecordID;

            if (_MedicalRecordID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

            toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000; // Duration of tooltip display
            toolTip1.InitialDelay = 0; // Delay before showing tooltip
            toolTip1.ReshowDelay = 0;   // Delay before reshowing tooltip

            // Set tooltip text for the TextBox control
            toolTip1.SetToolTip(txtMedicalRecordID, "This field is Read Only!");
        }

        private void _FillFieldWithData()
        {
            txtMedicalRecordID.Text = _MedicalRecord.MedicalRecordID.ToString();
            txtVisitDescription.Text = _MedicalRecord.VisitDescription;
            txtDiagnosis.Text = _MedicalRecord.Diagnosis;
            txtNotes.Text = _MedicalRecord.AdditionalNotes;
        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                _MedicalRecord = new clsMedicalRecord();

                lblMode.Text = "Add New Medical Record";

                return;
            }

            else
            {
                _MedicalRecord = clsMedicalRecord.FindMedicalRecord(_MedicalRecordID);

                if (_MedicalRecord == null)
                {
                    MessageBox.Show("There is no Medical Record with this ID!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                lblMode.Text = "Update Medical Record";

                _FillFieldWithData();
            }
        }

        private void _FillMedicalRecordWithData()
        {
            _MedicalRecord.VisitDescription = txtVisitDescription.Text.Trim();
            _MedicalRecord.Diagnosis = txtDiagnosis.Text.Trim();
            _MedicalRecord.AdditionalNotes = txtNotes.Text.Trim();
        }

        private void _SaveMedicalRecord()
        {
            if (_MedicalRecord.Save())
            {
                MessageBox.Show("Medical Record Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Medical Record";
                this._Mode = enMode.Update;

                _MedicalRecord._Mode = clsMedicalRecord.enMode.Update;

                txtMedicalRecordID.Text = _MedicalRecord.MedicalRecordID.ToString();

                // Trigger the event to send PaymentID to frmAddEditAppointment
                DataBack?.Invoke(_MedicalRecord.MedicalRecordID);

                btnAddPrescription.Enabled = true;
            }
            else
            {
                MessageBox.Show("Medical Record Saved Failed.", "Failed",
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

        private void textbox_MouseEnter(object sender, EventArgs e)
        {
            // Show the tooltip when the mouse enters the TextBox
            toolTip1.Show(toolTip1.GetToolTip(((Guna2TextBox)sender)), ((Guna2TextBox)sender));
        }

        private void textbox_MouseLeave(object sender, EventArgs e)
        {
            // Hide the tooltip when the mouse leaves the TextBox
            toolTip1.Hide(((Guna2TextBox)sender));
        }

        private void frmAddEditMedicalRecord_Load(object sender, EventArgs e)
        {
            txtNotes.BorderRadius = 20;
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillMedicalRecordWithData();
            _SaveMedicalRecord();
        }

        private void btnAddPrescription_Click(object sender, EventArgs e)
        {
            if (_MedicalRecord.MedicalRecordID != -1)
            {
                frmAddEditPrescription AddEditPrescription = new frmAddEditPrescription(-1, _MedicalRecord.MedicalRecordID);
                AddEditPrescription.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to add a correct medical record first!", "Error Medical Record",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
