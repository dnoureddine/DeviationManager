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

        /******** make sure if the current user can create deviation ***/
        public bool canCreateDeviation(User user)
        {
            DeviationModel model = new DeviationModel();
            var approvementGroups = model.listApprovementGroup();
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
