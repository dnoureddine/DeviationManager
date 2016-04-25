using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ProcedureTest.Classes
{
    public class EmailSender
    {

        public void sendEmail()
        {
            string To = "dnoureddin@tiauto.com";
            string From = "dnoureddin@tiauto.com";
            string Subject = "The Email Attachment Extract Process is Complete.";
            string Body = "The Email Attachment Extract Process is Complete. Please finish the Import process.";

            // create the email message
            MailMessage completeMessage = new MailMessage(From, To, Subject, Body);

            // create smtp client at mail server location
            SmtpClient client = new SmtpClient("smtp.extranet.tiauto.com");

       

            // add credentials
            client.UseDefaultCredentials = true;

            try
            {
                // send message
                client.Send(completeMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void getGroupMembers()
        {
            // ExpandGroupResults test;
        }




    }
}
