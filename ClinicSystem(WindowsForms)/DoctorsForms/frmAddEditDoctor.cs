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
    public partial class frmAddEditDoctor : Form
    {

        private int _DoctorID;

        public frmAddEditDoctor(int doctorID)
        {
            InitializeComponent();
            _DoctorID = doctorID;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditDoctor_Load(object sender, EventArgs e)
        {
            ucAddEditPerson1.LoadDate(_DoctorID);
        }
    }
}
