using DeviationManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeviationManager.GUI
{
    public partial class ChangePassword : Form
    {
        private DeviationModel deviationModel;
        public ChangePassword()
        {
            InitializeComponent();

            this.deviationModel = new DeviationModel();

        }

        private void Changepwd_Click(object sender, EventArgs e)
        {
            bool changePwdStatus = deviationModel.updatePassword(this.oldPassword.Text, this.newPassword.Text);
            if (changePwdStatus)
            {
                MessageBox.Show("The Password Was successfuly Changed !");

                this.Close();
            }else
            {
                MessageBox.Show("The PassWord Could not Be Changed !");
            }
        }
    }
}
