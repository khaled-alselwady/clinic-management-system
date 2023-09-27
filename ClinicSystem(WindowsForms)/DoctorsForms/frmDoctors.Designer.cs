namespace ClinicSystem_WindowsForms_.DoctorsForms
{
    partial class frmDoctors
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
            this.ucTemplateDGVAndSearch1 = new ClinicSystem_WindowsForms_.ucTemplateDGVAndSearch("frmDoctors");
            this.SuspendLayout();
            // 
            // ucTemplateDGVAndSearch1
            // 
            this.ucTemplateDGVAndSearch1.BackColor = System.Drawing.SystemColors.Control;
            this.ucTemplateDGVAndSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateDGVAndSearch1.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateDGVAndSearch1.Name = "ucTemplateDGVAndSearch1";
            this.ucTemplateDGVAndSearch1.Size = new System.Drawing.Size(1405, 717);
            this.ucTemplateDGVAndSearch1.TabIndex = 0;
            // 
            // frmDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1405, 717);
            this.Controls.Add(this.ucTemplateDGVAndSearch1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoctors";
            this.Tag = "DOCTORS";
            this.Text = "frmDoctors";
            this.Load += new System.EventHandler(this.frmDoctors_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTemplateDGVAndSearch ucTemplateDGVAndSearch1;
    }
}