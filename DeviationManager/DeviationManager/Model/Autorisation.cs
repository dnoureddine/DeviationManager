using DeviationManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DeviationManager.Model
{
    public class Autorisation
    {

        private DeviationModel deviationModel;

        public Autorisation()
        {
            deviationModel = new DeviationModel();
        }


        //the USER cann update the Deviation if he WROTE IT: output: null if must not, Deviation object if is allowed
        public Deviation canUpdateDeviation(String deviationRef)
        {
            Deviation deviation = deviationModel.getDeviationWithRef(deviationRef);
            if (deviation.signature == deviationModel.getUserNameFromActiveDirectory())
            {
                return deviation;
            }
            else
            {
                return null;
            }
        }

        /******** make sure if the current user can create deviation ***/
        public bool canCreateDeviation(User user)
        {
            var approvementGroups = deviationModel.listApprovementGroup();
            bool canCreateDeviation = false;

            foreach (var approvementGroup in approvementGroups)
            {
                if (approvementGroup.role == user.role)
                {
                    canCreateDeviation = true;
                    break;
                }
            }

            return canCreateDeviation;
        }


        /***** make sure if the user is allowed to approve ****/
        public String cannApprove(int approvementId)
        {
            String toAmpprove = "canApprove";

            Approvement approvement = deviationModel.getApprovement(approvementId);
            bool isAutorized = this.isAutorized(approvement.approvementGroup.role);

            if (approvement.deviation.status=="closed")
            {
                toAmpprove = "Deviation Was Already Closed";
            }
            if (approvement.approved || approvement.rejected)
            {
                if (toAmpprove == "canApprove")
                {
                    toAmpprove = " This Approvement Was Already Done, You Can Not Change IT !";
                }
                else
                {
                    toAmpprove = toAmpprove + ", This Approvement Was Already Done, You Can Not Change IT !";
                }
            }

            //if the user is not autorized to approve
            if (!isAutorized)
            {
                toAmpprove = " Sorry, You Are Not Autorrized To Approve!.";
            }
           
            return toAmpprove;
        }

        //make sure that the user has the role
        public bool isAutorized(String roles)
        {
            bool isAutorized = false;
            string[] tab = roles.Split(';');
            foreach (var role in tab)
            {
                try
                {
                    bool UserIsInGroup = new System.Security.Principal.WindowsPrincipal(new System.Security.Principal.WindowsIdentity(Environment.UserName)).IsInRole(role);
                    if (UserIsInGroup)
                    {
                        isAutorized = true;
                        break;
                    }

                }
                catch (System.Exception ex)
                {

                }

            }

            return isAutorized;
        }

        /**____ class   ****/
    }
}
