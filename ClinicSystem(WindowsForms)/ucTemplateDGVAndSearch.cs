using ClinicSystem_BusinessLayer_;
using ClinicSystem_WindowsForms_.AppointmentsForms;
using ClinicSystem_WindowsForms_.DoctorsForms;
using ClinicSystem_WindowsForms_.PatientsForms;
using ClinicSystem_WindowsForms_.PaymentForms;
using ClinicSystem_WindowsForms_.Properties;
using ClinicSystem_WindowsForms_.UsersForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_
{
    public partial class ucTemplateDGVAndSearch : UserControl
    {

        private int EditIndex = -1;
        private int DeleteIndex = -1;

        private enum enModeUC { Patient, Doctor, Appointment, Payment, User }
        private enModeUC _ModeUC = enModeUC.Patient;

        private string _FormName;

        public ucTemplateDGVAndSearch()
        {
            InitializeComponent();
        }

        public ucTemplateDGVAndSearch(string FormName)
        {
            InitializeComponent();

            _FormName = FormName;

            switch (_FormName)
            {

                case "frmDoctors":
                    _ModeUC = enModeUC.Doctor;
                    _HideContextStripMenu();
                    break;

                case "frmPatients":
                    _ModeUC = enModeUC.Patient;
                    _ShowContextStripMenuWithoutAppointmentDetails();
                    break;

                case "frmAppointments":
                    _ModeUC = enModeUC.Appointment;
                    _ShowOnlyAppointmentDetailsInContextStripMenu();
                    break;

                case "frmPayments":
                    _ModeUC = enModeUC.Payment;
                    _HideContextStripMenu();
                    break;

                case "frmUsers":
                    _ModeUC = enModeUC.User;
                    _HideContextStripMenu();
                    break;
            }
        }

        private void _OpenAddEditForm(int ID)
        {
            switch (_ModeUC)
            {
                case enModeUC.Patient:
                    frmAddEditPatient AddEditPatient = new frmAddEditPatient(ID);
                    AddEditPatient.ShowDialog();
                    RefreshDGV(clsPatient.GetAllPatients());
                    break;


                case enModeUC.Doctor:
                    frmAddEditDoctor AddEditDoctor = new frmAddEditDoctor(ID);
                    AddEditDoctor.ShowDialog();
                    RefreshDGV(clsDoctor.GetAllDoctors());
                    break;


                case enModeUC.Appointment:
                    frmAddEditAppointment AddEditAppointment = new frmAddEditAppointment(ID);
                    AddEditAppointment.ShowDialog();
                    RefreshDGV(clsAppointment.GetAllAppointments());
                    break;


                case enModeUC.Payment:
                    frmAddEditPayment AddEditPayment = new frmAddEditPayment(ID);
                    AddEditPayment.ShowDialog();
                    RefreshDGV(clsPayment.GetAllPayments());
                    break;

                case enModeUC.User:
                    frmAddEditUser AddEditUser = new frmAddEditUser(ID);
                    AddEditUser.ShowDialog();
                    RefreshDGV(clsUser.GetAllUsers());
                    break;

            }
        }

        private void _DeletePatient(int ID)
        {
            if (MessageBox.Show("Do you really want to delete this Patient?!", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsPatient.DeletePatient(ID))
                {
                    MessageBox.Show("Patient Deleted Successfully.", "Delete Patient",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDGV(clsPatient.GetAllPatients());
                }
                else
                {
                    MessageBox.Show("Patient Deleted Failed!, This Patient associated with other tables, so you cannot delete it now", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _DeleteDoctor(int ID)
        {
            if (MessageBox.Show("Do you really want to delete this Doctor?!", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsDoctor.DeleteDoctor(ID))
                {
                    MessageBox.Show("Doctor Deleted Successfully.", "Delete Doctor",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDGV(clsDoctor.GetAllDoctors());
                }
                else
                {
                    MessageBox.Show("Doctor Deleted Failed!, This Doctor associated with other tables, so you cannot delete it now", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _DeleteAppointment(int ID)
        {
            if (MessageBox.Show("Do you really want to delete this Appointment?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsAppointment.DeleteAppointment(ID))
                {
                    MessageBox.Show("Appointment Deleted Successfully.", "Delete Appointment",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDGV(clsAppointment.GetAllAppointments());
                }
                else
                {
                    MessageBox.Show("Appointment Deleted Failed!, This Appointment associated with other tables, so you cannot delete it now", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _DeletePayment(int ID)
        {
            if (MessageBox.Show("Do you really want to delete this Payment?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsPayment.DeletePayment(ID))
                {
                    MessageBox.Show("Payment Deleted Successfully.", "Delete Payment",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDGV(clsPayment.GetAllPayments());
                }
                else
                {
                    MessageBox.Show("Payment Deleted Failed!, This Payment associated with other tables, so you cannot delete it now", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _DeleteUser(int ID)
        {
            if (MessageBox.Show("Do you really want to delete this User?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsUser.DeleteUser(ID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Delete User",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDGV(clsUser.GetAllUsers());
                }
                else
                {
                    MessageBox.Show("User Deleted Failed!, This User associated with other tables, so you cannot delete it now", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _PerformDeletingPerson(int ID)
        {
            switch (_ModeUC)
            {
                case enModeUC.Patient:
                    _DeletePatient(ID);
                    break;

                case enModeUC.Doctor:
                    _DeleteDoctor(ID);
                    break;

                case enModeUC.Appointment:
                    _DeleteAppointment(ID);
                    break;

                case enModeUC.Payment:
                    _DeletePayment(ID);
                    break;

                case enModeUC.User:
                    _DeleteUser(ID);
                    break;
            }
        }

        private int _GetIDFromDGV()
        {
            int ID = -1;

            if (dgvShowList.CurrentCell == null)
            {
                return ID;
            }

            switch (_ModeUC)
            {
                case enModeUC.Patient:
                    ID = (int)dgvShowList.CurrentRow.Cells["PatientID"].Value;
                    break;

                case enModeUC.Doctor:
                    ID = (int)dgvShowList.CurrentRow.Cells["DoctorID"].Value;
                    break;

                case enModeUC.Appointment:
                    ID = (int)dgvShowList.CurrentRow.Cells["AppointmentID"].Value;
                    break;

                case enModeUC.Payment:
                    ID = (int)dgvShowList.CurrentRow.Cells["PaymentID"].Value;
                    break;

                case enModeUC.User:
                    ID = (int)dgvShowList.CurrentRow.Cells["UserID"].Value;
                    break;
            }

            return ID;
        }

        private void _ShowContextStripMenuWithoutAppointmentDetails()
        {
            foreach (ToolStripMenuItem Item in contextMenuStrip1.Items)
            {
                if (Item.Text != "Show Appointment Details")
                {
                    Item.Visible = true;
                }
                else
                {
                    Item.Visible = false;
                }
            }
        }

        private void _HideContextStripMenu()
        {
            foreach (ToolStripMenuItem Item in contextMenuStrip1.Items)
            {
                Item.Visible = false;
            }
        }

        private void _ShowOnlyAppointmentDetailsInContextStripMenu()
        {
            foreach (ToolStripMenuItem Item in contextMenuStrip1.Items)
            {
                if (Item.Text == "Show Appointment Details")
                {
                    Item.Visible = true;
                }
                else
                {
                    Item.Visible = false;
                }
            }
        }

        private void _SearchDataByID(string ID)
        {

            switch (_ModeUC)
            {
                case enModeUC.Patient:
                    dgvShowList.DataSource = clsPatient.SearchPatientsContainByPatientID(ID);
                    break;


                case enModeUC.Doctor:
                    dgvShowList.DataSource = clsDoctor.SearchDoctorsContainByDoctorID(ID);
                    break;


                case enModeUC.Appointment:
                    dgvShowList.DataSource = clsAppointment.SearchAppointmentsContainByAppointmentID(ID);
                    break;


                case enModeUC.Payment:
                    dgvShowList.DataSource = clsPayment.SearchPaymentsContainByPaymentID(ID);
                    break;


                case enModeUC.User:
                    dgvShowList.DataSource = clsUser.SearchUsersContainByUserID(ID);
                    break;
            }
        }

        private void _SearchAppointmentDataByPatientID(string PatientID)
        {
            dgvShowList.DataSource = clsAppointment.SearchAppointmentsContainByPatientID(PatientID);
        }

        private void _SearchAppointmentDataByDoctorID(string DoctorID)
        {
            dgvShowList.DataSource = clsAppointment.SearchAppointmentsContainByDoctorID(DoctorID);
        }

        private void _SearchDataByName(string Name)
        {
            dgvShowList.DataSource = (_ModeUC == enModeUC.Patient) ? clsPatient.SearchPatientsContainByName(Name) : clsDoctor.SearchDoctorsContainByName(Name);
        }

        private void _SearchDataByPaymentMethod(string PaymentMethod)
        {
            dgvShowList.DataSource = clsPayment.SearchPaymentsContainByPaymentMethod(PaymentMethod);
        }

        private void _SearchDataByUsername(string Username)
        {
            dgvShowList.DataSource = clsUser.SearchUsersContainByUsername(Username);
        }

        public void _HideAddNewButton()
        {
            btnAddNew.Visible = false;
        }

        public void AddImagesToDataGridView(int EditIndex, int DeleteIndex)
        {
            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            EditColumn.Name = "     "; // Set the column name
            EditColumn.Image = Resources.Edit;
            EditColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowList.Columns.Insert(EditIndex, EditColumn);


            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();
            DeleteColumn.Name = "     ";
            DeleteColumn.Image = Resources.delete;
            DeleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust the image layout as needed
            dgvShowList.Columns.Insert(DeleteIndex, DeleteColumn);

            this.EditIndex = EditIndex;
            this.DeleteIndex = DeleteIndex;
        }

        public void DeleteProductImageColumn(int EditIndex, int DeleteIndex)
        {
            if ((dgvShowList.Columns.Contains("     "))
                && dgvShowList.Columns.Count <= 2)
            {
                DataGridViewColumn columnToDelete = dgvShowList.Columns["     "];
                dgvShowList.Columns.Remove(columnToDelete);

                columnToDelete = dgvShowList.Columns["     "];
                dgvShowList.Columns.Remove(columnToDelete);
            }

            if (dgvShowList.Columns.Count > 2 && !dgvShowList.Columns.Contains("     "))
            {
                AddImagesToDataGridView(EditIndex, DeleteIndex);
            }
        }

        public void ChangeSelectionCellInDataGridView()
        {
            dgvShowList.ClearSelection(); // Clear any existing selections

            int desiredRowIndex = 0; // Change this to the desired row index

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvShowList.Rows.Count)
            {
                dgvShowList.Rows[desiredRowIndex].Cells[comboSearch.Text].Selected = true;
            }
        }

        public void RefreshDGV(object DataSource)
        {
            dgvShowList.DataSource = DataSource;
            clsChangeHeaderColorOfDataGridView.ChangeHeaderColorOfDataGridView(dgvShowList);
        }

        public void FillComboSearch(string[] arrChoices)
        {
            comboSearch.Items.Clear();

            foreach (string choice in arrChoices)
            {
                comboSearch.Items.Add(choice);
            }

            if (comboSearch.Items.Count > 0)
            {
                comboSearch.SelectedIndex = 0;
            }
        }

        private void combobox_MouseEnter(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(12, 76, 125);
        }

        private void combobox_MouseLeave(object sender, EventArgs e)
        {
            ((Guna2ComboBox)sender).BorderColor = Color.FromArgb(64, 64, 64);
        }

        private void btnAddNew_MouseEnter(object sender, EventArgs e)
        {
            btnAddNew.FlatAppearance.BorderColor = Color.FromArgb(12, 76, 125);
        }

        private void btnAddNew_MouseLeave(object sender, EventArgs e)
        {
            btnAddNew.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "PatientID":
                    if (_ModeUC == enModeUC.Appointment)
                    {
                        _SearchAppointmentDataByPatientID(txtSearch.Text.Trim());
                    }
                    else
                    {
                        _SearchDataByID(txtSearch.Text.Trim());
                    }
                    break;


                case "DoctorID":
                    if (_ModeUC == enModeUC.Appointment)
                    {
                        _SearchAppointmentDataByDoctorID(txtSearch.Text.Trim());
                    }
                    else
                    {
                        _SearchDataByID(txtSearch.Text.Trim());
                    }
                    break;


                case "Name":
                    _SearchDataByName(txtSearch.Text.Trim());
                    break;


                case "AppointmentID":
                    _SearchDataByID(txtSearch.Text.Trim());
                    break;


                case "PaymentID":
                    _SearchDataByID(txtSearch.Text.Trim());
                    break;


                case "PaymentMethod":
                    _SearchDataByPaymentMethod(txtSearch.Text.Trim());
                    break;

                case "UserID":
                    _SearchDataByID(txtSearch.Text.Trim());
                    break;

                case "Username":
                    _SearchDataByUsername(txtSearch.Text.Trim());
                    break;

            }

            DeleteProductImageColumn(this.EditIndex, this.DeleteIndex);
            ChangeSelectionCellInDataGridView();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

            ChangeSelectionCellInDataGridView();
        }

        private void dgvShowList_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Edit";
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                e.ToolTipText = "Delete";
            }
        }

        private void dgvShowList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = _GetIDFromDGV();

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                _OpenAddEditForm(ID);
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                _PerformDeletingPerson(ID);
            }
        }

        private void dgvShowList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //0 : Edit
            //1: Delete
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                dgvShowList.Cursor = Cursors.Hand;
            }
            else
            {
                dgvShowList.Cursor = Cursors.Default;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _OpenAddEditForm(-1);
        }

        private void medicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ModeUC == enModeUC.Patient)
            {
                string PatientName = (string)dgvShowList.CurrentRow.Cells["Name"].Value;

                frmShowMedicalRecordsOfPatient ShowMedicalRecordsOfPatient = new frmShowMedicalRecordsOfPatient(_GetIDFromDGV(), PatientName);
                ShowMedicalRecordsOfPatient.ShowDialog();
            }
        }

        private void preToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ModeUC == enModeUC.Patient)
            {
                string PatientName = (string)dgvShowList.CurrentRow.Cells["Name"].Value;

                frmShowPrescriptionsOfPatient ShowPrescriptionsOfPatient = new frmShowPrescriptionsOfPatient(_GetIDFromDGV(), PatientName);
                ShowPrescriptionsOfPatient.ShowDialog();
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ModeUC == enModeUC.Patient)
            {
                string PatientName = (string)dgvShowList.CurrentRow.Cells["Name"].Value;

                frmShowPaymentsOfPatient ShowPaymentsOfPatient = new frmShowPaymentsOfPatient(_GetIDFromDGV(), PatientName);
                ShowPaymentsOfPatient.ShowDialog();
            }

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ModeUC == enModeUC.Appointment)
            {
                frmShowAppointmentDetails ShowAppointmentDetails = new frmShowAppointmentDetails(_GetIDFromDGV());
                ShowAppointmentDetails.ShowDialog();
            }
        }
    }
}
