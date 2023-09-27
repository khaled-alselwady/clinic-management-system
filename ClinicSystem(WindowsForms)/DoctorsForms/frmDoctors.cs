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

namespace ClinicSystem_WindowsForms_.DoctorsForms
{
    public partial class frmDoctors : Form
    {
        public frmDoctors()
        {
            InitializeComponent();
        }

        private void _FillComboSearch()
        {
            string[] arrSearch = new string[] { "DoctorID", "Name" };

            ucTemplateDGVAndSearch1.FillComboSearch(arrSearch);
        }

        private void frmDoctors_Load(object sender, EventArgs e)
        {
            ucTemplateDGVAndSearch1.RefreshDGV(clsDoctor.GetAllDoctors());
            ucTemplateDGVAndSearch1.AddImagesToDataGridView(8, 9);  // 8: Edit Column Index, 9: Delete Column Index

            _FillComboSearch();
        }
    }
}
