using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcedureTest.Classes
{
    
    class ExcelDeviationGenerator
    {
        private Workbook workbook;

        public ExcelDeviationGenerator()
        {
            workbook = new Workbook();
        }


        //create page Header
        private Worksheet createPageHead()
        {
            Worksheet worksheet = new Worksheet("First Sheet");

            worksheet.Cells[0, 0] = new Cell("Bonjour Noureddine this ia your day you know that ???");
            worksheet.Cells[0, 3] = new Cell("Bonjour Noureddine this ia your day you know that ???");

            worksheet.Cells.ColumnWidth[0,1] = 600;
            worksheet.Cells.GetRow(1).Height = 300;

            return worksheet;
        }


        //create the hole excel page
        public void createExcelDeviationPage(String filePath)
        {
            //create page Header
            Worksheet worksheet = this.createPageHead();



            //save excel file 
            this.workbook.Worksheets.Add(worksheet);
            this.workbook.Save(filePath);
        }


    }
}
