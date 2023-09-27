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

namespace ClinicSystem_WindowsForms_.UsersForms
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void _FillComboSearch()
        {
            string[] arrSearch = new string[] { "UserID", "Username" };

            ucTemplateDGVAndSearch1.FillComboSearch(arrSearch);
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            ucTemplateDGVAndSearch1.RefreshDGV(clsUser.GetAllUsers());
            ucTemplateDGVAndSearch1.AddImagesToDataGridView(10, 11);  // 5: Edit Column Index, 6: Delete Column Index

            _FillComboSearch();
        }
    }
}
