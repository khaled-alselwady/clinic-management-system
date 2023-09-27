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
    public partial class frmAddEditPatient : Form
    {

        private int _PatientID;

        public frmAddEditPatient(int patientID)
        {
            InitializeComponent();

            _PatientID = patientID;
        }

        private void frmAddEditPatient_Load(object sender, EventArgs e)
        {
            ucAddEditPerson1.LoadDate(_PatientID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
