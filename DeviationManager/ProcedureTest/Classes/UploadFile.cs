using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace ProcedureTest.Classes
{
    public class UploadFile
    {
        FtpWebResponse response;


        //host attribut example =ftp://ftp.deviationmanager.esy.es/test
        public string  UploadFielToFtp(String host, String pwd, String userName, String filePath)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(host));
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(userName,pwd);


                // Copy the contents of the file to the request stream.
                StreamReader sourceStream = new StreamReader(filePath);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                //show Progress
                Console.WriteLine("-----------Begin progress---------------");

                //Begin Streaming
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                return "uploaded";
            } 
           catch (WebException webex)
           {
               if ((response != null) && (response.StatusCode == FtpStatusCode.ActionNotTakenFilenameNotAllowed)) {
                   //MessageBox.Show("You Are Not Allowed To Make Any Change On This Item Because Its Already Closed !", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);

               }

               return webex.Message;
           }


        }





    }
}
