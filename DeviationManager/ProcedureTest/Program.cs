
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using System.Security;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Text.RegularExpressions;
using ProcedureTest.Classes;
using System.IO;

namespace ProcedureTest
{
    class Program
    {
        static void Main(string[] args)
        {


            /*
            PDFDeviationGenerator pdfDoc = new PDFDeviationGenerator(25,25,45,45);
            pdfDoc.createPdfDeviation();*/

            EmailSender email = new EmailSender();
            email.sendEmail();

            Console.Read();
        }
    }
}
