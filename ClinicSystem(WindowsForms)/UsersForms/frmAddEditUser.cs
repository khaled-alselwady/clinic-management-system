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

namespace ClinicSystem_WindowsForms_.UsersForms
{
    public partial class frmAddEditUser : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _UserID = -1;
        private clsUser _User;

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            if (_UserID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private void _FillgpPermissions()
        {
            if (_User.Permissions == -1)
            {
                foreach (CheckBox item in gbPermissions.Controls)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in gbPermissions.Controls)
                {

                    if ((Convert.ToInt32(item.Tag) & _User.Permissions) == Convert.ToInt32(item.Tag))
                    {
                        item.Checked = true;
                    }

                }
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

        private void _FillFieldsWithUserData()
        {
            if (_User != null)
            {
                txtPersonID.Text = _User.UserID.ToString();

                string[] arrName = _User.Name.Split();
                txtFirstName.Text = arrName[0];
                if (arrName.Length > 1)
                {
                    txtLastName.Text = arrName[1];
                }

                dtpDateOfBirth.Value = _User.DateOfBirth;

                if (_User.Gender == 'M')
                {
                    _ActivePanelMale();
                }
                else
                {
                    _ActivePanelFemale();
                }

                txtPhone.Text = _User.PhoneNumber;

                txtEmail.Text = _User.Email;

                txtAddress.Text = _User.Address;

                txtUsername.Text = _User.Username;
                txtPassword.Text = _User.Password;

                _FillgpPermissions();

            }
            else
            {
                MessageBox.Show("This User is not available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();

                lblMode.Text = "Add New User";

                this.Tag = "Add New User";

                return;
            }
            else
            {
                _User = clsUser.FindUser(_UserID);

                _FillFieldsWithUserData();

                lblMode.Text = "Update User";
                this.Tag = "Update User";

            }
        }

        private int _GetPermission()
        {
            int Permissions = 0;

            if (chkAll.Checked)
            {
                return -1;
            }

            if (chkPatients.Checked)
            {
                Permissions += Convert.ToInt32(clsUser.enPermissions.Patients);
            }
            if (chkDoctors.Checked)
            {
                Permissions += Convert.ToInt32(clsUser.enPermissions.Doctors);
            }
            if (chkAppointments.Checked)
            {
                Permissions += Convert.ToInt32(clsUser.enPermissions.Appointments);
            }
            if (chkPayments.Checked)
            {
                Permissions += Convert.ToInt32(clsUser.enPermissions.Payments);
            }
            if (chkUsers.Checked)
            {
                Permissions += Convert.ToInt32(clsUser.enPermissions.Users);
            }

            return Permissions;
        }

        private bool _IsDataCorrect()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtLastName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtPhone.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtUsername.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) ||
                (!radioFemale.Checked && !radioMale.Checked))

            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_GetPermission() == 0)
            {
                MessageBox.Show("you have to choose the Permissions.",
                  "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void _FillUserObject()
        {
            _User.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _User.DateOfBirth = dtpDateOfBirth.Value;

            if (radioMale.Checked)
            {
                _User.Gender = 'M';
            }
            else
            {
                _User.Gender = 'F';
            }

            _User.PhoneNumber = txtPhone.Text.Trim();
            _User.Email = txtEmail.Text.Trim();
            _User.Address = txtAddress.Text.Trim();

            _User.Username = txtUsername.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.Permissions = _GetPermission();
        }

        private void _SavePatient()
        {
            if (_User.Save())
            {
                MessageBox.Show("User Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update User";


                _User.UserMode = clsUser.enUserMode.Update;
                _User.PersonMode = clsPerson.enPersonMode.Update;

                txtPersonID.Text = _User.UserID.ToString();
            }
            else
            {
                MessageBox.Show("User Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _IsAllItemIsChecked()
        {
            foreach (CheckBox item in gbPermissions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if (!item.Checked)
                    {
                        return false;
                    }
                }
            }

            return true;
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

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
            txtAddress.BorderRadius = 20;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataCorrect())
            {
                return;
            }
            else
            {
                _FillUserObject();
                _SavePatient();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                chkAll.Checked = false;
            }
     
            if (!_IsAllItemIsChecked())
            {
                chkAll.Checked = false;
            }
            else
            {
                chkAll.Checked = true;
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                foreach (CheckBox item in gbPermissions.Controls)
                {
                    item.Checked = true;
                }
            }
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
    }
}
