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

namespace ClinicSystem_WindowsForms_
{
    public partial class ucShowPersonDetails : UserControl
    {

        private enum enUCMode { Patient, Doctor }
        private enUCMode _UCMode = enUCMode.Patient;

        private clsPatient _Patient;

        private clsDoctor _Doctor;

        public ucShowPersonDetails()
        {
            InitializeComponent();
        }

        public ucShowPersonDetails(string Mode)
        {
            InitializeComponent();

            switch (Mode)
            {
                case "Patient":
                    _UCMode = enUCMode.Patient;
                    break;


                case "Doctor":
                    _UCMode = enUCMode.Doctor;
                    break;
            }
        }

        public void UpdateNameOfGroupBox(string Name)
        {
            gbPersonDetails.Text = Name;

            if (Name.Contains("Doctor"))
            {
                lblPersonID.Text = "Doctor ID:";
                lblSpecialization.Visible = true;
                lblSpecializationName.Visible = true;
            }
        }

        private void _EmptyData()
        {
            lblPersonIDNumber.Text = "???";
            lblName.Text = "???";
            lblDateOfBirth.Text = "???";
            lblGender.Text = "???";
            lblPhone.Text = "???";
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblSpecializationName.Text = "???";
        }

        private void _LoadPatientData(int PatientID)
        {
            _Patient = clsPatient.FindPatient(PatientID);

            if (_Patient != null)
            {
                lblPersonIDNumber.Text = _Patient.PatientID.ToString();
                lblName.Text = _Patient.Name;
                lblDateOfBirth.Text = _Patient.DateOfBirth.ToString("yyyy-MM-dd");

                if (_Patient.Gender == 'M')
                {
                    lblGender.Text = "Male";
                }
                else
                {
                    lblGender.Text = "Female";
                }

                lblPhone.Text = _Patient.PhoneNumber.ToString();
                lblEmail.Text = _Patient.Email;
                lblAddress.Text = _Patient.Address;
            }
            else
            {
                _EmptyData();
            }
        }

        private void _LoadDoctorData(int DoctorID)
        {
            _Doctor = clsDoctor.FindDoctor(DoctorID);

            if (_Doctor != null)
            {
                lblPersonIDNumber.Text = _Doctor.DoctorID.ToString();
                lblName.Text = _Doctor.Name;
                lblDateOfBirth.Text = _Doctor.DateOfBirth.ToString("yyyy-MM-dd");

                if (_Doctor.Gender == 'M')
                {
                    lblGender.Text = "Male";
                }
                else
                {
                    lblGender.Text = "Female";
                }

                lblPhone.Text = _Doctor.PhoneNumber.ToString();
                lblEmail.Text = _Doctor.Email;
                lblAddress.Text = _Doctor.Address;
                lblSpecializationName.Text = _Doctor.Specialization;
            }
            else
            {
                _EmptyData();
            }
        }

        public void LoadData(int PersonID)
        {
            switch (_UCMode)
            {

                case enUCMode.Patient:
                    _LoadPatientData(PersonID);
                    lblPersonID.Text = "Patient ID:";
                    lblSpecialization.Visible = false;
                    lblSpecializationName.Visible = false;
                    gbPersonDetails.Text = "Patient Details";
                    break;

                case enUCMode.Doctor:
                    _LoadDoctorData(PersonID);
                    lblPersonID.Text = "Doctor ID:";
                    lblSpecialization.Visible = true;
                    lblSpecializationName.Visible = true;
                    gbPersonDetails.Text = "Doctor Details";
                    break;

            }
        }


    }
}
