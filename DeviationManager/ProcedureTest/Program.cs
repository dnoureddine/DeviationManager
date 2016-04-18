
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
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now.AddDays(-1);

            TimeSpan t = (TimeSpan)(d1 - d2);

            int minutes = (int)t.TotalMinutes;

            int days = minutes / (24 * 60);
            int hours = (minutes - (days * 24 * 60)) / 60;
            int minutesnb = minutes - (days * 24 * 60) - (hours * 60);

            Console.Write("days :"+days +" hours :"+hours+" minutes: "+minutesnb);

            Console.Read();
        }
    }
}
