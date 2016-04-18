namespace DeviationManager.GUI
{
    partial class PrincipalWin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDeviationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveApprovementGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listDeviationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.lISTToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDeviationToolStripMenuItem,
            this.saveApprovementGroupToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.saveToolStripMenuItem.Text = "SAVE";
            // 
            // saveDeviationToolStripMenuItem
            // 
            this.saveDeviationToolStripMenuItem.Name = "saveDeviationToolStripMenuItem";
            this.saveDeviationToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveDeviationToolStripMenuItem.Text = "Save Deviation";
            this.saveDeviationToolStripMenuItem.Click += new System.EventHandler(this.saveDeviationToolStripMenuItem_Click);
            // 
            // saveApprovementGroupToolStripMenuItem
            // 
            this.saveApprovementGroupToolStripMenuItem.Name = "saveApprovementGroupToolStripMenuItem";
            this.saveApprovementGroupToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveApprovementGroupToolStripMenuItem.Text = "Save approvement group";
            this.saveApprovementGroupToolStripMenuItem.Click += new System.EventHandler(this.saveApprovementGroupToolStripMenuItem_Click);
            // 
            // lISTToolStripMenuItem
            // 
            this.lISTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listDeviationsToolStripMenuItem});
            this.lISTToolStripMenuItem.Name = "lISTToolStripMenuItem";
            this.lISTToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.lISTToolStripMenuItem.Text = "LIST";
            // 
            // listDeviationsToolStripMenuItem
            // 
            this.listDeviationsToolStripMenuItem.Name = "listDeviationsToolStripMenuItem";
            this.listDeviationsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.listDeviationsToolStripMenuItem.Text = "List deviations";
            this.listDeviationsToolStripMenuItem.Click += new System.EventHandler(this.listDeviationsToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // PrincipalWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 594);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalWin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Deviation Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDeviationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveApprovementGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listDeviationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
    }
}