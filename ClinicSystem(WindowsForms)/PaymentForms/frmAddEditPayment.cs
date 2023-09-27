using ClinicSystem_BusinessLayer_;
using Guna.UI2.WinForms;
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
    public partial class frmAddEditPayment : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(int PaymentID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _PaymentID;
        private clsPayment _Payment;

        private ToolTip toolTip1;

        public frmAddEditPayment(int paymentID)
        {
            InitializeComponent();
            _PaymentID = paymentID;

            if (_PaymentID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

            toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000; // Duration of tooltip display
            toolTip1.InitialDelay = 0; // Delay before showing tooltip
            toolTip1.ReshowDelay = 0;   // Delay before reshowing tooltip

            // Set tooltip text for the TextBox control
            toolTip1.SetToolTip(txtPaymentID, "This field is Read Only!");
        }

        private void _FillFieldWithData()
        {
            txtPaymentID.Text = _Payment.PaymentID.ToString();
            dtpPaymentDate.Value = _Payment.PaymentDate;
            comboPaymentMethod.SelectedIndex = comboPaymentMethod.FindString(_Payment.PaymentMethod);
            txtAmountPaid.Text = _Payment.AmountPaid.ToString();
            txtNotes.Text = _Payment.AdditionalNotes;
        }

        private void _LoadData()
        {
            comboPaymentMethod.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                _Payment = new clsPayment();

                lblMode.Text = "Add New Payment";

                return;
            }
            else
            {
                _Payment = clsPayment.FindPayment(_PaymentID);

                if (_Payment == null)
                {
                    MessageBox.Show("There is no payment with this ID!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                lblMode.Text = "Update Payment";

                _FillFieldWithData();
            }
        }

        private void _FillPaymentWithData()
        {
            _Payment.PaymentDate = dtpPaymentDate.Value;
            _Payment.PaymentMethod = comboPaymentMethod.Text;
            _Payment.AmountPaid = decimal.Parse(txtAmountPaid.Text.Trim());
            _Payment.AdditionalNotes = txtNotes.Text.Trim();
        }

        private void _SavePayment()
        {
            if (_Payment.Save())
            {
                MessageBox.Show("Payment Saved Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "Update Payment";
                this._Mode = enMode.Update;

                _Payment._Mode = clsPayment.enMode.Update;

                txtPaymentID.Text = _Payment.PaymentID.ToString();

                // Trigger the event to send PaymentID to frmAddEditAppointment
                DataBack?.Invoke(_Payment.PaymentID);
            }
            else
            {
                MessageBox.Show("Payment Saved Failed.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void textbox_MouseEnter(object sender, EventArgs e)
        {
            // Show the tooltip when the mouse enters the TextBox
            toolTip1.Show(toolTip1.GetToolTip(((Guna2TextBox)sender)), ((Guna2TextBox)sender));
        }

        private void textbox_MouseLeave(object sender, EventArgs e)
        {
            // Hide the tooltip when the mouse leaves the TextBox
            toolTip1.Hide(((Guna2TextBox)sender));
        }

        private void frmAddEditPayment_Load(object sender, EventArgs e)
        {
            txtNotes.BorderRadius = 20;
            _LoadData();
        }

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Allow digits, the decimal point, and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isDecimalPoint = (inputChar == '.');
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isDecimalPoint && !isBackspace)
            {
                e.Handled = true;
            }

            // Make sure there is only one decimal point in the input.
            if (isDecimalPoint && ((sender as Guna2TextBox).Text.Contains(".") || (sender as Guna2TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmountPaid.Text.Trim()))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            else
            {
                _FillPaymentWithData();
                _SavePayment();
            }

        }

        private void dtpPaymentDate_MouseEnter(object sender, EventArgs e)
        {
            dtpPaymentDate.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            dtpPaymentDate.BorderColor = Color.FromArgb(94, 148, 255);
        }

        private void dtpPaymentDate_MouseLeave(object sender, EventArgs e)
        {
            dtpPaymentDate.HoverState.BorderColor = Color.FromArgb(64, 64, 64);
        }
    }
}
