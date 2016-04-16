using DeviationManager.Entity;
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
    public partial class EmailGUI : Form
    {
        private Deviation deviation;
        private DeviationModel deviationModel;
        private SaveDeviation saveDeviation;

        public EmailGUI(Deviation deviation, SaveDeviation saveDeviation)
        {
            InitializeComponent();
            this.deviation = deviation;
            this.saveDeviation = saveDeviation;
            this.deviationModel = new DeviationModel();

            //generate email Content from deviation
            this.generateEmailContent();
        }


        //add deviation content to the email input
        private void generateEmailContent()
        {
            this.messageContent.AppendText(this.deviation.deviationRef);
        }


        /****************************** Event **************************************/
        private void sendMessage_Click(object sender, EventArgs e)
        {

            //Add the New deviation
            this.deviationModel.addDeviation(this.deviation);

            MessageBox.Show("The Deviation Was Successfuly Added", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.saveDeviation.Close();
            this.Close();
        }

        private void cancelSendEmail_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /*****_____class ****/
    }
}
