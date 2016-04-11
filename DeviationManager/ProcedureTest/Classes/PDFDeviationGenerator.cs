using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcedureTest.Classes
{
    public class PDFDeviationGenerator
    {
        private Document doc;
        private Font normal ;

        public PDFDeviationGenerator(int x1,int x2,int x3,int x4)
        {
            doc = new Document(PageSize.A4, x1, x2, x3, x4);
            normal = FontFactory.GetFont("Arial", 7, BaseColor.BLACK);
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
            cell.BackgroundColor=cellBackColor;
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
            this.addTableCell(table, "Usage of Document:", normal, 1,0);

            //FTDS -BM-P-008 Deviation Control Procedure cell
            this.addTableCell(table, "FTDS -BM-P-008 Deviation Control Procedure Documentation and Approval of Deviations which are departures from standard procedures, product specifications or process controls.", normal, 3,0);


            //scope of document  cell
            this.addTableCell(table, "Scope of Document:", normal, 1,0);

            //TI FTDS Division  cell
            this.addTableCell(table, "TI FTDS Division", normal, 2,0);


            
            return table;

        }


        public PdfPTable createDeviationContent(PdfPTable table)
        {
            //Deviation No cell
            this.addTableCell(table, "DEVIATION NO:", normal, 1, 0);

            //Deviation No Value cell
            this.addTableCell(table, "DR-", normal, 2, 0);

            // Risk Category cell
            this.addTableCell(table, "RISK CATEGORY:", normal, 2, 0);

            // Risk Category Value cell
            this.addTableCell(table, "................", normal, 2, 0);

            // Requested by cell
            this.addTableCell(table, "REQUESTED BY:", normal, 1, 0);

            // Requested by value cell
            this.addTableCell(table, "............", normal, 3, 0);

            // DATE cell
            this.addTableCell(table, "DATE:", normal, 1, 0);

            // DATE value cell
            this.addTableCell(table, "...........", normal, 2, 0);

            // Signature cell
            this.addTableCell(table, "SIGNATURE:", normal, 1, 0);

            //Signature value cell
            this.addTableCell(table, "............", normal, 3, 0);

            // position cell
            this.addTableCell(table, "POSITION:", normal, 1, 0);

            // position value cell
            this.addTableCell(table, "...........", normal, 2, 0);

            // deviation type cell
            this.addTableCell(table, "DEVIATION TYPE:", normal, 2, 0);

            // deviation type value cell
            this.addTableCell(table, ".............", normal, 1, 0);

            // Other Description value cell
            this.addTableCell(table, "Other :................................", normal, 7, 0);

            // Detail description of deviation cell
            this.addTableCell(table, "DETAILED DESCRIPTION OF DEVIATION (detail product name / procedure number / specification / etc)", normal, 7, 0);

            // Standard condition cell
            this.addTableCell(table, "Standard Condition", normal, 3, 1, "#0095ff");

            // detail requested condition cell
            this.addTableCell(table, "Detail Requested Condition", normal, 4, 1, "#0095ff");

            // Standard condition  value cell
            this.addTableCell(table, ".................\n .....................\n .....................\n .....................\n .....................", normal, 3, 0);

            // detail requested condition value  cell
            this.addTableCell(table, ".................\n .....................\n .....................\n ..................... \n .....................", normal, 4, 0);

            // 5 why cell
            this.addTableCell(table, "DETAIL 5 WHY TO SHOW REASON CHANGE FOR DEVIATION:", normal, 7, 0, "#0095ff");

            // why 1 cell
            this.addTableCell(table, "WHY:", normal, 7, 0);

            // why 2 cell
            this.addTableCell(table, "WHY:", normal, 7, 0);

            // why 3 cell
            this.addTableCell(table, "WHY:", normal, 7, 0);

            // why 4 cell
            this.addTableCell(table, "WHY:", normal, 7, 0);

            // why 5 cell
            this.addTableCell(table, "WHY:", normal, 7, 0);

            // Period deviation cell
            this.addTableCell(table, "PERIOD FOR DEVIATION /or PERMANENT(shift / week / etc)", normal, 3, 0, "#0095ff");

            // Period deviation value  cell
            this.addTableCell(table, "", normal, 4, 0);


            return table;
        }


        //to create the hole document
        public void createPdfDeviation(){

            this.getPdfWriter("deviatiomdocument.pdf");
            
            //crate deviation page header
            PdfPTable table = this.generatePageHead();

            //create deviation page content
            this.createDeviationContent(table);

            // close the document and save it
            doc.Add(table);
            doc.Close();


        }


    }
}
