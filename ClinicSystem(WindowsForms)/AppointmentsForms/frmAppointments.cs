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
    public partial class frmAppointments : Form
    {
        public frmAppointments()
        {
            InitializeComponent();
        }

        private void _FillComboSearch()
        {
            string[] arrSearch = new string[] { "AppointmentID", "PatientID", "DoctorID" };

            ucTemplateDGVAndSearch1.FillComboSearch(arrSearch);
        }

        private void frmAppointments_Load(object sender, EventArgs e)
        {
            ucTemplateDGVAndSearch1.RefreshDGV(clsAppointment.GetAllAppointments());
            ucTemplateDGVAndSearch1.AddImagesToDataGridView(7, 8);  // 7: Edit Column Index, 8: Delete Column Index

            _FillComboSearch();
        }
    }
}
