namespace ClinicSystem_WindowsForms_.AppointmentsForms
{
    partial class frmAddEditAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numaricPatientID = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numaricDoctor = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMedicalRecordID = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddNewMedicalRecord = new Guna.UI2.WinForms.Guna2Button();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAppointmentTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.ucShowDoctorDetails = new ClinicSystem_WindowsForms_.ucShowPersonDetails("Doctor");
            this.ucShowPatientDetails = new ClinicSystem_WindowsForms_.ucShowPersonDetails("Patient");
            ((System.ComponentModel.ISupportInitialize)(this.numaricPatientID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numaricDoctor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Brown;
            this.lblMode.Location = new System.Drawing.Point(469, 19);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(276, 40);
            this.lblMode.TabIndex = 347;
            this.lblMode.Text = "Add New Donor";
            this.lblMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblMode_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 346;
            this.label1.Text = "Patient ID:";
            // 
            // numaricPatientID
            // 
            this.numaricPatientID.BackColor = System.Drawing.Color.Transparent;
            this.numaricPatientID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numaricPatientID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numaricPatientID.Location = new System.Drawing.Point(114, 137);
            this.numaricPatientID.Name = "numaricPatientID";
            this.numaricPatientID.Size = new System.Drawing.Size(100, 27);
            this.numaricPatientID.TabIndex = 347;
            this.numaricPatientID.ValueChanged += new System.EventHandler(this.numaricPatientID_ValueChanged);
            // 
            // numaricDoctor
            // 
            this.numaricDoctor.BackColor = System.Drawing.Color.Transparent;
            this.numaricDoctor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numaricDoctor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numaricDoctor.Location = new System.Drawing.Point(523, 136);
            this.numaricDoctor.Name = "numaricDoctor";
            this.numaricDoctor.Size = new System.Drawing.Size(100, 27);
            this.numaricDoctor.TabIndex = 350;
            this.numaricDoctor.ValueChanged += new System.EventHandler(this.numaricDoctor_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(433, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 349;
            this.label2.Text = "Doctor ID:";
            // 
            // comboStatus
            // 
            this.comboStatus.AutoRoundedCorners = true;
            this.comboStatus.BackColor = System.Drawing.Color.White;
            this.comboStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.comboStatus.BorderRadius = 17;
            this.comboStatus.BorderThickness = 2;
            this.comboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.comboStatus.FocusedColor = System.Drawing.Color.Empty;
            this.comboStatus.FocusedState.ForeColor = System.Drawing.Color.White;
            this.comboStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboStatus.ForeColor = System.Drawing.Color.White;
            this.comboStatus.ItemHeight = 30;
            this.comboStatus.ItemsAppearance.BackColor = System.Drawing.Color.White;
            this.comboStatus.ItemsAppearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.comboStatus.Location = new System.Drawing.Point(980, 128);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(164, 36);
            this.comboStatus.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboStatus.TabIndex = 352;
            this.comboStatus.DropDown += new System.EventHandler(this.comboStatus_DropDown);
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(914, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 353;
            this.label3.Text = "Status:";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Checked = true;
            this.dtpAppointmentDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentDate.ForeColor = System.Drawing.Color.White;
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(980, 203);
            this.dtpAppointmentDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAppointmentDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(164, 36);
            this.dtpAppointmentDate.TabIndex = 354;
            this.dtpAppointmentDate.Value = new System.DateTime(2023, 8, 5, 18, 39, 34, 339);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(914, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 355;
            this.label4.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(875, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 356;
            this.label5.Text = "Medical Record ID:";
            // 
            // lblMedicalRecordID
            // 
            this.lblMedicalRecordID.AutoSize = true;
            this.lblMedicalRecordID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalRecordID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMedicalRecordID.Location = new System.Drawing.Point(1032, 343);
            this.lblMedicalRecordID.Name = "lblMedicalRecordID";
            this.lblMedicalRecordID.Size = new System.Drawing.Size(0, 25);
            this.lblMedicalRecordID.TabIndex = 357;
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPaymentID.Location = new System.Drawing.Point(1032, 405);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(0, 25);
            this.lblPaymentID.TabIndex = 359;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(896, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 358;
            this.label7.Text = "Payment ID:";
            // 
            // btnAddNewMedicalRecord
            // 
            this.btnAddNewMedicalRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewMedicalRecord.Animated = true;
            this.btnAddNewMedicalRecord.AutoRoundedCorners = true;
            this.btnAddNewMedicalRecord.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewMedicalRecord.BorderRadius = 16;
            this.btnAddNewMedicalRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewMedicalRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewMedicalRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewMedicalRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewMedicalRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewMedicalRecord.Enabled = false;
            this.btnAddNewMedicalRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.btnAddNewMedicalRecord.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddNewMedicalRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddNewMedicalRecord.Location = new System.Drawing.Point(1097, 338);
            this.btnAddNewMedicalRecord.Name = "btnAddNewMedicalRecord";
            this.btnAddNewMedicalRecord.Size = new System.Drawing.Size(129, 34);
            this.btnAddNewMedicalRecord.TabIndex = 360;
            this.btnAddNewMedicalRecord.Text = "Add New";
            this.btnAddNewMedicalRecord.Click += new System.EventHandler(this.btnAddNewMedicalRecord_Click);
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.Animated = true;
            this.btnPay.AutoRoundedCorners = true;
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.BorderRadius = 16;
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.btnPay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(1097, 402);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(129, 34);
            this.btnPay.TabIndex = 361;
            this.btnPay.Text = "Pay";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 23;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(357, 671);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 48);
            this.btnSave.TabIndex = 362;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 23;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Crimson;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(752, 671);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 48);
            this.btnClose.TabIndex = 363;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(914, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 365;
            this.label6.Text = "Time:";
            // 
            // dtpAppointmentTime
            // 
            this.dtpAppointmentTime.Checked = true;
            this.dtpAppointmentTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.dtpAppointmentTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentTime.ForeColor = System.Drawing.Color.White;
            this.dtpAppointmentTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpAppointmentTime.Location = new System.Drawing.Point(980, 271);
            this.dtpAppointmentTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAppointmentTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAppointmentTime.Name = "dtpAppointmentTime";
            this.dtpAppointmentTime.ShowUpDown = true;
            this.dtpAppointmentTime.Size = new System.Drawing.Size(164, 36);
            this.dtpAppointmentTime.TabIndex = 364;
            this.dtpAppointmentTime.Value = new System.DateTime(2023, 8, 5, 18, 39, 34, 339);
            // 
            // ucShowDoctorDetails
            // 
            this.ucShowDoctorDetails.BackColor = System.Drawing.SystemColors.Control;
            this.ucShowDoctorDetails.Location = new System.Drawing.Point(437, 187);
            this.ucShowDoctorDetails.Name = "ucShowDoctorDetails";
            this.ucShowDoctorDetails.Size = new System.Drawing.Size(377, 431);
            this.ucShowDoctorDetails.TabIndex = 351;
            // 
            // ucShowPatientDetails
            // 
            this.ucShowPatientDetails.BackColor = System.Drawing.SystemColors.Control;
            this.ucShowPatientDetails.Location = new System.Drawing.Point(28, 188);
            this.ucShowPatientDetails.Name = "ucShowPatientDetails";
            this.ucShowPatientDetails.Size = new System.Drawing.Size(377, 431);
            this.ucShowPatientDetails.TabIndex = 348;
            // 
            // frmAddEditAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1271, 722);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpAppointmentTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnAddNewMedicalRecord);
            this.Controls.Add(this.lblPaymentID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMedicalRecordID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpAppointmentDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.ucShowDoctorDetails);
            this.Controls.Add(this.numaricDoctor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucShowPatientDetails);
            this.Controls.Add(this.numaricPatientID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddEditAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Edit Appointment";
            this.Load += new System.EventHandler(this.frmAddEditAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numaricPatientID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numaricDoctor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2NumericUpDown numaricPatientID;
        private ucShowPersonDetails ucShowPatientDetails;
        private ucShowPersonDetails ucShowDoctorDetails;
        private Guna.UI2.WinForms.Guna2NumericUpDown numaricDoctor;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox comboStatus;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMedicalRecordID;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button btnAddNewMedicalRecord;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpAppointmentTime;
    }
}