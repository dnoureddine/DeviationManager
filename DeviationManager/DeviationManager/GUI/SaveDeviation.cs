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
    public partial class SaveDeviation : Form
    {
        private DeviationModel deviationModel;

        public SaveDeviation(String actionType)
        {
            InitializeComponent();
            deviationModel = new DeviationModel();

            initialize();
            if (actionType == "newDeviation")
            {
                addApproval();
                setSignature();
            }

        }


        /**************************************************************************************/

        /************* add Approval to Approvement Group **********/
        public void addApproval()
        {
            var approvementGroups = deviationModel.listApprovementGroup();
            foreach (var approvementGroup in approvementGroups)
            {
                this.approventGroupDataGrid.Rows.Add(approvementGroup.approvalId,approvementGroup.liblle);
            }

            this.approventGroupDataGrid.AllowUserToAddRows = false;

            /******** set deviation Number *****/
            this.deviationNO.Text = deviationModel.getDeviationNumber();
            this.deviationNO.Enabled = false;
        }


        /******* get user name to set siganture  and make signature field uneditable  ****/
        public void setSignature()
        {
            this.deviationSignature.Text = deviationModel.getUserNameFromActiveDirectory();
            this.deviationSignature.Enabled = false;
        }


        /*******   get Other Approvement to print ****/
        public List<OtherApprovement> getOtherApprovementToPrint(){

            OtherApprovement regionalQuality = new OtherApprovement
            {
                title = "REGIONAL QUALITY DIRECTOR APPROVAL:  REFER TO FTDS-BM-P-008  FOR REQUIREMENT",
                selectYesNo = this.yesNoReginal.Text,
                date=this.dateRegional.Value,
                positionApproval= this.positionRegional.Text,
                nameApproval=this.nameReginal.Text,
                signatureApproval=this.signatureRegional.Text,
                requestApproved=this.requestApprovedRegional.Checked,
                requestRejected=this.requestRejectedRegional.Checked
            };

            OtherApprovement productEng = new OtherApprovement
            {
                title = "PRODUCT ENGINEERING APPROVAL:  REFER TO FTDS-BM-P-008  FOR REQUIREMENT",
                selectYesNo = this.yesNoProductEng.Text,
                date = this.dateProductEng.Value,
                positionApproval = this.positionProductEng.Text,
                nameApproval = this.nameProductEng.Text,
                signatureApproval = this.signatureProductEng.Text,
                requestApproved = this.requestApprovedProductEng.Checked,
                requestRejected = this.requestRejectedProductEng.Checked
            };

            OtherApprovement ManufactEng = new OtherApprovement
            {
                title = "MANUFACTURING ENGINEERING APPROVAL:  REFER TO FTDS-BM-P-008  FOR REQUIREMENT",
                selectYesNo = this.yesNoManufactEng.Text,
                date = this.dateManufactEng.Value,
                positionApproval = this.positionManufactEng.Text,
                nameApproval = this.nameManufactEng.Text,
                signatureApproval = this.signatureManufactEng.Text,
                requestApproved = this.requestedApprovedManufactEng.Checked,
                requestRejected = this.requestRejectedManufactEng.Checked
            };

            OtherApprovement customer = new OtherApprovement
            {
                title = "CUSTOMER APPROVAL:  REFER TO FTDS-BM-P-008  FOR REQUIREMENT",
                selectYesNo = this.yesNoCustomer.Text,
                date = this.dateCustomer.Value,
                positionApproval = this.positionCustomer.Text,
                nameApproval = this.nameCustomer.Text,
                signatureApproval = this.signatureCustomer.Text,
                requestApproved = this.requestApprovedCustomer.Checked,
                requestRejected = this.requestRejectedCustomer.Checked
            };

            List<OtherApprovement> listOtherApprovement = new List<OtherApprovement>();
            listOtherApprovement.Add(regionalQuality);
            listOtherApprovement.Add(productEng);
            listOtherApprovement.Add(ManufactEng);
            listOtherApprovement.Add(customer);

            return listOtherApprovement;
        }


        //create a Deviation object from Form inputs
        private Deviation getDeviationObject()
        {
            Deviation deviation = new Deviation();

            deviation.deviationRef = this.deviationNO.Text;
            deviation.deviationRiskCategory = this.riskCategory.SelectedItem.ToString();
            deviation.requestedBy = this.requestedBy.Text;
            deviation.dateCreation = this.deviationDateCreation.Value;
            deviation.position = this.position.Text;
            deviation.deviationType = this.deviationType.SelectedItem.ToString();
            deviation.describeOtherType = this.deviationDescription.Text;
            deviation.signature = this.deviationSignature.Text;
            deviation.detailStandardCondition = this.standardCondition.Text;
            deviation.detailRequestCondition = this.detailRequestedDeviation.Text;
            deviation.startDatePeriod = this.pFirstDate.Value;
            deviation.endDatePeriod = this.pSecondDate.Value;
            

            //add Reasons
            IList<Reason> listReasons = new List<Reason>();
            Reason reas1 = new Reason { reason = this.reason1.Text };
            Reason reas2 = new Reason { reason = this.reason2.Text };
            Reason reas3 = new Reason { reason = this.reason3.Text };
            Reason reas4 = new Reason { reason = this.reason4.Text };
            Reason reas5 = new Reason { reason = this.reason5.Text };
            listReasons.Add(reas1); listReasons.Add(reas2); listReasons.Add(reas3);
            listReasons.Add(reas4); listReasons.Add(reas5);
            deviation.reasons = listReasons;


            //add Approvement Groups
            IList<Approvement> listApprovements = new List<Approvement>();
            foreach (DataGridViewRow row in this.approventGroupDataGrid.Rows)
            {
                int approvementGroupId =(int)row.Cells[0].Value;
                if (approvementGroupId != 0)
                {
                    ApprovementGroup approvementGroup = deviationModel.getApprovementGroup(approvementGroupId);
                    if (approvementGroup != null)
                    {
                        Approvement approvement = new Approvement();
                        approvement.approvementGroup = approvementGroup;
                        listApprovements.Add(approvement);
                    }
                }
            }

            deviation.approvements = listApprovements;


            //Add Attachments
            IList<Attachments> listAttachments = new List<Attachments>();
            foreach (DataGridViewRow  row in this.uploadFileDataGridView.Rows)
            {
                Attachments attachement = new Attachments();
                attachement.fileName = row.Cells[0].Value.ToString();
                attachement.fileNameDb = row.Cells[1].Value.ToString();
                attachement.date = DateTime.Now;

                listAttachments.Add(attachement);
            }

            deviation.attachements = listAttachments;
                

            return deviation;
        }


        //shoe form to update deviation
        public void updateDeviation(Deviation deviation)
        {
            this.deviationNO.Text = deviation.deviationRef;
            this.riskCategory.SelectedText = deviation.deviationRiskCategory;
            this.requestedBy.Text = deviation.requestedBy;
            this.deviationDateCreation.Value = (DateTime)deviation.dateCreation;
            this.position.Text=deviation.position;
            this.deviationType.SelectedText=deviation.deviationType;
            this.deviationSignature.Text=deviation.signature;
            this.standardCondition.Text=deviation.detailStandardCondition;
            this.detailRequestedDeviation.Text=deviation.detailRequestCondition;
            this.pFirstDate.Value=(DateTime)deviation.startDatePeriod;
            this.pSecondDate.Value=(DateTime)deviation.endDatePeriod;
            this.deviationDescription.Text = deviation.describeOtherType;

            //set Resons
            var reasons = deviation.reasons;
            this.reason1.Text = reasons.ElementAt<Reason>(0).reason;
            this.reason2.Text = reasons.ElementAt<Reason>(1).reason;
            this.reason3.Text = reasons.ElementAt<Reason>(2).reason;
            this.reason4.Text = reasons.ElementAt<Reason>(3).reason;
            this.reason5.Text = reasons.ElementAt<Reason>(4).reason;

            //set Attachments
            var attachements = deviation.attachements;
            foreach (var attachment in attachements)
            {
                this.uploadFileDataGridView.Rows.Add(attachment.fileName, attachment.fileNameDb, attachment.date.ToString());
            }

            //set Approvement
            var approvements = deviation.approvements;
            foreach(var approvement in approvements){
                if (deviationModel.getApprovementGroup(approvement) != null)
                {
                   // MessageBox.Show("Null");
                }
            }



            this.deviationSignature.Enabled = false;
            this.deviationNO.Enabled = false;
            this.approventGroupDataGrid.AllowUserToAddRows = false;
            this.Show();
        }


        //show deviation
        public void showDeviation(Deviation deviation){

            this.updateDeviation(deviation);

            this.deviationSignature.Enabled = false;
            this.deviationNO.Enabled = false;
            this.approventGroupDataGrid.AllowUserToAddRows = false;
            this.addDocument.Enabled = false;
            this.deleteDocument.Enabled = false;
            this.DeviationSave.Enabled = false;
            this.closeDeviation.Enabled = false;

            this.Show();

        }


        /***********************    Events  **************************************************************************/

        private void saveDeviation_Click(object sender, EventArgs e)
        {
            FormValidation formValidation = new FormValidation();
            bool requestedBy = formValidation.isTextBoxNotNull(this.requestedBy, errorProvider1);
            bool position = formValidation.isTextBoxNotNull(this.position, errorProvider1);
            bool reason1 = formValidation.isTextBoxNotNull(this.reason1, errorProvider1);

            if (requestedBy || position || reason1)
            {
                Deviation deviation = this.getDeviationObject();
                if (deviation.deviationId != 0)
                {
                    //update DEVIATION
                    // before updating verify the Autorisation
                }
                else
                {
                    //add a new Deviation
                    //verify if the user is one of the Group
                    //redirect the user to se the email content
                    EmailGUI emailGUI = new EmailGUI(deviation,this);
                    emailGUI.Show();
                    
                }
                
            }
            else
            {
                MessageBox.Show("The Form Inputs Are Not Valid !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //initialize form
        private void initialize()
        {
            this.riskCategory.SelectedIndex = 1;
            this.deviationType.SelectedIndex = 1;
            this.yesNoReginal.SelectedIndex = 1;
            this.yesNoProductEng.SelectedIndex = 1;
            this.yesNoManufactEng.SelectedIndex = 1;
            this.yesNoCustomer.SelectedIndex = 1;
        }


        private void requestedBy_GotFocus(object sender, EventArgs e)
        {

            this.errorProvider1.SetError(this.requestedBy, "");
        }

        private void position_GotFocus(object sender, EventArgs e)
        {

            this.errorProvider1.SetError(this.position, "");
        }

        private void reason1_GotFocus(object sender, EventArgs e)
        {

            this.errorProvider1.SetError(this.reason1, "");
        }

        private void DeviationPrint_Click(object sender, EventArgs e)
        {

        }

        private void closeDeviation_Click(object sender, EventArgs e)
        {
            String deviationRef = this.deviationNO.Text;
            if (deviationRef != "" || deviationRef != null)
            {
                if (MessageBox.Show("Close Deviation Means You Will Not Be Able Later To Make Any Change On It, Are You Sure You Wish To Make This Action ?", "Close Deviation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (deviationModel.closeDeviation(deviationRef) == null)
                    {
                        MessageBox.Show("The Deviation You Are Trying To Close Was Not Found In The Database !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        //Add diagrams 
        private void addDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                UploadFile uploadFile = new UploadFile("u288026726","alter6+");

                String fileNameDB = uploadFile.generateFileName(fileDialog.SafeFileName);
                String fileName = fileDialog.SafeFileName;
                String filePath = fileDialog.FileName;


                String result = uploadFile.UploadFielToFtp("ftp://31.170.165.123/" + fileNameDB, filePath);


                if (result == "uploaded")
                {

                    this.uploadFileDataGridView.Rows.Add(fileName, fileNameDB, DateTime.Now.ToString());
                }
                else
                {
                    MessageBox.Show(result, "Infos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            } 
        }

        private void downloadDocument_Click(object sender, EventArgs e)
        {
           
            if (this.uploadFileDataGridView.CurrentRow != null)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description="Choose A Directory To Save You File";

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    String saveDirectory = folderBrowser.SelectedPath;
                    String fileSave = this.uploadFileDataGridView.CurrentRow.Cells[1].Value.ToString();
                    UploadFile uploadFile = new UploadFile("u288026726", "alter6+");

                    String result = uploadFile.DownloadFileFTP("ftp://31.170.165.123/" + fileSave, saveDirectory+"/"+fileSave);
                    if (result == "downloaded")
                    {
                        MessageBox.Show("File Downloaded !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result, "Infos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        //show diagramms of deviation in other Fen
        private void button1_Click(object sender, EventArgs e)
        {
            String fileSave = this.uploadFileDataGridView.CurrentRow.Cells[1].Value.ToString();

            ShowDiagramms showDiagramm = new ShowDiagramms("ftp://31.170.165.123/"+fileSave);
            showDiagramm.Show();
        }

        //delete An Attachement
        private void deleteDocument_Click(object sender, EventArgs e)
        {
            if (this.uploadFileDataGridView.CurrentRow != null)
            {
                UploadFile uploadFile = new UploadFile("u288026726", "alter6+");
                String fileNameDB = this.uploadFileDataGridView.CurrentRow.Cells[1].Value.ToString();

                //Delete File using FTP
                String result= uploadFile.deleteFileFTP("ftp://31.170.165.123/" + fileNameDB);
                if(result=="deleted"){
                    //delete File in DB
                    deviationModel.deleteAttachment(fileNameDB);

                    //remove from DataGridView
                    this.uploadFileDataGridView.Rows.RemoveAt(this.uploadFileDataGridView.CurrentRow.Index);
                    MessageBox.Show("File Deleted !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result, "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }




        /******_____class ***/

    }
}
