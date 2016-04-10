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
        public SaveDeviation()
        {
            InitializeComponent();
            addApproval();
            setSignature();

        }


        /**************************************************************************************/

        /************* add Approval to Approvement Group **********/
        public void addApproval()
        {
            DeviationModel model = new DeviationModel();
            var approvementGroups = model.listApprovementGroup();
            foreach (var approvementGroup in approvementGroups)
            {
                this.approventGroupDataGrid.Rows.Add(approvementGroup.liblle);
            }

            this.approventGroupDataGrid.AllowUserToAddRows = false;

            /******** set deviation Number *****/
            this.deviationNO.Text = model.getDeviationNumber();
            this.deviationNO.Enabled = false;
        }


        /******* get user name to set siganture  and make signature field uneditable  ****/
        public void setSignature()
        {
            DeviationModel model = new DeviationModel();
            this.signature.Text = model.getUserNameFromActiveDirectory();
            this.signature.Enabled = false;
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


        /***********************    Events  *****************************************/

        private void saveDeviation_Click(object sender, EventArgs e)
        {
            FormValidation formValidation = new FormValidation();
            bool requestedBy = (formValidation.isTextBoxNotNull(this.requestedBy, errorProvider1) || formValidation.isOnlyCharecters(this.requestedBy, errorProvider1));
            bool position = (formValidation.isTextBoxNotNull(this.position, errorProvider1) || formValidation.isOnlyCharecters(this.position, errorProvider1));
            bool reason1 = formValidation.isTextBoxNotNull(this.reason1, errorProvider1);

            if (requestedBy || position || reason1)
            {
                //save deviation
            }
            else
            {
                MessageBox.Show("Form is not valid ...!");
            }
        }

        private void SaveDeviation_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void DeviationPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
