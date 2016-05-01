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
            String emailSubject = "";

            //generate email subject
            if (this.deviation.product !="")
            {
                emailSubject = "New Deviation fürs Produkt : " + this.deviation.product;
            }

            if(this.deviation.anlage!="")
            {
                if (this.deviation.product != "")
                {
                    emailSubject = emailSubject + " / die Anlage : " + this.deviation.anlage;
                }
                else
                {
                    emailSubject = "New Deviation für die Anlage : " + this.deviation.anlage;
                }
            }

            if (emailSubject == "")
            {
                emailSubject = "New Deviation";
            }

            this.subject.AppendText(emailSubject);

            //generate the email body
            this.messageContent.AppendText("\n Standard Condition : \n\n");
            this.messageContent.AppendText(this.deviation.detailStandardCondition);

            this.messageContent.AppendText("\n\n\n");

            this.messageContent.AppendText("Detail Requested Condition : \n\n");
            this.messageContent.AppendText(this.deviation.detailRequestCondition);
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
