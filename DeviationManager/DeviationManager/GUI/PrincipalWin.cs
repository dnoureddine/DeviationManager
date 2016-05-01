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
        }

        private void saveDeviationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDeviation saveDeviation = new SaveDeviation("newDeviation");
            saveDeviation.Show();
        }

        private void saveApprovementGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApprovementGroupGUI approvementGroup = new ApprovementGroupGUI();
            approvementGroup.Show();
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

      
    }
}
