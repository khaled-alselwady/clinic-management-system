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

namespace ClinicSystem_WindowsForms_.PatientsForms
{
    public partial class frmShowMedicalRecordsOfPatient : Form
    {
        private int _PatientID;
        private string _PatientName;

        public frmShowMedicalRecordsOfPatient(int patientID, string PatientName)
        {
            InitializeComponent();
            _PatientID = patientID;
            _PatientName = PatientName;
        }

        private void frmShowMedicalRecordsOfPatient_Load(object sender, EventArgs e)
        {
            ucTemplateDGV1.UpdateTitleName(_PatientName + "'s Medical Records");
            ucTemplateDGV1.RefreshDGV(clsMedicalRecord.GetAllMedicalRecordsOfSpecificPatient(_PatientID));
            ucTemplateDGV1.UpdateButtonName("All Medical Records");
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
    }
}
