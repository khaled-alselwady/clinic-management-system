using ClinicSystem_BusinessLayer_;
using ClinicSystem_WindowsForms_.AppointmentsForms;
using ClinicSystem_WindowsForms_.DashboardForms;
using ClinicSystem_WindowsForms_.DoctorsForms;
using ClinicSystem_WindowsForms_.LoginForms;
using ClinicSystem_WindowsForms_.PatientsFroms;
using ClinicSystem_WindowsForms_.PaymentForms;
using ClinicSystem_WindowsForms_.UsersForms;
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
    public partial class frmMainMenu : Form
    {
        private int _UserID = -1;
        private clsUser _User;

        public Form frmDeniedMassage = new frmAccessDenied();

        public frmMainMenu(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            _User = clsUser.FindUser(_UserID);
        }

        private bool _CheckAccessDenied(clsUser.enPermissions enPermissions)
        {

            if (this._User.Permissions == (int)clsUser.enPermissions.All)
            {
                return true;
            }


            if (((int)enPermissions & this._User.Permissions) == (int)enPermissions)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            if (!_CheckAccessDenied(clsUser.enPermissions.Patients))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            clsOpenChildForm.OpenChildFormInPanel(new frmPatients(), panelChildForm, lblTitleChildForm, sender, panelMenu, IconCurrentChildForm);
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            if (!_CheckAccessDenied(clsUser.enPermissions.Doctors))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            clsOpenChildForm.OpenChildFormInPanel(new frmDoctors(), panelChildForm, lblTitleChildForm, sender, panelMenu, IconCurrentChildForm);
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            if (!_CheckAccessDenied(clsUser.enPermissions.Appointments))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            clsOpenChildForm.OpenChildFormInPanel(new frmAppointments(), panelChildForm, lblTitleChildForm, sender, panelMenu, IconCurrentChildForm);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (!_CheckAccessDenied(clsUser.enPermissions.Payments))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            clsOpenChildForm.OpenChildFormInPanel(new frmPayments(), panelChildForm, lblTitleChildForm, sender, panelMenu, IconCurrentChildForm);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!_CheckAccessDenied(clsUser.enPermissions.Users))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            clsOpenChildForm.OpenChildFormInPanel(new frmUsers(), panelChildForm, lblTitleChildForm, sender, panelMenu, IconCurrentChildForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLoginScreen LoginScreen = new frmLoginScreen();
            LoginScreen.Show();
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmDashboard(), panelChildForm, lblTitleChildForm, sender, panelMenu, IconCurrentChildForm);
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            clsOpenChildForm.OpenChildFormInPanel(new frmDashboard(), panelChildForm, lblTitleChildForm);
            btnDashboard.BackColor = Color.FromArgb(12, 76, 125);
            IconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
        }
    }
}
