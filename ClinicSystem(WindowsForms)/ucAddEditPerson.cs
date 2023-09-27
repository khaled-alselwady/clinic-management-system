using ClinicSystem_BusinessLayer_;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_
{
    public partial class ucAddEditPerson : UserControl
    {
        private clsPatient _Patient;
        private clsDoctor _Doctor;

        private enum enFormMode { Patient, Doctor }
        private enFormMode _FormMode = enFormMode.Patient;
        private string _FormName;

        private enum enAddEditMode { AddNew, Update }
        private enAddEditMode _AddEditMode = enAddEditMode.AddNew;

        private ToolTip toolTip1;

        public ucAddEditPerson(string formName)
        {
            InitializeComponent();

            _FormName = formName;

            if (_FormName == "frmDoctors")
            {
                _FormMode = enFormMode.Doctor;
            }
            if (_FormName == "frmPatients")
            {
                _FormMode = enFormMode.Patient;
            }

            toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000; // Duration of tooltip display
            toolTip1.InitialDelay = 0; // Delay before showing tooltip
            toolTip1.ReshowDelay = 0;   // Delay before reshowing tooltip

            // Set tooltip text for the TextBox control
            toolTip1.SetToolTip(txtPersonID, "This field is Read Only!");

        }

        private void _LoadDataInAddNewMode()
        {
            switch (_FormMode)
            {

                case enFormMode.Patient:
                    _Patient = new clsPatient();
                    lblMode.Text = "Add New Patient";
                    lblPersonID.Text = "Patient ID:";
                    return;

                case enFormMode.Doctor:
                    _Doctor = new clsDoctor();
                    lblMode.Text = "Add New Doctor";
                    lblPersonID.Text = "Doctor ID:";
                    txtSpecialization.Visible = true;
                    lblSpecialization.Visible = true;
                    return;

            }
        }

        private void _LoadDataInUpdateMode(int ID)
        {
            switch (_FormMode)
            {
                case enFormMode.Patient:
                    _Patient = clsPatient.FindPatient(ID);
                    lblMode.Text = "Update Patient";
                    lblPersonID.Text = "Patient ID:";
                    _FillFieldsWithPatientData();
                    break;

                case enFormMode.Doctor:
                    _Doctor = clsDoctor.FindDoctor(ID);
                    lblMode.Text = "Update Doctor";
                    lblPersonID.Text = "Doctor ID:";
                    txtSpecialization.Visible = true;
                    lblSpecialization.Visible = true;
                    _FillFieldsWithDoctorData();
                    break;
            }
        }

        private void _ActivePanelMale()
        {
            radioMale.Checked = true;

            panelMale.BorderColor = Color.FromArgb(94, 148, 255);
            panelFemale.BorderColor = Color.FromArgb(64, 64, 64);

            if (radioFemale.Checked)
            {
                radioFemale.Checked = false;
            }
        }

        private void _ActivePanelFemale()
        {
            radioFemale.Checked = true;

            panelFemale.BorderColor = Color.FromArgb(94, 148, 255);
            panelMale.BorderColor = Color.FromArgb(64, 64, 64);

            if (radioMale.Checked)
            {
                radioMale.Checked = false;
            }
        }

        private void _FillFieldsWithPatientData()
        {
            if (_Patient != null)
            {
                txtPersonID.Text = _Patient.PatientID.ToString();

                string[] arrName = _Patient.Name.Split();
                txtFirstName.Text = arrName[0];
                if (arrName.Length > 1)
                {
                    txtLastName.Text = arrName[1];
                }

                dtpDateOfBirth.Value = _Patient.DateOfBirth;

                if (_Patient.Gender == 'M')
                {
                    _ActivePanelMale();
                }
                else
                {
                    _ActivePanelFemale();
                }

                txtPhone.Text = _Patient.PhoneNumber;

                txtEmail.Text = _Patient.Email;

                txtAddress.Text = _Patient.Address;
            }
            else
            {
                MessageBox.Show("This patient is not available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillFieldsWithDoctorData()
        {
            if (_Doctor != null)
            {
                txtPersonID.Text = _Doctor.DoctorID.ToString();

                string[] arrName = _Doctor.Name.Split();
                txtFirstName.Text = arrName[0];
                if (arrName.Length > 1)
                {
                    txtLastName.Text = arrName[1];
                }

                dtpDateOfBirth.Value = _Doctor.DateOfBirth;

                if (_Doctor.Gender == 'M')
                {
                    _ActivePanelMale();
                }
                else
                {
                    _ActivePanelFemale();
                }

                txtPhone.Text = _Doctor.PhoneNumber;

                txtEmail.Text = _Doctor.Email;

                txtAddress.Text = _Doctor.Address;

                txtSpecialization.Text = _Doctor.Specialization;
            }
            else
            {
                MessageBox.Show("This doctor is not available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillPatientObject()
        {
            _Patient.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Patient.DateOfBirth = dtpDateOfBirth.Value;

            if (radioMale.Checked)
            {
                _Patient.Gender = 'M';
            }
            else
            {
                _Patient.Gender = 'F';
            }

            _Patient.PhoneNumber = txtPhone.Text.Trim();
            _Patient.Email = txtEmail.Text.Trim();
            _Patient.Address = txtAddress.Text.Trim();
        }

        private void _FillDoctorObject()
        {
            _Doctor.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Doctor.DateOfBirth = dtpDateOfBirth.Value;

            if (radioMale.Checked)
            {
                _Doctor.Gender = 'M';
            }
            else
            {
                _Doctor.Gender = 'F';
            }

            _Doctor.PhoneNumber = txtPhone.Text.Trim();
            _Doctor.Email = txtEmail.Text.Trim();
            _Doctor.Address = txtAddress.Text.Trim();
            _Doctor.Specialization = txtSpecialization.Text.Trim();
        }

        private void _SavePatient()
        {
            if (_Patient.Save())
            {
                MessageBox.Show("Patient Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Patient";
                this._AddEditMode = enAddEditMode.Update;

                _Patient.PatientMode = clsPatient.enPatientMode.Update;
                _Patient.PersonMode = clsPerson.enPersonMode.Update;

                txtPersonID.Text = _Patient.PatientID.ToString();
            }
            else
            {
                MessageBox.Show("Patient Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _SaveDoctor()
        {
            if (_Doctor.Save())
            {
                MessageBox.Show("Doctor Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Doctor";
                this._AddEditMode = enAddEditMode.Update;

                _Doctor.DoctorMode = clsDoctor.enDoctorMode.Update;
                _Doctor.PersonMode = clsPerson.enPersonMode.Update;

                txtPersonID.Text = _Doctor.DoctorID.ToString();
            }
            else
            {
                MessageBox.Show("Doctor Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtLastName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtPhone.Text.Trim()) ||
                (!radioFemale.Checked && !radioMale.Checked) ||
                (_FormMode == enFormMode.Doctor && string.IsNullOrWhiteSpace(txtSpecialization.Text.Trim())))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void _OnlyNumbersInTextBox(KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Allow digits and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isBackspace)
            {
                e.Handled = true;
            }
        }

        public void LoadDate(int ID)
        {
            if (ID == -1)
            {
                _AddEditMode = enAddEditMode.AddNew;

                _LoadDataInAddNewMode();
            }

            else
            {
                _AddEditMode = enAddEditMode.Update;

                _LoadDataInUpdateMode(ID);
            }
        }

        private void ucAddEditPerson_Load(object sender, EventArgs e)
        {
            txtAddress.BorderRadius = 20;
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

        private void panelMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void lblMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void radioMale_Click(object sender, EventArgs e)
        {
            _ActivePanelMale();
        }

        private void panelFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void radioFemale_Click(object sender, EventArgs e)
        {
            _ActivePanelFemale();
        }

        private void dtpDateOfBirth_MouseEnter(object sender, EventArgs e)
        {
            dtpDateOfBirth.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            dtpDateOfBirth.BorderColor = Color.FromArgb(94, 148, 255);
        }

        private void dtpDateOfBirth_MouseLeave(object sender, EventArgs e)
        {
            dtpDateOfBirth.HoverState.BorderColor = Color.FromArgb(64, 64, 64);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }

            else
            {
                switch (_FormMode)
                {
                    case enFormMode.Patient:
                        _FillPatientObject();
                        _SavePatient();
                        break;


                    case enFormMode.Doctor:
                        _FillDoctorObject();
                        _SaveDoctor();
                        break;
                }


            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            _OnlyNumbersInTextBox(e);
        }
    }
}
