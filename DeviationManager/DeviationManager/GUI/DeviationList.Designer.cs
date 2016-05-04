namespace DeviationManager.GUI
{
    partial class DeviationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviationList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sendMessage = new System.Windows.Forms.Button();
            this.showDeviation = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.DeviationDataGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ldeviationFilterBox = new System.Windows.Forms.GroupBox();
            this.ldate2 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.ldate1 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.product = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.anlage = new System.Windows.Forms.TextBox();
            this.deviationListUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.likeSearch = new System.Windows.Forms.CheckBox();
            this.Filter = new System.Windows.Forms.Button();
            this.requestedBy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deviationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.riskCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deviationNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviationDataGridView)).BeginInit();
            this.ldeviationFilterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sendMessage);
            this.panel1.Controls.Add(this.showDeviation);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.DeviationDataGridView);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ldeviationFilterBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 653);
            this.panel1.TabIndex = 0;
            // 
            // sendMessage
            // 
            this.sendMessage.Image = ((System.Drawing.Image)(resources.GetObject("sendMessage.Image")));
            this.sendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendMessage.Location = new System.Drawing.Point(1078, 196);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(122, 38);
            this.sendMessage.TabIndex = 6;
            this.sendMessage.Text = " Remind Group";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // showDeviation
            // 
            this.showDeviation.Image = ((System.Drawing.Image)(resources.GetObject("showDeviation.Image")));
            this.showDeviation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showDeviation.Location = new System.Drawing.Point(1078, 152);
            this.showDeviation.Name = "showDeviation";
            this.showDeviation.Size = new System.Drawing.Size(122, 38);
            this.showDeviation.TabIndex = 5;
            this.showDeviation.Text = " Show Deviation";
            this.showDeviation.UseVisualStyleBackColor = true;
            this.showDeviation.Click += new System.EventHandler(this.showDeviation_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1078, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = " Close Deviation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.closeDeviation_Click);
            // 
            // DeviationDataGridView
            // 
            this.DeviationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeviationDataGridView.Location = new System.Drawing.Point(12, 240);
            this.DeviationDataGridView.Name = "DeviationDataGridView";
            this.DeviationDataGridView.Size = new System.Drawing.Size(1188, 384);
            this.DeviationDataGridView.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1078, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Edit Deviation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.editDeviation_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1078, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = " Add Deviation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewDeviation_Click);
            // 
            // ldeviationFilterBox
            // 
            this.ldeviationFilterBox.Controls.Add(this.ldate2);
            this.ldeviationFilterBox.Controls.Add(this.date2);
            this.ldeviationFilterBox.Controls.Add(this.ldate1);
            this.ldeviationFilterBox.Controls.Add(this.date1);
            this.ldeviationFilterBox.Controls.Add(this.label7);
            this.ldeviationFilterBox.Controls.Add(this.product);
            this.ldeviationFilterBox.Controls.Add(this.label6);
            this.ldeviationFilterBox.Controls.Add(this.anlage);
            this.ldeviationFilterBox.Controls.Add(this.deviationListUpdate);
            this.ldeviationFilterBox.Controls.Add(this.label5);
            this.ldeviationFilterBox.Controls.Add(this.likeSearch);
            this.ldeviationFilterBox.Controls.Add(this.Filter);
            this.ldeviationFilterBox.Controls.Add(this.requestedBy);
            this.ldeviationFilterBox.Controls.Add(this.label4);
            this.ldeviationFilterBox.Controls.Add(this.deviationType);
            this.ldeviationFilterBox.Controls.Add(this.label3);
            this.ldeviationFilterBox.Controls.Add(this.riskCategory);
            this.ldeviationFilterBox.Controls.Add(this.label2);
            this.ldeviationFilterBox.Controls.Add(this.deviationNO);
            this.ldeviationFilterBox.Controls.Add(this.label1);
            this.ldeviationFilterBox.Location = new System.Drawing.Point(12, 12);
            this.ldeviationFilterBox.Name = "ldeviationFilterBox";
            this.ldeviationFilterBox.Size = new System.Drawing.Size(1060, 222);
            this.ldeviationFilterBox.TabIndex = 0;
            this.ldeviationFilterBox.TabStop = false;
            this.ldeviationFilterBox.Text = "Deviations Filter";
            // 
            // ldate2
            // 
            this.ldate2.AutoSize = true;
            this.ldate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldate2.Location = new System.Drawing.Point(707, 76);
            this.ldate2.Name = "ldate2";
            this.ldate2.Size = new System.Drawing.Size(109, 15);
            this.ldate2.TabIndex = 20;
            this.ldate2.Text = "Date 2              :";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(820, 76);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(219, 20);
            this.date2.TabIndex = 19;
            // 
            // ldate1
            // 
            this.ldate1.AutoSize = true;
            this.ldate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldate1.Location = new System.Drawing.Point(707, 35);
            this.ldate1.Name = "ldate1";
            this.ldate1.Size = new System.Drawing.Size(109, 15);
            this.ldate1.TabIndex = 18;
            this.ldate1.Text = "Date 1              :";
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(820, 35);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(219, 20);
            this.date1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(368, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Anlage              :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // product
            // 
            this.product.Location = new System.Drawing.Point(481, 120);
            this.product.Multiline = true;
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(210, 25);
            this.product.TabIndex = 15;
            this.product.TextChanged += new System.EventHandler(this.product_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Product            :";
            // 
            // anlage
            // 
            this.anlage.Location = new System.Drawing.Point(120, 118);
            this.anlage.Multiline = true;
            this.anlage.Name = "anlage";
            this.anlage.Size = new System.Drawing.Size(228, 25);
            this.anlage.TabIndex = 13;
            this.anlage.TextChanged += new System.EventHandler(this.anlage_TextChanged);
            // 
            // deviationListUpdate
            // 
            this.deviationListUpdate.Image = ((System.Drawing.Image)(resources.GetObject("deviationListUpdate.Image")));
            this.deviationListUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deviationListUpdate.Location = new System.Drawing.Point(820, 175);
            this.deviationListUpdate.Name = "deviationListUpdate";
            this.deviationListUpdate.Size = new System.Drawing.Size(102, 41);
            this.deviationListUpdate.TabIndex = 12;
            this.deviationListUpdate.Text = "Update";
            this.deviationListUpdate.UseVisualStyleBackColor = true;
            this.deviationListUpdate.Click += new System.EventHandler(this.deviationListUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(707, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Use All Inputs   :";
            // 
            // likeSearch
            // 
            this.likeSearch.AutoSize = true;
            this.likeSearch.Location = new System.Drawing.Point(823, 126);
            this.likeSearch.Name = "likeSearch";
            this.likeSearch.Size = new System.Drawing.Size(15, 14);
            this.likeSearch.TabIndex = 10;
            this.likeSearch.UseVisualStyleBackColor = true;
            // 
            // Filter
            // 
            this.Filter.Image = ((System.Drawing.Image)(resources.GetObject("Filter.Image")));
            this.Filter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Filter.Location = new System.Drawing.Point(928, 175);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(122, 41);
            this.Filter.TabIndex = 9;
            this.Filter.Text = "Filter Deviations";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // requestedBy
            // 
            this.requestedBy.Location = new System.Drawing.Point(122, 66);
            this.requestedBy.Multiline = true;
            this.requestedBy.Name = "requestedBy";
            this.requestedBy.Size = new System.Drawing.Size(226, 25);
            this.requestedBy.TabIndex = 8;
            this.requestedBy.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Requested By   :";
            // 
            // deviationType
            // 
            this.deviationType.FormattingEnabled = true;
            this.deviationType.Items.AddRange(new object[] {
            "Specification",
            "Process",
            "Documentation"});
            this.deviationType.Location = new System.Drawing.Point(481, 71);
            this.deviationType.Name = "deviationType";
            this.deviationType.Size = new System.Drawing.Size(210, 21);
            this.deviationType.TabIndex = 6;
            this.deviationType.SelectedIndexChanged += new System.EventHandler(this.deviationType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(368, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Deviation Type  :";
            // 
            // riskCategory
            // 
            this.riskCategory.FormattingEnabled = true;
            this.riskCategory.Items.AddRange(new object[] {
            "RED",
            "YELLOW",
            "GREEN"});
            this.riskCategory.Location = new System.Drawing.Point(481, 30);
            this.riskCategory.Name = "riskCategory";
            this.riskCategory.Size = new System.Drawing.Size(210, 21);
            this.riskCategory.TabIndex = 4;
            this.riskCategory.SelectedIndexChanged += new System.EventHandler(this.riskCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(368, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Risk Category   :";
            // 
            // deviationNO
            // 
            this.deviationNO.Location = new System.Drawing.Point(122, 25);
            this.deviationNO.Multiline = true;
            this.deviationNO.Name = "deviationNO";
            this.deviationNO.Size = new System.Drawing.Size(226, 25);
            this.deviationNO.TabIndex = 2;
            this.deviationNO.TextChanged += new System.EventHandler(this.deviationNO_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DEVIATION NO :";
            // 
            // DeviationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 653);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviationList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Deviation";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeviationDataGridView)).EndInit();
            this.ldeviationFilterBox.ResumeLayout(false);
            this.ldeviationFilterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox ldeviationFilterBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox riskCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox deviationNO;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox requestedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox deviationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DeviationDataGridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button showDeviation;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox likeSearch;
        private System.Windows.Forms.Button deviationListUpdate;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox product;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox anlage;
        private System.Windows.Forms.Label ldate1;
        private System.Windows.Forms.Label ldate2;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Button sendMessage;
    }
}