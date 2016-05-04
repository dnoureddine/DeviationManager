using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ProcedureTest.Classes
{
    public class EmailSender
    {

 


        public void getGroupMembers()
        {
            // ExpandGroupResults test;
        }

        public String sendEmail(String subject, String body, String To)
        {
            try
            {
                //if Outlook is not open start it and wait
                Process[] pName = Process.GetProcessesByName("OUTLOOK");
                if (pName.Length == 0)
                {
                    // Open Outlook anew.
                    System.Diagnostics.Process.Start("OUTLOOK.EXE");
                    System.Threading.Thread.Sleep(2000);
                }

                //****
                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //The email receiver
                mailItem.To = To;

                mailItem.Subject = subject;
                mailItem.Body = body;

                mailItem.Send();

                return "sent";
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.ErrorCode == -2147417846)
                {
                    return "This Programm Use Outlock Service To Send Your Email, You Need To Execute Outlock First Than Send Your Email.";
                }
                else
                {
                    return "Error, Email was Not sent";
                }
            }


        }


        public void sendEamilUsingSmptp(){

            try
            {

                SmtpClient client = new SmtpClient("smtp.extranet.tiauto.com");
                client.EnableSsl = true;
                client.Timeout = 100000;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Credentials = new NetworkCredential("deviationemailkomponent", "DevKom#01");
                MailMessage msg = new MailMessage();

                msg.To.Add("dnoureddin@tiauto.com");
                msg.From = new MailAddress("dnoureddin@tiauto.com");

                msg.Subject = "Test";
                msg.Body = "bla bla bla bla";

                client.Send(msg);

                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }



        public void sendEmailSmtpGmail()
        {

            try
            {

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Credentials = new NetworkCredential("dnoureddine11@gmail.com", "dahmane1989");
                MailMessage msg = new MailMessage();

                msg.To.Add("dnoureddine11@gmail.com");
                msg.From = new MailAddress("dnoureddine11@gmail.com");
                msg.Subject = "Test";
                msg.Body = "bla bla bla bla";

                client.Send(msg);

                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


    }
}
