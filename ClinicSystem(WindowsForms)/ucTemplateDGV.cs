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

namespace ClinicSystem_WindowsForms_
{
    public partial class ucTemplateDGV : UserControl
    {
        public ucTemplateDGV()
        {
            InitializeComponent();
        }

        private void _IsDGVEmpty()
        {
            if (dgvShowList.Rows.Count < 1)
            {
                if (lblTitle.Text.Contains("Medical"))
                {
                    MessageBox.Show("There is no medical record for this patient!", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lblTitle.Text.Contains("Payments"))
                {
                    MessageBox.Show("There is no Payment record for this patient!", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lblTitle.Text.Contains("Prescriptions"))
                {
                    MessageBox.Show("There is no Prescription record for this patient!", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }

        public void RefreshDGV(object DataSource)
        {
            dgvShowList.DataSource = DataSource;
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowList);

            _IsDGVEmpty();
        }

        public void UpdateTitleName(string Name)
        {
            lblTitle.Text = Name;
        }

        public void UpdateButtonName(string ButtonName)
        {
            btnShowAll.Text = ButtonName;
        }

        public void InvisibleButton()
        {
            btnShowAll.Visible = false;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (btnShowAll.Text.Contains("Medical"))
            {
                dgvShowList.DataSource = clsMedicalRecord.GetAllMedicalRecords();
                lblTitle.Text = "             All Medical Records";
                return;
            }

            if (btnShowAll.Text.Contains("Prescriptions"))
            {
                dgvShowList.DataSource = clsPrescription.GetAllPrescriptions();
                lblTitle.Text = "             All Prescriptions";
                return;
            }

            if (btnShowAll.Text.Contains("Payments"))
            {
                dgvShowList.DataSource = clsPayment.GetAllPayments();
                lblTitle.Text = "             All Payments";
                return;
            }
        }

        private void dgvShowList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            // Determine the bounds of the row header
            Rectangle rowHeaderBounds = new Rectangle(
                dataGridView.RowHeadersWidth - 40,  // Adjust this value to control the position
                e.RowBounds.Top,
                dataGridView.RowHeadersWidth,
                e.RowBounds.Height);

            // Fill the row header with a custom color
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(7, 43, 71)))  // Replace with your desired color
            {
                e.Graphics.FillRectangle(brush, rowHeaderBounds);
            }
        }
    }
}
