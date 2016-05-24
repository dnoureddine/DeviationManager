using DeviationManager.Entity;
using DeviationManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace DeviationManager.GUI
{
    public partial class PrincipalWin : Form
    {
        private DeviationModel deviationModel;
        private Autorisation autorisation;
        private EmailSender emailSender;
        private int n = 1;
        private int m = 200;
        public PrincipalWin()
        {
            InitializeComponent();
            this.autorisation = new Autorisation();
            this.emailSender = new EmailSender();

            deviationModel = new DeviationModel();
            this.init();
          
        }


        //init Method
        private void init()
        {
            this.approvedDev.Text = this.deviationModel.listApprovedDeviation().Count + "";
            this.pendingDev.Text = this.deviationModel.listPendingDeviation().Count + ""; 
            this.rejectedDev.Text = this.deviationModel.listRejectedDeviation().Count + "";

            var deviations = deviationModel.listPendingDeviation();
            var source = new BindingSource();
            source.DataSource = deviations;
            this.DeviationDataGridView.DataSource = source;

            this.language.SelectedIndex = 1;
        }


        //set lanague
        private void setLanguage()
        {
            LanguageModel languageModel = new LanguageModel();

            this.newDevaition.Text = languageModel.getString("lnewDeviation");
            this.deviationList.Text = languageModel.getString("ldeviationList");
            this.updateDeviation.Text = languageModel.getString("lupdate");

            this.addDeviation.Text = languageModel.getString("laddDeviation");
            this.editDeviation.Text = languageModel.getString("leditDeviation");
            this.closeDeviation.Text = languageModel.getString("lcloseDeviation");
            this.showDeviation.Text = languageModel.getString("lshowDeviation");
            this.sendMessage.Text = languageModel.getString("lremindGroup");


        }

        private void saveDeviationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDeviation saveDeviation = new SaveDeviation("newDeviation");
            saveDeviation.Show();
        }

        private void saveApprovementGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.Show();
        }

        private void listDeviationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviationList deviationList = new DeviationList();
            deviationList.Show();
        }

        private void blueDev_Click(object sender, EventArgs e)
        {

        }


        private void panel13_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void newDevaition_Click(object sender, EventArgs e)
        {
            SaveDeviation addDeviation = new SaveDeviation("newDeviation");
            addDeviation.Show();
        }

        private void deviationList_Click(object sender, EventArgs e)
        {
            DeviationList deviationList = new DeviationList();
            deviationList.Show();
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            var deviations = deviationModel.listApprovedDeviation();
            var source = new BindingSource();
            source.DataSource = deviations;
            this.DeviationDataGridView.DataSource = source;
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            var deviations = deviationModel.listPendingDeviation();
            var source = new BindingSource();
            source.DataSource = deviations;
            this.DeviationDataGridView.DataSource = source;
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            var deviations = deviationModel.listRejectedDeviation();
            var source = new BindingSource();
            source.DataSource = deviations;
            this.DeviationDataGridView.DataSource = source;
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        //update list
        private void button1_Click(object sender, EventArgs e)
        {
            var deviations = deviationModel.listPendingDeviation();
            var source = new BindingSource();
            source.DataSource = deviations;
            this.DeviationDataGridView.DataSource = source;


            this.approvedDev.Text = this.deviationModel.listApprovedDeviation().Count + "";
            this.pendingDev.Text = this.deviationModel.listPendingDeviation().Count + "";
            this.rejectedDev.Text = this.deviationModel.listRejectedDeviation().Count + "";

        }

        private void language_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String languageName = this.language.SelectedItem.ToString();
            if (languageName == "English")
            {
                LanguageName.languageName = "DeviationManager.Lang.language_en";
            }
            else if (languageName=="Deutsch")
            {
                LanguageName.languageName = "DeviationManager.Lang.language_de";
            }
            

            //set Language
            this.setLanguage();
        }

        //show deviation
        private void deviationAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                Deviation deviation = deviationModel.getDeviationWithRef(deviationRef);
                //The user can update the deviation if signature attribut of the deviation has the user name
                if (deviation != null)
                {
                    //show Deviation
                    SaveDeviation saveDeviation = new SaveDeviation("showDeviation");
                    saveDeviation.showDeviation(deviation);
                }
                else
                {
                    MessageBox.Show("Deviation dos not exist!");
                }

            }
            else
            {
                MessageBox.Show("Please Choose a Deviation Before makimg this Action!");
            }
        }

        //edit deviation
        private void deviationÜberarbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
            Deviation deviation = autorisation.canUpdateDeviation(deviationRef);
            //The user can update the deviation if signature attribut of the deviation has the user name
            if (deviation != null)
            {
                //dos the user choose the Deviation to update
                if (deviationRef != "" && deviationRef != null)
                {

                    //make sure that the deviation is closed
                    if (!deviationModel.isDeviationClosed(deviation))
                    {
                        //update Deviation
                        SaveDeviation saveDeviation = new SaveDeviation("updateDeviation");
                        saveDeviation.updateDeviation(deviation);
                    }
                    else
                    {
                        MessageBox.Show("You Are Not Allowed To Make Any Change On This Item Because Its Already Closed !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                MessageBox.Show("You Are Not Allowed To Update This Item !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //close deviation
        private void deviationSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                if (deviationRef != "" || deviationRef != null)
                {
                    if (MessageBox.Show("Close Deviation Means You Will Not Be Able Later To Make Any Change On It, Are You Sure You Wish To Make This Action ?", "Close Deviation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        String result = deviationModel.closeDeviation(deviationRef);
                        if (result == "closed")
                        {
                            MessageBox.Show("The Deviation Was Succesfuly Closed.", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error The Deviation Cloud Not Be Closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        //remind Group
        private void gruppeErinnernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                Deviation deviation = autorisation.canUpdateDeviation(deviationRef);
                if (deviation != null)
                {
                    //send email to Groups that they did not yet approve
                    var result = this.emailSender.sentEmailToGroups(deviation);
                    if (result == "sent")
                    {
                        MessageBox.Show("An Email has been sent !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        //add deviation
        private void addDeviation_Click(object sender, EventArgs e)
        {
            SaveDeviation saveDeviation = new SaveDeviation("newDeviation");
            saveDeviation.Show();
        }

        //add deviation
        private void editDeviation_Click(object sender, EventArgs e)
        {
            String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
            Deviation deviation = autorisation.canUpdateDeviation(deviationRef);
            //The user can update the deviation if signature attribut of the deviation has the user name
            if (deviation != null)
            {
                //dos the user choose the Deviation to update
                if (deviationRef != "" && deviationRef != null)
                {

                    //make sure that the deviation is closed
                    if (!deviationModel.isDeviationClosed(deviation))
                    {
                        //update Deviation
                        SaveDeviation saveDeviation = new SaveDeviation("updateDeviation");
                        saveDeviation.updateDeviation(deviation);
                    }
                    else
                    {
                        MessageBox.Show("You Are Not Allowed To Make Any Change On This Item Because Its Already Closed !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                MessageBox.Show("You Are Not Allowed To Update This Item !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //close deviation
        private void closeDeviation_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                if (deviationRef != "" || deviationRef != null)
                {
                    if (MessageBox.Show("Close Deviation Means You Will Not Be Able Later To Make Any Change On It, Are You Sure You Wish To Make This Action ?", "Close Deviation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        String result = deviationModel.closeDeviation(deviationRef);
                        if (result == "closed")
                        {
                            MessageBox.Show("The Deviation Was Succesfuly Closed.", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error The Deviation Cloud Not Be Closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        //show deviation
        private void showDeviation_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                Deviation deviation = deviationModel.getDeviationWithRef(deviationRef);
                //The user can update the deviation if signature attribut of the deviation has the user name
                if (deviation != null)
                {
                    //show Deviation
                    SaveDeviation saveDeviation = new SaveDeviation("showDeviation");
                    saveDeviation.showDeviation(deviation);
                }
                else
                {
                    MessageBox.Show("Deviation dos not exist!");
                }

            }
            else
            {
                MessageBox.Show("Please Choose a Deviation Before makimg this Action!");
            }
        }

        //remind Group
        private void sendMessage_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                Deviation deviation = deviationModel.getDeviationWithRef(deviationRef);
                if (deviation != null)
                {
                    //send email to Groups that they did not yet approve
                    var result = this.emailSender.sentEmailToGroups(deviation);
                    if (result == "sent")
                    {
                        MessageBox.Show("An Email has been sent !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }else
                {
                    MessageBox.Show("Deviation dos not exist !!");
                }

            }
        }



        //___Class ______

    }
}
