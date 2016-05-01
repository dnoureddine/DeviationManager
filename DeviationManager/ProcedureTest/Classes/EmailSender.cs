using System;
using System.Collections.Generic;
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

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            message.To.Add("dnoureddin@de.tiauto.com");
            message.From = new System.Net.Mail.MailAddress("dnoureddin@de.tiauto.com");

            message.Subject = "This is the Subject line";
            message.Body = "This is the message body";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.extranet.tiauto.com");
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("dnoureddin", "DevKom#01");

            smtp.Send(message);
            Console.WriteLine("Done");

        }

        public void sendEmailSmtp()
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Hello World");
        }


    }
}
