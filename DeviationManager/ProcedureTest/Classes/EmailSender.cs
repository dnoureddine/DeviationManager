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

        public void sendEmail()
        {
            try{

                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "eu.tiauto.com");


                // define a "query-by-example" principal - here, we search for a GroupPrincipal 
                GroupPrincipal qbeGroup = new GroupPrincipal(ctx);

                // create your principal searcher passing in the QBE principal    
                PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);

                // find all matches
                int i = 0;
                foreach (var found in srch.FindAll())
                {
                    GroupPrincipal foundGroup = found as GroupPrincipal;


                    foreach (Principal p in foundGroup.GetMembers(true))
                    {
                        Console.WriteLine(p.Name);
                    }

                    i++;
                    if (i == 14)
                    {
                        break;
                    }
                }

                if (srch != null)
                {
                    Console.WriteLine("not nlll");
                }
                else
                {
                    Console.WriteLine("null");
                }
            }
            catch(DirectoryServicesCOMException dex){
               Console.WriteLine(dex.Message);
            }
            
        }






    }
}
