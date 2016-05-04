namespace DeviationManager.GUI
{
    partial class ApprovementGroupGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovementGroupGUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.approvementGroupsDataGridview = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idGroupeApprovement = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.Label();
            this.role = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.liblle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupEmail = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.approvementGroupsDataGridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.approvementGroupsDataGridview);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 499);
            this.panel1.TabIndex = 0;
            // 
            // approvementGroupsDataGridview
            // 
            this.approvementGroupsDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.approvementGroupsDataGridview.Location = new System.Drawing.Point(12, 215);
            this.approvementGroupsDataGridview.Name = "approvementGroupsDataGridview";
            this.approvementGroupsDataGridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.approvementGroupsDataGridview.Size = new System.Drawing.Size(660, 263);
            this.approvementGroupsDataGridview.TabIndex = 7;
            this.approvementGroupsDataGridview.SelectionChanged += new System.EventHandler(this.approvementGroupsDataGridview_SelectionChanged);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(490, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Register Approvement Group";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.registerApprovementGroupe_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(490, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Delete Approvement Group";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.deleteApprovementGroup_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(490, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "New Approvement Group";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewApprovementGroup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Email);
            this.groupBox1.Controls.Add(this.groupEmail);
            this.groupBox1.Controls.Add(this.idGroupeApprovement);
            this.groupBox1.Controls.Add(this.Id);
            this.groupBox1.Controls.Add(this.role);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.liblle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new approvement Group";
            // 
            // idGroupeApprovement
            // 
            this.idGroupeApprovement.BackColor = System.Drawing.Color.White;
            this.idGroupeApprovement.Enabled = false;
            this.idGroupeApprovement.Location = new System.Drawing.Point(73, 19);
            this.idGroupeApprovement.Multiline = true;
            this.idGroupeApprovement.Name = "idGroupeApprovement";
            this.idGroupeApprovement.Size = new System.Drawing.Size(308, 25);
            this.idGroupeApprovement.TabIndex = 10;
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id.Location = new System.Drawing.Point(6, 20);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(61, 15);
            this.Id.TabIndex = 9;
            this.Id.Text = "ID        : ";
            // 
            // role
            // 
            this.role.BackColor = System.Drawing.Color.White;
            this.role.Location = new System.Drawing.Point(73, 105);
            this.role.Multiline = true;
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(308, 25);
            this.role.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Role    : ";
            // 
            // liblle
            // 
            this.liblle.BackColor = System.Drawing.Color.White;
            this.liblle.Location = new System.Drawing.Point(73, 60);
            this.liblle.Multiline = true;
            this.liblle.Name = "liblle";
            this.liblle.Size = new System.Drawing.Size(308, 25);
            this.liblle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name  : ";
            // 
            // groupEmail
            // 
            this.groupEmail.BackColor = System.Drawing.Color.White;
            this.groupEmail.Location = new System.Drawing.Point(73, 146);
            this.groupEmail.Multiline = true;
            this.groupEmail.Name = "groupEmail";
            this.groupEmail.Size = new System.Drawing.Size(308, 25);
            this.groupEmail.TabIndex = 11;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(6, 147);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(60, 15);
            this.Email.TabIndex = 12;
            this.Email.Text = "Email  : ";
            // 
            // ApprovementGroupGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 499);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApprovementGroupGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approvement Group";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.approvementGroupsDataGridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox liblle;
        private System.Windows.Forms.TextBox role;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView approvementGroupsDataGridview;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox idGroupeApprovement;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox groupEmail;
    }
}