using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem_WindowsForms_
{
    public class clsOpenChildForm
    {
        private static Form activeForm = null;
        private static IconButton currentButton;

        private static void ActivateButton(object btnSender, Panel panelMenu, IconPictureBox IconCurrentChildForm)
        {
            if (btnSender != null)
            {
                if (currentButton != (IconButton)btnSender)
                {
                    DisableMenuButton(panelMenu);

                    currentButton = (IconButton)btnSender;
                    currentButton.BackColor = Color.FromArgb(12, 76, 125);
                    currentButton.IconColor = Color.Gainsboro;
                    currentButton.ForeColor = Color.Gainsboro;
                    IconCurrentChildForm.IconChar = currentButton.IconChar;
                }
            }
        }

        private static void DisableMenuButton(Panel panelMenu)
        {
            IconButton iconbutton = new IconButton();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    iconbutton = (IconButton)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(7, 43, 71);
                    previousBtn.ForeColor = Color.Gainsboro;
                    iconbutton.IconColor = Color.Gainsboro;
                }
            }
        }


        public static void OpenChildFormInPanel(Form childForm, Panel panelChildForm, Label lblTitleChildForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitleChildForm.Text = childForm.Text;
            }

        }

        public static void OpenChildFormInPanel(Form childForm, Panel panelChildForm, Label lblTitleChildForm, object btnSender, Panel panelMenu, IconPictureBox IconCurrentChildForm)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender, panelMenu, IconCurrentChildForm);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitleChildForm.Text = childForm.Text;
            }


        }

    }
}
