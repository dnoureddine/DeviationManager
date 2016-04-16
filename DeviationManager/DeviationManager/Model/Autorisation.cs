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
        public bool cannApprove(User user, ApprovementGroup approvementGroup)
        {
            /** 1: make sure if the current user can create deviation ***/
            bool canCreateDeviation = this.canCreateDeviation(user);

            /** 2: make sure that the user belong to the approvementGroup ***/
            bool userBelongToApprovementGroup = false;
            if (user.role == approvementGroup.role) userBelongToApprovementGroup = true;

            /** 3: If the approvement already set, make sure that it belong to the user in order to update it  */



            return canCreateDeviation || userBelongToApprovementGroup;
        }

        

        /**____ class   ****/
    }
}
