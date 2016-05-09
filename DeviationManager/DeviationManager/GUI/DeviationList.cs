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
    public partial class DeviationList : Form
    {
        private DeviationModel deviationModel;
        private Autorisation autorisation;
        private EmailSender emailSender;

        public DeviationList()
        {
            InitializeComponent();

            deviationModel = new DeviationModel();
            autorisation = new Autorisation();
            emailSender = new EmailSender();
            //DataGridViw Configuration
            this.DataViewConfiguration();

            //show deviation list
            this.showDeviationList();

            //set  language
            if (LanguageName.languageName != "DeviationManager.Lang.language_en")
            {
                this.setLanguage();
            }

        }


        //set the language
        private void setLanguage()
        {
            LanguageModel languageModel = new LanguageModel();

            this.lDeviationNO.Text = languageModel.getString("ldeviationNo");
            this.lRequestedBy.Text = languageModel.getString("lrequestedBy");
            this.lProduct.Text = languageModel.getString("lproduct");
            this.lRiskCategory.Text = languageModel.getString("lriskCategory");
            this.lDeviationType.Text = languageModel.getString("ldeviationType");
            this.lAnlage.Text = languageModel.getString("lmachine");
            this.lDate1.Text = languageModel.getString("ldate1");
            this.lDate2.Text = languageModel.getString("ldate2");
            this.lUseAllInputs.Text = languageModel.getString("luseAllInputs");

            this.deviationListUpdate.Text = languageModel.getString("lupdate");
            this.Filter.Text = languageModel.getString("lfilterDeviation");
            this.button1.Text = languageModel.getString("laddDeviation");
            this.button2.Text = languageModel.getString("leditDeviation");
            this.button3.Text = languageModel.getString("lcloseDeviation");
            this.showDeviation.Text = languageModel.getString("lshowDeviation");
            this.sendMessage.Text = languageModel.getString("lremindGroup");
        }

        //show Deviation List
        private void showDeviationList()
        {
            var deviations = deviationModel.listDeviations();
            var source = new BindingSource();
            source.DataSource = deviations;
            this.DeviationDataGridView.DataSource = source;
        }

        //update  Deviation List
        private void updateDeviationList(IList<Deviation> listdeviations)
        {
            var source = new BindingSource();
            source.DataSource = listdeviations;
            this.DeviationDataGridView.DataSource = source;
        }

        //DataGridViw Configuration
        private void DataViewConfiguration()
        {
            //fill Datagridview
            this.DeviationDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //DataGridView OnlyRead
            this.DeviationDataGridView.ReadOnly = true;

            //evit user to add new colums
            this.DeviationDataGridView.AllowUserToAddRows = false;
        }


        /*************************** Event **********************************************************************/
        private void addNewDeviation_Click(object sender, EventArgs e)
        {
            SaveDeviation saveDeviation = new SaveDeviation("newDeviation");
            saveDeviation.Show();
        }

        private void editDeviation_Click(object sender, EventArgs e)
        {
            String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
            Deviation deviation=autorisation.canUpdateDeviation(deviationRef);
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


        //close Deviation
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
                            MessageBox.Show("The Deviation Was Succesfuly Closed.","Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error The Deviation Cloud Not Be Closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
             
        }


        //Show Deviation
        private void showDeviation_Click(object sender, EventArgs e)
        {
            if (this.DeviationDataGridView.CurrentRow != null)
            {
                String deviationRef = this.DeviationDataGridView.CurrentRow.Cells[0].Value.ToString();
                Deviation deviation=autorisation.canUpdateDeviation(deviationRef);
               //The user can update the deviation if signature attribut of the deviation has the user name
                if (deviation != null)
                {
                    //update Deviation
                    SaveDeviation saveDeviation = new SaveDeviation("showDeviation");
                    saveDeviation.showDeviation(deviation);
                }
                 
            }
        }

        //search deviation using deviation ref
        private void deviationNO_TextChanged(object sender, EventArgs e)
        {
            if (this.likeSearch.Checked == false)
            {
                this.updateDeviationList(deviationModel.filterDeviationByRef(this.deviationNO.Text));
            }
        }

        //search deviation using requested by
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.likeSearch.Checked == false)
            {
                this.updateDeviationList(deviationModel.filterDeviationByRequestedBy(this.requestedBy.Text));
            }
        }

        //search deviation using rick category
        private void riskCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.likeSearch.Checked == false)
            {
                this.updateDeviationList(deviationModel.filterDeviationByRiskCategory(this.riskCategory.SelectedItem.ToString()));
            }
        }


        //search deviation using deviation type
        private void deviationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.likeSearch.Checked == false)
            {
                this.updateDeviationList(deviationModel.filterDeviationByDeviationType(this.deviationType.SelectedItem.ToString()));
            }
        }

        //search deviation using all  properties
        private void Filter_Click(object sender, EventArgs e)
        {

            String deviationRef = this.deviationNO.Text;
            String requestedBy = this.requestedBy.Text;
            String deviationType = "";
            String deviationRiskCategory = "";
            DateTime date1 = this.date1.Value;
            DateTime date2 = this.date2.Value;

            if (this.riskCategory.SelectedItem != null)
            {
                deviationRiskCategory = this.riskCategory.SelectedItem.ToString();
            }
            if (this.deviationType.SelectedItem != null)
            {
                deviationType = this.deviationType.SelectedItem.ToString();
            }

            var deviations = deviationModel.filterDeviationByAll(deviationRef, requestedBy, deviationRiskCategory, deviationType, date1, date2);
            this.updateDeviationList(deviations);
        }


        //update deviations list
        private void deviationListUpdate_Click(object sender, EventArgs e)
        {
            this.showDeviationList();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //searching by Anlage
        private void anlage_TextChanged(object sender, EventArgs e)
        {
            if (this.likeSearch.Checked == false)
            {
                this.updateDeviationList(deviationModel.filterDeviationByAnlage(this.anlage.Text));
            }
        }

        //searching by product
        private void product_TextChanged(object sender, EventArgs e)
        {
            if (this.likeSearch.Checked == false)
            {
                this.updateDeviationList(deviationModel.filterDeviationByPruduct(this.product.Text));
            }
        }


        //send email to groups who they 
        private void sendMessage_Click(object sender, EventArgs e)
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
        


        /**___________classs _____*****/

    }
}
