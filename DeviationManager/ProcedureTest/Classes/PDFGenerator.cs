using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedureTest.Classes
{
    public class PDFGenerator
    {
        private Document doc;

        public PDFGenerator(int x1,int x2,int x3,int x4)
        {
            doc = new Document(PageSize.LETTER, x1, x2, x3, x4);
        }


        // get Pdf Writer to be able to write in the document 
        public PdfWriter getPdfWriter(String filePath)
        {
            PdfWriter pdfWriter = PdfWriter.GetInstance(this.doc, new System.IO.FileStream(filePath, System.IO.FileMode.Append));
            this.doc.Open();

            return pdfWriter;
        }

        // using the pdf writer generate the page header
        public void generatePageHead()
        {
            PdfPTable table = new PdfPTable(4);
           
            Paragraph par1 = new Paragraph("Hello Noureddine !!! you are teh best !!");

            PdfPCell logo = new PdfPCell(new Phrase("Ici le Logo!!"));
            logo.Padding = 4;
            logo.HorizontalAlignment = 1;
            table.AddCell(logo);

            PdfPCell title = new PdfPCell(new Phrase("TI FTDS Quality Management System"));
            title.Colspan = 3;
            title.Padding = 4;
            title.HorizontalAlignment = 1;
            table.AddCell(title);


            
            //doc.Add(par1);
            doc.Add(table);
        }


        //to create the hole document
        public void createPdfDeviation(){

            this.getPdfWriter("deviatiomdocument.pdf");

            this.generatePageHead();


            // close the document and save it
            doc.Close();


        }


    }
}
