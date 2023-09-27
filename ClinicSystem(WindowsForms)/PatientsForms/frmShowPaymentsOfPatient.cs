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
    public partial class frmShowPaymentsOfPatient : Form
    {

        private int _PatientID;
        private string _PatientName;

        public frmShowPaymentsOfPatient(int patientID, string patientName)
        {
            InitializeComponent();
            _PatientID = patientID;
            _PatientName = patientName;
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

        private void frmShowPaymentsOfPatient_Load(object sender, EventArgs e)
        {
            ucTemplateDGV1.UpdateTitleName(_PatientName + "'s Payments");
            ucTemplateDGV1.RefreshDGV(clsPayment.GetAllPaymentsOfSpecificPatient(_PatientID));
            ucTemplateDGV1.UpdateButtonName("All Payments");
        }
    }
}
