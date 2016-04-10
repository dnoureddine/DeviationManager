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
        public PrincipalWin()
        {
            InitializeComponent();
        }

        private void saveDeviationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDeviation saveDeviation = new SaveDeviation();
            saveDeviation.Show();
        }

        private void saveApprovementGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApprovementGroup approvementGroup = new ApprovementGroup();
            approvementGroup.Show();
        }

        private void listDeviationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviationList deviationList = new DeviationList();
            deviationList.Show();
        }
    }
}
