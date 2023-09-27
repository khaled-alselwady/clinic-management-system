namespace ClinicSystem_WindowsForms_.AppointmentsForms
{
    partial class frmShowAppointmentDetails
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbMedicalRecordDetails = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.lblVisitDescription = new System.Windows.Forms.Label();
            this.lblMedicalRecordID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.gbPaymentDetails = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ucShowDoctorDetails = new ClinicSystem_WindowsForms_.ucShowPersonDetails("Doctor");
            this.ucShowPatientDetails = new ClinicSystem_WindowsForms_.ucShowPersonDetails("Patient");
            this.gbMedicalRecordDetails.SuspendLayout();
            this.gbPaymentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Brown;
            this.lblTitle.Location = new System.Drawing.Point(381, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 58);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Appointment Details";
            // 
            // gbMedicalRecordDetails
            // 
            this.gbMedicalRecordDetails.BackColor = System.Drawing.SystemColors.Control;
            this.gbMedicalRecordDetails.BorderRadius = 20;
            this.gbMedicalRecordDetails.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.gbMedicalRecordDetails.Controls.Add(this.lblDiagnosis);
            this.gbMedicalRecordDetails.Controls.Add(this.lblVisitDescription);
            this.gbMedicalRecordDetails.Controls.Add(this.lblMedicalRecordID);
            this.gbMedicalRecordDetails.Controls.Add(this.label4);
            this.gbMedicalRecordDetails.Controls.Add(this.label2);
            this.gbMedicalRecordDetails.Controls.Add(this.lblPersonID);
            this.gbMedicalRecordDetails.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.gbMedicalRecordDetails.FillColor = System.Drawing.SystemColors.Control;
            this.gbMedicalRecordDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMedicalRecordDetails.ForeColor = System.Drawing.Color.LightGray;
            this.gbMedicalRecordDetails.Location = new System.Drawing.Point(876, 146);
            this.gbMedicalRecordDetails.Name = "gbMedicalRecordDetails";
            this.gbMedicalRecordDetails.Size = new System.Drawing.Size(452, 203);
            this.gbMedicalRecordDetails.TabIndex = 4;
            this.gbMedicalRecordDetails.Text = "Medical Record Details";
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.lblDiagnosis.Location = new System.Drawing.Point(220, 155);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(0, 24);
            this.lblDiagnosis.TabIndex = 354;
            // 
            // lblVisitDescription
            // 
            this.lblVisitDescription.AutoSize = true;
            this.lblVisitDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitDescription.ForeColor = System.Drawing.Color.Black;
            this.lblVisitDescription.Location = new System.Drawing.Point(220, 111);
            this.lblVisitDescription.Name = "lblVisitDescription";
            this.lblVisitDescription.Size = new System.Drawing.Size(0, 24);
            this.lblVisitDescription.TabIndex = 353;
            // 
            // lblMedicalRecordID
            // 
            this.lblMedicalRecordID.AutoSize = true;
            this.lblMedicalRecordID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalRecordID.ForeColor = System.Drawing.Color.Black;
            this.lblMedicalRecordID.Location = new System.Drawing.Point(220, 66);
            this.lblMedicalRecordID.Name = "lblMedicalRecordID";
            this.lblMedicalRecordID.Size = new System.Drawing.Size(0, 24);
            this.lblMedicalRecordID.TabIndex = 352;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 24);
            this.label4.TabIndex = 341;
            this.label4.Text = "Diagnosis:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 339;
            this.label2.Text = "Visit Description:";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.ForeColor = System.Drawing.Color.Black;
            this.lblPersonID.Location = new System.Drawing.Point(12, 64);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(188, 24);
            this.lblPersonID.TabIndex = 338;
            this.lblPersonID.Text = "Medical Record ID:";
            // 
            // gbPaymentDetails
            // 
            this.gbPaymentDetails.BackColor = System.Drawing.SystemColors.Control;
            this.gbPaymentDetails.BorderRadius = 20;
            this.gbPaymentDetails.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.gbPaymentDetails.Controls.Add(this.lblPaymentAmount);
            this.gbPaymentDetails.Controls.Add(this.label9);
            this.gbPaymentDetails.Controls.Add(this.lblPaymentMethod);
            this.gbPaymentDetails.Controls.Add(this.lblPaymentDate);
            this.gbPaymentDetails.Controls.Add(this.lblPaymentID);
            this.gbPaymentDetails.Controls.Add(this.label6);
            this.gbPaymentDetails.Controls.Add(this.label7);
            this.gbPaymentDetails.Controls.Add(this.label8);
            this.gbPaymentDetails.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.gbPaymentDetails.FillColor = System.Drawing.SystemColors.Control;
            this.gbPaymentDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPaymentDetails.ForeColor = System.Drawing.Color.LightGray;
            this.gbPaymentDetails.Location = new System.Drawing.Point(876, 359);
            this.gbPaymentDetails.Name = "gbPaymentDetails";
            this.gbPaymentDetails.Size = new System.Drawing.Size(452, 235);
            this.gbPaymentDetails.TabIndex = 355;
            this.gbPaymentDetails.Text = "Payment Details";
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentAmount.Location = new System.Drawing.Point(200, 201);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(0, 24);
            this.lblPaymentAmount.TabIndex = 356;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 24);
            this.label9.TabIndex = 355;
            this.label9.Text = "Amount:";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentMethod.Location = new System.Drawing.Point(200, 157);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(0, 24);
            this.lblPaymentMethod.TabIndex = 354;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentDate.Location = new System.Drawing.Point(200, 113);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(0, 24);
            this.lblPaymentDate.TabIndex = 353;
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentID.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentID.Location = new System.Drawing.Point(200, 69);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(0, 24);
            this.lblPaymentID.TabIndex = 352;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 24);
            this.label6.TabIndex = 341;
            this.label6.Text = "Payment Method:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 339;
            this.label7.Text = "Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 24);
            this.label8.TabIndex = 338;
            this.label8.Text = "Payment ID:";
            // 
            // ucShowDoctorDetails
            // 
            this.ucShowDoctorDetails.BackColor = System.Drawing.SystemColors.Control;
            this.ucShowDoctorDetails.Location = new System.Drawing.Point(447, 141);
            this.ucShowDoctorDetails.Name = "ucShowDoctorDetails";
            this.ucShowDoctorDetails.Size = new System.Drawing.Size(377, 435);
            this.ucShowDoctorDetails.TabIndex = 3;
            // 
            // ucShowPatientDetails
            // 
            this.ucShowPatientDetails.BackColor = System.Drawing.SystemColors.Control;
            this.ucShowPatientDetails.Location = new System.Drawing.Point(23, 139);
            this.ucShowPatientDetails.Name = "ucShowPatientDetails";
            this.ucShowPatientDetails.Size = new System.Drawing.Size(377, 437);
            this.ucShowPatientDetails.TabIndex = 2;
            // 
            // frmShowAppointmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1356, 635);
            this.Controls.Add(this.gbPaymentDetails);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbMedicalRecordDetails);
            this.Controls.Add(this.ucShowDoctorDetails);
            this.Controls.Add(this.ucShowPatientDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowAppointmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Appointment Details";
            this.Load += new System.EventHandler(this.frmShowAppointmentDetails_Load);
            this.gbMedicalRecordDetails.ResumeLayout(false);
            this.gbMedicalRecordDetails.PerformLayout();
            this.gbPaymentDetails.ResumeLayout(false);
            this.gbPaymentDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private ucShowPersonDetails ucShowPatientDetails;
        private ucShowPersonDetails ucShowDoctorDetails;
        private Guna.UI2.WinForms.Guna2GroupBox gbMedicalRecordDetails;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.Label lblVisitDescription;
        private System.Windows.Forms.Label lblMedicalRecordID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPersonID;
        private Guna.UI2.WinForms.Guna2GroupBox gbPaymentDetails;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.Label label9;
    }
}