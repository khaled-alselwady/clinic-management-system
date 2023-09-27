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

namespace ClinicSystem_WindowsForms_.MedicalRecordsForms
{
    public partial class frmShowAllMedicalRecords : Form
    {
        public frmShowAllMedicalRecords()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            clsDragForm.ReleaseCapture();
            clsDragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmShowAllMedicalRecords_Load(object sender, EventArgs e)
        {
            ucTemplateDGV1.UpdateTitleName("All Medical Records");
            ucTemplateDGV1.RefreshDGV(clsMedicalRecord.GetAllMedicalRecords());
            ucTemplateDGV1.InvisibleButton();
        }
    }
}
