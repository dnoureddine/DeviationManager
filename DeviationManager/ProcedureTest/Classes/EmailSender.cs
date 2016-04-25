using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace ProcedureTest.Classes
{
    public class EmailSender
    {

        public int sendEmail()
        {
            try{

                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "eu.tiauto.com");

                GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "*ETT DR-Approval");
                if (group != null)
                {
                    PrincipalSearchResult<Principal> members = group.GetMembers();

                    return members.Count();
                }
                else
                {
                    Console.WriteLine("Group mot fund");
                    return 0;
                }

                
            }
            catch(DirectoryServicesCOMException dex){
               Console.WriteLine(dex.Message);
               return 0;
            }
            
        }


        public void getGroupMembers()
        {
            // ExpandGroupResults test;
        }




    }
}
