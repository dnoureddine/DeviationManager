using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeviationManager;
using DeviationManager.Model;
using DeviationManager.Entity;
using System.Collections.Generic;

namespace DeviationManagerTest
{
    [TestClass]
    public class DeviationModelUnitTest
    {
        [TestMethod]
        public void TestAddDeviation()
        {

            DeviationModel model = new DeviationModel();


            Deviation dev = new Deviation();

            dev.deviationRef = "2016-01";
            dev.requestedBy = "Noureddine";

            Reason reason = new Reason();
            Reason reason2 = new Reason();

            reason.reason = "First test Reason!!!!!";
            reason2.reason = "Second test Reason";


            Approvement appr1 = new Approvement { name = "Noureddine Dahmane" };
            Approvement appr2 = new Approvement { name = "Ibrahim Dahmane" };


            IList<Approvement> list2 = new List<Approvement>();
            list2.Add(appr1);
            list2.Add(appr2);

            IList<Reason> list = new List<Reason>();
            list.Add(reason);
            list.Add(reason2);

            dev.requestedBy = "Noureddine Dahmane";
            dev.dateCreation = DateTime.Now;
            dev.reasons = list;
            dev.approvements = list2;

            model.addDeviation(dev);

            var deviation = model.listDeviations(1,3);

            Assert.IsTrue(deviation.Count>0);

        }


        [TestMethod]
        public void TestAddApprovementGroup()
        {
            DeviationModel model = new DeviationModel();

            ApprovementGroup approvementGroup1 = new ApprovementGroup { liblle = "Operations Mgr", role = "Operations Mgr" };
            ApprovementGroup approvementGroup2 = new ApprovementGroup { liblle = "Engineering Mgr", role = "Engineering Mgr" };
            ApprovementGroup approvementGroup3 = new ApprovementGroup { liblle = "Quality Engineer", role = "Quality Engineer" };
            ApprovementGroup approvementGroup4 = new ApprovementGroup { liblle = "General/Plant Manager", role = "General/Plant Manager" };
            ApprovementGroup approvementGroup5 = new ApprovementGroup { liblle = "Quality Manager", role = "Quality Manager" };

            model.addApprovementGroup(approvementGroup1);
            model.addApprovementGroup(approvementGroup2);
            model.addApprovementGroup(approvementGroup3);
            model.addApprovementGroup(approvementGroup4);
            model.addApprovementGroup(approvementGroup5);

            var approvementGroups = model.listApprovementGroup();
            Assert.IsTrue(approvementGroups.Count>0);
        }
    }
}
