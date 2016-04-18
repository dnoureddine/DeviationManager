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
            if (approvement.deviation.status=="closed")
            {
                toAmpprove = "Deviation Was Already Closed";
            }
            if (approvement.signed)
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

           
            return toAmpprove;
        }

        

        /**____ class   ****/
    }
}
