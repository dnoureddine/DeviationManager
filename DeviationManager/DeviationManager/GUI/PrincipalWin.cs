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

        public PrincipalWin()
        {
            InitializeComponent();

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
    }
}
