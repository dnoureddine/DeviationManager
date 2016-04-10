
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

namespace ProcedureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string test = "Noureddine dah";
            Regex r = new Regex(@"^[a-zA-Z\s,]*$");
            if (r.IsMatch(test))
            {
                Console.WriteLine("true");
            }

            Console.Read();
        }
    }
}
