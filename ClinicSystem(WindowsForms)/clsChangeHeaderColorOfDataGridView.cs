using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_
{
    public class clsChangeHeaderColorOfDataGridView
    {

        public static void ChangeHeaderColorOfDataGridView(DataGridView dataGridView)
        {
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(7, 43, 71);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

    }
}
