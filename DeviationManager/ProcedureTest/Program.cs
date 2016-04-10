
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using System.Security;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Text.RegularExpressions;
using ProcedureTest.Classes;

namespace ProcedureTest
{
    class Program
    {
        static void Main(string[] args)
        {


            PDFGenerator pdfDoc = new PDFGenerator(10,10,40,40);
            pdfDoc.createPdfDeviation();

            Console.Read();
        }
    }
}
