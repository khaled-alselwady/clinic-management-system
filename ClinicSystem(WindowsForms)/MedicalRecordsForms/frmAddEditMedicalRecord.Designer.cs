namespace ClinicSystem_WindowsForms_.MedicalRecordsForms
{
    partial class frmAddEditMedicalRecord
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
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMedicalRecordID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVisitDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddPrescription = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Transparent;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Brown;
            this.lblMode.Location = new System.Drawing.Point(94, 19);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(244, 35);
            this.lblMode.TabIndex = 357;
            this.lblMode.Text = "Add New Donor";
            this.lblMode.Click += new System.EventHandler(this.lblMode_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 17;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(367, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 37);
            this.btnSave.TabIndex = 372;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 24);
            this.label4.TabIndex = 368;
            this.label4.Text = "Visit Description:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 24);
            this.label10.TabIndex = 366;
            this.label10.Text = "Diagnosis:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.AutoRoundedCorners = true;
            this.txtDiagnosis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDiagnosis.BorderRadius = 20;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiagnosis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiagnosis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiagnosis.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiagnosis.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.txtDiagnosis.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiagnosis.Location = new System.Drawing.Point(190, 258);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PasswordChar = '\0';
            this.txtDiagnosis.PlaceholderText = "";
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.Size = new System.Drawing.Size(307, 42);
            this.txtDiagnosis.TabIndex = 367;
            this.txtDiagnosis.Tag = "";
            // 
            // txtNotes
            // 
            this.txtNotes.AutoRoundedCorners = true;
            this.txtNotes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNotes.BorderRadius = 66;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Location = new System.Drawing.Point(190, 334);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(307, 134);
            this.txtNotes.TabIndex = 365;
            this.txtNotes.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 24);
            this.label8.TabIndex = 364;
            this.label8.Text = "Additional Note:";
            // 
            // txtMedicalRecordID
            // 
            this.txtMedicalRecordID.AutoRoundedCorners = true;
            this.txtMedicalRecordID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMedicalRecordID.BorderRadius = 20;
            this.txtMedicalRecordID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedicalRecordID.DefaultText = "";
            this.txtMedicalRecordID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMedicalRecordID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMedicalRecordID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedicalRecordID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedicalRecordID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMedicalRecordID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMedicalRecordID.ForeColor = System.Drawing.Color.Black;
            this.txtMedicalRecordID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMedicalRecordID.Location = new System.Drawing.Point(190, 106);
            this.txtMedicalRecordID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMedicalRecordID.Name = "txtMedicalRecordID";
            this.txtMedicalRecordID.PasswordChar = '\0';
            this.txtMedicalRecordID.PlaceholderText = "";
            this.txtMedicalRecordID.ReadOnly = true;
            this.txtMedicalRecordID.SelectedText = "";
            this.txtMedicalRecordID.Size = new System.Drawing.Size(136, 42);
            this.txtMedicalRecordID.TabIndex = 363;
            this.txtMedicalRecordID.Tag = "";
            this.txtMedicalRecordID.MouseEnter += new System.EventHandler(this.textbox_MouseEnter);
            this.txtMedicalRecordID.MouseLeave += new System.EventHandler(this.textbox_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 24);
            this.label9.TabIndex = 362;
            this.label9.Text = "Medical Record ID:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtVisitDescription
            // 
            this.txtVisitDescription.AutoRoundedCorners = true;
            this.txtVisitDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVisitDescription.BorderRadius = 20;
            this.txtVisitDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVisitDescription.DefaultText = "";
            this.txtVisitDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVisitDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVisitDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVisitDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVisitDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVisitDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVisitDescription.ForeColor = System.Drawing.Color.Black;
            this.txtVisitDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVisitDescription.Location = new System.Drawing.Point(190, 182);
            this.txtVisitDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVisitDescription.Name = "txtVisitDescription";
            this.txtVisitDescription.PasswordChar = '\0';
            this.txtVisitDescription.PlaceholderText = "";
            this.txtVisitDescription.SelectedText = "";
            this.txtVisitDescription.Size = new System.Drawing.Size(307, 42);
            this.txtVisitDescription.TabIndex = 373;
            this.txtVisitDescription.Tag = "";
            // 
            // btnAddPrescription
            // 
            this.btnAddPrescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPrescription.Animated = true;
            this.btnAddPrescription.AutoRoundedCorners = true;
            this.btnAddPrescription.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPrescription.BorderRadius = 17;
            this.btnAddPrescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPrescription.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPrescription.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPrescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPrescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPrescription.Enabled = false;
            this.btnAddPrescription.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnAddPrescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddPrescription.ForeColor = System.Drawing.Color.White;
            this.btnAddPrescription.Location = new System.Drawing.Point(13, 513);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(169, 37);
            this.btnAddPrescription.TabIndex = 374;
            this.btnAddPrescription.Text = "Add Prescription";
            this.btnAddPrescription.Click += new System.EventHandler(this.btnAddPrescription_Click);
            // 
            // frmAddEditMedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(556, 557);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnAddPrescription);
            this.Controls.Add(this.txtVisitDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMedicalRecordID);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAddEditMedicalRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Edit Medical Reocrd";
            this.Load += new System.EventHandler(this.frmAddEditMedicalRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMode;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtMedicalRecordID;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtVisitDescription;
        private Guna.UI2.WinForms.Guna2Button btnAddPrescription;
    }
}