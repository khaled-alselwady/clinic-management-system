namespace ClinicSystem_WindowsForms_.PrescriptionsForms
{
    partial class frmShowAllPrescriptions
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
            this.ucTemplateDGV1 = new ClinicSystem_WindowsForms_.ucTemplateDGV();
            this.SuspendLayout();
            // 
            // ucTemplateDGV1
            // 
            this.ucTemplateDGV1.BackColor = System.Drawing.SystemColors.Control;
            this.ucTemplateDGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateDGV1.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateDGV1.Name = "ucTemplateDGV1";
            this.ucTemplateDGV1.Size = new System.Drawing.Size(1252, 662);
            this.ucTemplateDGV1.TabIndex = 5;
            // 
            // frmShowAllPrescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1252, 662);
            this.Controls.Add(this.ucTemplateDGV1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowAllPrescriptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show All Prescripions";
            this.Load += new System.EventHandler(this.frmShowAllPrescriptions_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ucTemplateDGV ucTemplateDGV1;
    }
}