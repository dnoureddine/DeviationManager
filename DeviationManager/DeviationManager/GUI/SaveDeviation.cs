using DeviationManager.Entity;
using DeviationManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeviationManager.GUI
{
    public partial class SaveDeviation : Form
    {
        private DeviationModel deviationModel;
        private String actionType;
        private Deviation deviation=null;

        public SaveDeviation(String actionType)
        {
            InitializeComponent();
            deviationModel = new DeviationModel();
            this.actionType = actionType;

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
                this.approvementGroupDataGrid.Rows.Add(approvementGroup.approvalId,approvementGroup.liblle);
            }

            this.approvementGroupDataGrid.AllowUserToAddRows = false;

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
        public IList<OtherApprovement> getOtherApprovementToPrint(){

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
            deviation.deviationRiskCategory = this.riskCategory.Text;
            deviation.requestedBy = this.requestedBy.Text;
            deviation.position = this.position.Text;
            deviation.deviationType = this.deviationType.SelectedItem.ToString();
            deviation.describeOtherType = this.deviationDescription.Text;
            deviation.signature = this.deviationSignature.Text;
            deviation.detailStandardCondition = this.standardCondition.Text;
            deviation.detailRequestCondition = this.detailRequestedDeviation.Text;
            deviation.anlage = this.anlage.Text;
            deviation.product = this.product.Text;
            if (this.actionType == "newDeviation")
            {
                deviation.status = "Pending";
            }

            DateTime deviationDateCreation = this.deviationDateCreation.Value;
            DateTime deviationTimeCreation = this.deviationTimeCreation.Value;
            deviation.dateCreation = new DateTime(deviationDateCreation.Year, deviationDateCreation.Month, deviationDateCreation.Day, deviationTimeCreation.Hour, deviationTimeCreation.Minute, deviationTimeCreation.Second);

            DateTime pFirstDate = this.pFirstDate.Value;
            DateTime pFirstTime = this.pFirstTime.Value;
            deviation.startDatePeriod = new DateTime(pFirstDate.Year, pFirstDate.Month, pFirstDate.Day, pFirstTime.Hour, pFirstTime.Minute, pFirstTime.Second);

            DateTime pSecondDate = this.pSecondDate.Value;
            DateTime pSecondTime = this.pSecondTime.Value;
            deviation.endDatePeriod = new DateTime(pSecondDate.Year, pSecondDate.Month, pSecondDate.Day, pSecondTime.Hour, pSecondTime.Minute, pSecondTime.Second);

            

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
            foreach (DataGridViewRow row in this.approvementGroupDataGrid.Rows)
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
                if (row.Cells[3].Value != null)
                {
                    attachement.liblle = row.Cells[3].Value.ToString();
                }
                
                listAttachments.Add(attachement);
            }

            deviation.attachements = listAttachments;
                

            return deviation;
        }

        //update deviation object
        private Deviation getDeviationObjectToUpdate()
        {
            if (this.deviation != null)
            {
                deviation.deviationRef = this.deviationNO.Text;
                deviation.deviationRiskCategory = this.riskCategory.Text;
                deviation.requestedBy = this.requestedBy.Text;
                deviation.position = this.position.Text;
                deviation.deviationType = this.deviationType.SelectedItem.ToString();
                deviation.describeOtherType = this.deviationDescription.Text;
                deviation.signature = this.deviationSignature.Text;
                deviation.detailStandardCondition = this.standardCondition.Text;
                deviation.detailRequestCondition = this.detailRequestedDeviation.Text;
                deviation.anlage = this.anlage.Text;
                deviation.product = this.product.Text;
                if (this.actionType == "newDeviation")
                {
                    deviation.status = "Pending";
                }

                DateTime deviationDateCreation = this.deviationDateCreation.Value;
                DateTime deviationTimeCreation = this.deviationTimeCreation.Value;
                deviation.dateCreation = new DateTime(deviationDateCreation.Year, deviationDateCreation.Month, deviationDateCreation.Day, deviationTimeCreation.Hour, deviationTimeCreation.Minute, deviationTimeCreation.Second);

                DateTime pFirstDate = this.pFirstDate.Value;
                DateTime pFirstTime = this.pFirstTime.Value;
                deviation.startDatePeriod = new DateTime(pFirstDate.Year, pFirstDate.Month, pFirstDate.Day, pFirstTime.Hour, pFirstTime.Minute, pFirstTime.Second);

                DateTime pSecondDate = this.pSecondDate.Value;
                DateTime pSecondTime = this.pSecondTime.Value;
                deviation.endDatePeriod = new DateTime(pSecondDate.Year, pSecondDate.Month, pSecondDate.Day, pSecondTime.Hour, pSecondTime.Minute, pSecondTime.Second);



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

            }

            return this.deviation;
        }

        //show form to update deviation
        public void updateDeviation(Deviation deviation)
        {
            this.deviationNO.Text = deviation.deviationRef;
            this.riskCategory.Text = deviation.deviationRiskCategory;           
            this.requestedBy.Text = deviation.requestedBy;
            this.deviationDateCreation.Value = (DateTime)deviation.dateCreation;
            this.deviationTimeCreation.Value = (DateTime)deviation.dateCreation;
            this.position.Text = deviation.position;
            this.deviationType.SelectedItem=deviation.deviationType;
            this.deviationSignature.Text=deviation.signature;
            this.standardCondition.Text=deviation.detailStandardCondition;
            this.detailRequestedDeviation.Text=deviation.detailRequestCondition;
            this.pFirstDate.Value = (DateTime)deviation.startDatePeriod;
            this.pFirstTime.Value = (DateTime) deviation.startDatePeriod;
            this.pSecondDate.Value=(DateTime)deviation.endDatePeriod;
            this.pSecondTime.Value = (DateTime)deviation.endDatePeriod; 
            this.deviationDescription.Text = deviation.describeOtherType;
            this.anlage.Text = deviation.anlage;
            this.product.Text = deviation.product;


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
                this.uploadFileDataGridView.Rows.Add(attachment.fileName, attachment.fileNameDb, attachment.date.ToString(),attachment.liblle);
            }

            //set Approvement
            var approvements = deviation.approvements;
            foreach(var approvement in approvements){
                var approved = new CheckBox().Checked=approvement.approved;
                var rejected = new CheckBox().Checked=approvement.rejected;
                var signed = new CheckBox().Checked=approvement.signed;
                var date = "";
                if (approvement.date != null)
                {
                    date = approvement.date.Value.ToString();
                }

       
                this.approvementGroupDataGrid.Rows.Add(approvement.approvementId, approvement.approvementGroup.liblle, approvement.name, approved, rejected, signed, date,approvement.comment,"OK");
            }


            this.deviation = deviation;
            this.deviationSignature.Enabled = false;
            this.deviationNO.Enabled = false;
            this.approvementGroupDataGrid.AllowUserToAddRows = false;
            this.Show();
        }


        //show deviation
        public void showDeviation(Deviation deviation){

            this.updateDeviation(deviation);

            this.deviationSignature.Enabled = false;
            this.deviationNO.Enabled = false;
            this.approvementGroupDataGrid.AllowUserToAddRows = false;
            this.addDocument.Enabled = false;
            this.deleteDocument.Enabled = false;
            this.DeviationSave.Enabled = false;
            this.closeDeviation.Enabled = false;
            this.deviation = deviation;

            this.Show();

        }
       
        //validate deviation period
        private int validateDeviationPeriod()
        {
            DateTime pFirstDate = this.pFirstDate.Value;
            DateTime pFirstTime = this.pFirstTime.Value;
            DateTime pFirstDateTime = new DateTime(pFirstDate.Year, pFirstDate.Month, pFirstDate.Day, pFirstTime.Hour, pFirstTime.Minute, pFirstTime.Second);

            DateTime pSecondDate = this.pSecondDate.Value;
            DateTime pSecondTime = this.pSecondTime.Value;
            DateTime pSecondDateTime =  new DateTime(pSecondDate.Year, pSecondDate.Month, pSecondDate.Day, pSecondTime.Hour, pSecondTime.Minute, pSecondTime.Second);

            return DateTime.Compare(pFirstDateTime, pSecondDateTime);
        }
        //Approvement validation
        private String validateApprovement(DataGridViewRow row){

            String isValid = "valid";

            if (row.Cells[2].Value==null)
            {
                isValid = " Name Value Null, "; 
            }
            DataGridViewCheckBoxCell approved = (DataGridViewCheckBoxCell)row.Cells[3];
            DataGridViewCheckBoxCell rejected = (DataGridViewCheckBoxCell)row.Cells[4];

            if (((bool)approved.Value != true) && ((bool)rejected.Value != true))
            {
                if (isValid == "valid")
                {
                    isValid = " Yous Must Reject Or Approve The Deviation !";
                }
                else
                {
                    isValid = isValid + "And You Must Reject Or Approve The Deviation !";
                }
            }
           
            return isValid;
        }
        /***********************    Events  **************************************************************************/

        private void saveDeviation_Click(object sender, EventArgs e)
        {
            FormValidation formValidation = new FormValidation();
            bool requestedBy = formValidation.isTextBoxNotNull(this.requestedBy, errorProvider1);
            bool position = formValidation.isTextBoxNotNull(this.position, errorProvider1);
            bool standardCondition = formValidation.isTextBoxNotNull(this.standardCondition, errorProvider1);
            bool detailRequestedDevV = formValidation.isTextBoxNotNull(this.detailRequestedDeviation, errorProvider1);
            bool deviationType = formValidation.isItemFromComoBoxSelected(this.deviationType, errorProvider1);
            int compareDeviationPeriod = this.validateDeviationPeriod();

            if (requestedBy && position && standardCondition && detailRequestedDevV && deviationType && compareDeviationPeriod != 0 && compareDeviationPeriod < 0)
            {
                Deviation deviation = this.getDeviationObject();
                if (this.actionType == "newDeviation")
                {
                  
                    //add a new Deviation
                    //verify if the user is one of the Group
                    //redirect the user to se the email content
                    EmailGUI emailGUI = new EmailGUI(deviation, this);
                    emailGUI.Show();
                }
                else
                {
                    //update DEVIATION
                    // before updating verify the Autorisation
                    if (this.deviation != null)
                    {
                        deviationModel.updateDeviation(this.getDeviationObjectToUpdate());
                        MessageBox.Show("The Deviation Was Successfly Updated.", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                
                    }
               
                }
                
            }
            else
            {
                MessageBox.Show("The Form Inputs Are Not Valid !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (compareDeviationPeriod == 0)
                {
                    MessageBox.Show("The Deviation Period Has Not To Be Null!, You Can Choose Different Dates To Avoid This.", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (compareDeviationPeriod > 0)
                {
                    MessageBox.Show("The Deviation Period Has Not Valid !, The Input <<P.Second date>> Must Be Bigger Than the Input <<P.First date>>", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //initialize form
        private void initialize()
        {
            this.yesNoReginal.SelectedIndex = 1;
            this.yesNoProductEng.SelectedIndex = 1;
            this.yesNoManufactEng.SelectedIndex = 1;
            this.yesNoCustomer.SelectedIndex = 1;
        }

        //***__ __***
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


        private void standardCondition_GotFocus(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.standardCondition, "");
        }

        private void detailRequestedDeviation_GotFocus(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.detailRequestedDeviation, "");
        }

        private void deviationType_SelectedValueChanged(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.deviationType, "");
        }



        //Close Deviation
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

        //show diagramms of deviation in other Win
        private void button1_Click(object sender, EventArgs e)
        {
            String fileSave = this.uploadFileDataGridView.CurrentRow.Cells[1].Value.ToString();

            ShowDiagramms showDiagramm = new ShowDiagramms(this.uploadFileDataGridView);
            showDiagramm.Show();
        }

        //delete An Attachement
        private void deleteDocument_Click(object sender, EventArgs e)
        {
            if (this.uploadFileDataGridView.CurrentRow != null)
            {
                if (MessageBox.Show("Are Sure, You Wish to Delete This Attachment ?", "Delete Attachment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UploadFile uploadFile = new UploadFile("u288026726", "alter6+");
                    String fileNameDB = this.uploadFileDataGridView.CurrentRow.Cells[1].Value.ToString();

                    //Delete File using FTP
                    String result = uploadFile.deleteFileFTP("ftp://31.170.165.123/" + fileNameDB);
                    if (result == "deleted")
                    {
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
        }


        //make the approvement
        private void approvementGroupDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.actionType == "newDeviation")
            {
                MessageBox.Show("You Can Not Make This Action Now, You Schould First Save The Deviation !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (e.ColumnIndex == 8)
                {
                    //Get The Approvement ID
                    var approvementID = (int)this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[0].Value;
                    String approvementValidation = this.validateApprovement((DataGridViewRow)this.approvementGroupDataGrid.Rows[e.RowIndex]);
                    if (approvementValidation == "valid")
                    {
                        //make Sure that the user has the Right to set Approvement
                        Autorisation aut = new Autorisation();
                        String toApprove = aut.cannApprove(approvementID);
                        if (toApprove == "canApprove")
                        {
                            //make the Approvement
                            Approvement approvement = deviationModel.getApprovement(approvementID);
                            if (approvement != null) {
                                approvement.name = this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                                approvement.approved = (bool)this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[3].Value;
                                approvement.rejected = (bool)this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[4].Value;
                                approvement.signed = (bool)this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[5].Value;
                                approvement.date = DateTime.Now;
                                if (this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[7].Value != null)
                                {
                                    approvement.comment = this.approvementGroupDataGrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                                }

                                deviationModel.updateApprovement(approvement);
                                MessageBox.Show("Your Approvement Was Succesfuly Done !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Action Failed." + toApprove, "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some Inputs Are Required ." + approvementValidation, "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                
            }
           
        }


        //Print Deviation
        private void DeviationPrint_Click(object sender, EventArgs e)
        {
            if (this.actionType == "newDeviation")
            {
                MessageBox.Show("You Can Not Make This Action Now, You Schould First Save The Deviation !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else{
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "Choose A Directory To Save Your File";

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    var pdfGenerator = new PDFDeviationGenerator(25, 25, 45, 45);
                    String filePath = folderBrowser.SelectedPath;
                    IList<OtherApprovement> otherApprovements = this.getOtherApprovementToPrint();
                    String fileSave = pdfGenerator.createPdfDeviation(this.deviation, otherApprovements, filePath);

                    Process.Start(fileSave);

                }
            }
        }

        // choose risk category 
        private void riskCategory_Click(object sender, EventArgs e)
        {
            RiskMatrix riskMatrix = new RiskMatrix(this.riskCategory);
            riskMatrix.ShowDialog();
            riskCategory.Focus();
        }



        /******_____class ***/

    }
}
