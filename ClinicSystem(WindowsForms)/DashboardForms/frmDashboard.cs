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

namespace ClinicSystem_WindowsForms_.DashboardForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblNumberOfPatients.Text = clsPatient.GetTotalPatients().ToString();
            lblNumberOfDoctors.Text = clsDoctor.GetTotalDoctors().ToString();
            lblNumberOfAppointments.Text = clsAppointment.GetTotalAppointments().ToString();
            lblNumberOfUsers.Text = clsUser.GetTotalUsers().ToString();
            lblDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
