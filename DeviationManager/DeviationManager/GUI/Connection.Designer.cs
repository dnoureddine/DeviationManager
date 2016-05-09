namespace DeviationManager.GUI
{
    partial class Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection));
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordchange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.passwort = new System.Windows.Forms.TextBox();
            this.lpassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordchange);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.passwort);
            this.panel1.Controls.Add(this.lpassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 248);
            this.panel1.TabIndex = 0;
            // 
            // passwordchange
            // 
            this.passwordchange.Location = new System.Drawing.Point(239, 143);
            this.passwordchange.Name = "passwordchange";
            this.passwordchange.Size = new System.Drawing.Size(111, 34);
            this.passwordchange.TabIndex = 3;
            this.passwordchange.Text = "Change Password";
            this.passwordchange.UseVisualStyleBackColor = true;
            this.passwordchange.Click += new System.EventHandler(this.passwordchange_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwort
            // 
            this.passwort.Location = new System.Drawing.Point(132, 98);
            this.passwort.Multiline = true;
            this.passwort.Name = "passwort";
            this.passwort.Size = new System.Drawing.Size(347, 27);
            this.passwort.TabIndex = 1;
            // 
            // lpassword
            // 
            this.lpassword.AutoSize = true;
            this.lpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lpassword.Location = new System.Drawing.Point(11, 99);
            this.lpassword.Name = "lpassword";
            this.lpassword.Size = new System.Drawing.Size(115, 15);
            this.lpassword.TabIndex = 0;
            this.lpassword.Text = "Enter Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sorry, this feld is protect , a password is required to get in.";
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 248);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button passwordchange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox passwort;
        private System.Windows.Forms.Label lpassword;
        private System.Windows.Forms.Label label1;
    }
}