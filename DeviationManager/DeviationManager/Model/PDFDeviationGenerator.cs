using DeviationManager.Entity;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviationManager.Model
{
    public class PDFDeviationGenerator
    {
        private Document doc;
        private Font normal;
        private Font normalBold;
        private Font small;

        public PDFDeviationGenerator(int x1, int x2, int x3, int x4)
        {
            doc = new Document(PageSize.A4, x1, x2, x3, x4);
            normal = FontFactory.GetFont("Arial", 7, BaseColor.BLACK);
            normalBold = FontFactory.GetFont("Arial", 7, Font.BOLD);
            small = FontFactory.GetFont("Arial", 5);
        }


        // get Pdf Writer to be able to write in the document 
        public PdfWriter getPdfWriter(String filePath)
        {
            PdfWriter pdfWriter = PdfWriter.GetInstance(this.doc, new System.IO.FileStream(filePath, System.IO.FileMode.Append));
            this.doc.Open();

            return pdfWriter;
        }


        //add table cell
        private void addTableCell(PdfPTable table, String text, Font font, int collapse, int allignement)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Colspan = collapse;
            cell.Padding = 8;
            cell.HorizontalAlignment = allignement;
            table.AddCell(cell);
        }

        //add table cell
        private void addTableCell(PdfPTable table, String text, Font font, int collapse, int allignement, String color)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            BaseColor cellBackColor = WebColors.GetRGBColor(color);
            cell.BackgroundColor = cellBackColor;
            cell.Colspan = collapse;
            cell.Padding = 8;
            cell.HorizontalAlignment = allignement;
            table.AddCell(cell);
        }


        // using the pdf writer generate the page header
        public PdfPTable generatePageHead()
        {
            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 100;

            Image logoIm = Image.GetInstance("logo.png");
            PdfPCell logo = new PdfPCell();
            logo.FixedHeight = 50f;
            logo.Colspan = 2;
            logo.Padding = 4;
            logo.HorizontalAlignment = 1;
            logo.AddElement(logoIm);
            table.AddCell(logo);

            //Title  cell
            this.addTableCell(table, "TI FTDS Quality Management System1", normal, 5, 0);

            //Document Number  cell
            this.addTableCell(table, "Document Number: FTDS-BM-F-001", normal, 2, 0);

            //Process Chqmpion  cell
            this.addTableCell(table, "Process Champion:  Global Quality Standards Manager", normal, 5, 0);


            //Document title  cell
            this.addTableCell(table, "Document Title:  DEVIATION REPORT", normal, 2, 0);

            //Process Approver cell
            this.addTableCell(table, "Process Approver:  Global Quality & Warranty Director", normal, 5, 0);

            //user Document cell
            this.addTableCell(table, "Usage of Document:", normal, 1, 0);

            //FTDS -BM-P-008 Deviation Control Procedure cell
            this.addTableCell(table, "FTDS -BM-P-008 Deviation Control Procedure Documentation and Approval of Deviations which are departures from standard procedures, product specifications or process controls.", normal, 3, 0);


            //scope of document  cell
            this.addTableCell(table, "Scope of Document:", normal, 1, 0);

            //TI FTDS Division  cell
            this.addTableCell(table, "TI FTDS Division", normal, 2, 0);



            return table;

        }


        public PdfPTable createDeviationContent(PdfPTable table, Deviation deviation)
        {
            //Deviation No cell
            this.addTableCell(table, "DEVIATION NO:", normal, 1, 0);

            //Deviation No Value cell
            this.addTableCell(table, "DR-", normal, 2, 0);

            // Risk Category cell
            this.addTableCell(table, "RISK CATEGORY:", normal, 2, 0);

            // Risk Category Value cell
            this.addTableCell(table,deviation.deviationRiskCategory, normal, 2, 0);

            // Requested by cell
            this.addTableCell(table, "REQUESTED BY:", normal, 1, 0);

            // Requested by value cell
            this.addTableCell(table, deviation.requestedBy, normal, 3, 0);

            // DATE cell
            this.addTableCell(table, "DATE:", normal, 1, 0);

            // DATE value cell
            this.addTableCell(table, deviation.dateCreation.ToString(), normal, 2, 0);

            // Signature cell
            this.addTableCell(table, "SIGNATURE:", normal, 1, 0);

            //Signature value cell
            this.addTableCell(table, "", normal, 3, 0);

            // position cell
            this.addTableCell(table, "POSITION:", normal, 1, 0);

            // position value cell
            this.addTableCell(table, deviation.position, normal, 2, 0);

            // deviation type cell
            this.addTableCell(table, "DEVIATION TYPE:", normal, 2, 0);

            // deviation type value cell
            this.addTableCell(table, deviation.deviationType, normal, 1, 0);

            // Other Description value cell
            this.addTableCell(table, "Other : "+deviation.describeOtherType, normal, 7, 0);

            // Detail description of deviation cell
            this.addTableCell(table, "DETAILED DESCRIPTION OF DEVIATION (detail product name / procedure number / specification / etc)", normal, 7, 0);

            // Standard condition cell
            this.addTableCell(table, "Standard Condition", normal, 3, 1, "#0095ff");

            // detail requested condition cell
            this.addTableCell(table, "Detail Requested Condition", normal, 4, 1, "#0095ff");

            // Standard condition  value cell
            this.addTableCell(table, deviation.detailRequestCondition, normal, 3, 0);

            // detail requested condition value  cell
            this.addTableCell(table, deviation.detailStandardCondition, normal, 4, 0);

            // 5 why cell
            this.addTableCell(table, "DETAIL 5 WHY TO SHOW REASON CHANGE FOR DEVIATION:", normal, 7, 0, "#0095ff");

            // why 1 cell
            var reasons = deviation.reasons;
            this.addTableCell(table, "WHY: " + reasons.ElementAt<Reason>(0).reason, normal, 7, 0);

            // why 2 cell
            this.addTableCell(table, "WHY: " + reasons.ElementAt<Reason>(1).reason, normal, 7, 0);

            // why 3 cell
            this.addTableCell(table, "WHY: " + reasons.ElementAt<Reason>(2).reason, normal, 7, 0);

            // why 4 cell
            this.addTableCell(table, "WHY: " + reasons.ElementAt<Reason>(3).reason, normal, 7, 0);

            // why 5 cell
            this.addTableCell(table, "WHY: " + reasons.ElementAt<Reason>(4).reason, normal, 7, 0);

            // Period deviation cell
            this.addTableCell(table, "PERIOD FOR DEVIATION /or PERMANENT(shift / week / etc)", normal, 3, 0, "#0095ff");

            // Period deviation value  cell
            TimeSpan t = (TimeSpan)(deviation.endDatePeriod - deviation.startDatePeriod);
            int countMinutes = (int)t.TotalMinutes;
            int days = countMinutes / (24 * 60);
            int hours = (countMinutes - (days * 24 * 60)) / 60;
            int minutesnb = countMinutes - (days * 24 * 60) - (hours * 60);

            this.addTableCell(table, days+" Days  "+hours+" Hours  "+minutesnb+" Minutes", normal, 4, 0);


            // DENTFY THE FIRST AND LAST PART NUMBER  FOR DEVIATION  ... cell
            this.addTableCell(table, "IDENTFY THE FIRST AND LAST PART NUMBER  FOR DEVIATION OR IDENTIFY ALTERNATIVE IDENTIFICATION METHOD (For example circle on base of tank - include photo, diagram where applicable)", normal, 7, 0, "#0095ff");


            // DENTFY THE FIRST AND LAST PART NUMBER  FOR DEVIATION value  ... cell
            this.addTableCell(table, ".................\n .....................\n .....................\n ..................... \n .....................", normal, 7, 0);


            return table;
        }


        /********   add Aprovement to Deivation pdf ****/
        private PdfPTable createApprovementPdf(PdfPTable table, Deviation deviation)
        {

            // Approval cell
            this.addTableCell(table, "APPROVAL", normalBold, 1, 1, "#0095ff");

            // Name cell
            this.addTableCell(table, "NAME", normalBold, 1, 1, "#0095ff");

            // Approve cell
            this.addTableCell(table, "APPROVE", normalBold, 1, 1, "#0095ff");

            // Reject cell
            this.addTableCell(table, "REJECT", normalBold, 1, 1, "#0095ff");

            // Comments cell
            this.addTableCell(table, "COMMENTS", normalBold, 1, 1, "#0095ff");

            // Signed cell
            this.addTableCell(table, "SIGNED", normalBold, 1, 1, "#0095ff");

            // Signed cell
            this.addTableCell(table, "DATE", normalBold, 1, 1, "#0095ff");

            //Get All Approvement
            var approvements = deviation.approvements;
            foreach (var approvement in approvements)
            {             
                    // Approval cell
                    this.addTableCell(table, approvement.approvementGroup.liblle, normal, 1, 0);

                    // Name cell
                    this.addTableCell(table, approvement.name, normal, 1, 0);

                    // Approve cell
                    this.addTableCell(table, approvement.approved.ToString(), normal, 1, 0);

                    // Reject cell
                    this.addTableCell(table, approvement.rejected.ToString(), normal, 1, 0);

                    // Comments cell
                    this.addTableCell(table, approvement.comment, normal, 1, 0);

                    // Signed cell
                    this.addTableCell(table, "", normal, 1, 0);

                    // date cell
                    this.addTableCell(table, approvement.date.ToString(), normal, 1, 0);
                
            }

            
            return table;
        }



        /******** add other(the last part of the deviation)  ****/
        private PdfPTable createDeviationOtherOneTablePdf(PdfPTable table, OtherApprovement otherApprovement)
        {
            // Head cell
            this.addTableCell(table, otherApprovement.title, normalBold, 6, 0, "#FF0000");

            // Yes/No value cell
            this.addTableCell(table, otherApprovement.selectYesNo, normal, 1, 0, "#ff9933");

            // Request Approved value cell
            this.addTableCell(table, "REQUEST APPROVED", small, 1, 0);

            // Request Approved value value cell
            this.addTableCell(table, otherApprovement.requestApproved.ToString(), small, 1, 0);

            // Name cell
            this.addTableCell(table, "NAME", small, 1, 0);

            // Name value cell
            this.addTableCell(table, otherApprovement.nameApproval, small, 4, 0);

            // REQUEST REJECTED cell
            this.addTableCell(table, "REQUEST REJECTED", small, 1, 0);

            // REQUEST REJECTED value value cell
            this.addTableCell(table, otherApprovement.requestRejected.ToString(), small, 1, 0);

            // SIGNATURE cell
            this.addTableCell(table, "SIGNATURE", small, 1, 0);

            // SIGNATURE value cell
            this.addTableCell(table, otherApprovement.signatureApproval, small, 4, 0);

            // DATE cell
            this.addTableCell(table, "DATE", small, 1, 0);

            // DATEvalue value cell
            this.addTableCell(table, otherApprovement.date.ToString(), small, 1, 0);

            // POSITION cell
            this.addTableCell(table, "POSITION", small, 1, 0);

            // POSITION value cell
            this.addTableCell(table, otherApprovement.positionApproval, small, 4, 0);



            return table;
        }


        /***** add All approvement table   ****/
        private PdfPTable createAllApprovementTablePdf(PdfPTable table, IList<OtherApprovement> otherApprovements)
        {
            foreach (var otherApprovement in otherApprovements)
            {
                this.createDeviationOtherOneTablePdf(table, otherApprovement);
            }

            return table;
        }


        //to create the hole document
        public String createPdfDeviation(Deviation deviation, IList<OtherApprovement> otherApprovements, String filePath)
        {
            String fileSave = filePath + "/deviation" + deviation.deviationRef + "_" + DateTime.Now.Second.ToString() + ".pdf";
            this.getPdfWriter(fileSave);

            //crate deviation page header
            PdfPTable table = this.generatePageHead();

            //create deviation page content
            this.createDeviationContent(table,deviation);

            //Add approvement Group part to the document
            this.createApprovementPdf(table, deviation);


            //Add Approvement table 
            this.createAllApprovementTablePdf(table, otherApprovements);

            // close the document and save it
            doc.Add(table);
            doc.Close();

            return fileSave;

        }


    }


}
