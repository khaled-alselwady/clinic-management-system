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

namespace ClinicSystem_WindowsForms_.PaymentForms
{
    public partial class frmPayments : Form
    {
        public frmPayments()
        {
            InitializeComponent();
        }

        private void _FillComboSearch()
        {
            string[] arrSearch = new string[] { "PaymentID", "PaymentMethod" };

            ucTemplateDGVAndSearch1.FillComboSearch(arrSearch);
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            ucTemplateDGVAndSearch1.RefreshDGV(clsPayment.GetAllPayments());
            ucTemplateDGVAndSearch1.AddImagesToDataGridView(5, 6);  // 5: Edit Column Index, 6: Delete Column Index
            ucTemplateDGVAndSearch1._HideAddNewButton();

            _FillComboSearch();
        }
    }
}
