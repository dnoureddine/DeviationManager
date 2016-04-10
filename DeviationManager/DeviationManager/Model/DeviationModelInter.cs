using DeviationManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviationManager.Model
{
    public interface DeviationModelInter
    {
         Deviation addDeviation(Deviation deviation);
         IList<Deviation> listDeviations();
         Deviation getDeviation(int deviationId);
         void deleteDeviation(int deviationId);
         void updateDeviation(Deviation deviation);
         void closeDeviation(Deviation deviation);
         void extendDeviation(Deviation deviation);
         void setIsPrintedDeviation(Deviation deviation);
         void rejectDeviation(Deviation deviation);
         String getUserNameFromActiveDirectory();


         ApprovementGroup addApprovementGroup(ApprovementGroup approvementGroupe);
         ApprovementGroup getApprovementGroup(int id);
         IList<ApprovementGroup> listApprovementGroup();
         void deleteApprovementGroup(int id);
    }
}
