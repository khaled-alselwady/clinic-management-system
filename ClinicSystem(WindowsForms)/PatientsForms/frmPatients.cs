using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem_BusinessLayer_;

namespace ClinicSystem_WindowsForms_.PatientsFroms
{
    public partial class frmPatients : Form
    {
        public frmPatients()
        {
            InitializeComponent();
        }

        private void _FillComboSearch()
        {
            string[] arrSearch = new string[] { "PatientID", "Name" };

            ucTemplateDGVAndSearch1.FillComboSearch(arrSearch);
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            ucTemplateDGVAndSearch1.RefreshDGV(clsPatient.GetAllPatients());
            ucTemplateDGVAndSearch1.AddImagesToDataGridView(7, 8);  // 7: Edit Column Index, 8: Delete Column Index

            _FillComboSearch();
        }
    }
}
