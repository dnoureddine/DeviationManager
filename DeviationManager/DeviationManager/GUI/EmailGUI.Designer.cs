﻿namespace DeviationManager.GUI
{
    partial class EmailGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailGUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelSendEmail = new System.Windows.Forms.Button();
            this.sendMessage = new System.Windows.Forms.Button();
            this.messageContent = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelSendEmail);
            this.panel1.Controls.Add(this.sendMessage);
            this.panel1.Controls.Add(this.messageContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 504);
            this.panel1.TabIndex = 0;
            // 
            // cancelSendEmail
            // 
            this.cancelSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("cancelSendEmail.Image")));
            this.cancelSendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelSendEmail.Location = new System.Drawing.Point(715, 432);
            this.cancelSendEmail.Name = "cancelSendEmail";
            this.cancelSendEmail.Size = new System.Drawing.Size(95, 46);
            this.cancelSendEmail.TabIndex = 2;
            this.cancelSendEmail.Text = "Cancel";
            this.cancelSendEmail.UseVisualStyleBackColor = true;
            this.cancelSendEmail.Click += new System.EventHandler(this.cancelSendEmail_Click);
            // 
            // sendMessage
            // 
            this.sendMessage.Image = ((System.Drawing.Image)(resources.GetObject("sendMessage.Image")));
            this.sendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendMessage.Location = new System.Drawing.Point(816, 432);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(94, 46);
            this.sendMessage.TabIndex = 1;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // messageContent
            // 
            this.messageContent.Location = new System.Drawing.Point(12, 30);
            this.messageContent.Multiline = true;
            this.messageContent.Name = "messageContent";
            this.messageContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageContent.Size = new System.Drawing.Size(934, 372);
            this.messageContent.TabIndex = 0;
            // 
            // EmailGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 504);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EmailGUI";
            this.Text = "EmailGUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelSendEmail;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.TextBox messageContent;
    }
}