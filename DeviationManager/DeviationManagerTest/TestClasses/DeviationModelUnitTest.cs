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

            var deviation = model.listDeviations();

            Assert.IsTrue(deviation.Count>0);

        }


        [TestMethod]
        public void TestAddApprovementGroup()
        {
            DeviationModel model = new DeviationModel();

            ApprovementGroup approvementGroup1 = new ApprovementGroup { liblle = "Operations Mgr", role = "Operations Mgr" };
            ApprovementGroup approvementGroup2 = new ApprovementGroup { liblle = "Engineering Mgr", role = "Engineering Mgr" };

            model.addApprovementGroup(approvementGroup1);
            model.addApprovementGroup(approvementGroup2);

            var approvementGroups = model.listApprovementGroup();
            Assert.IsTrue(approvementGroups.Count>0);
        }
    }
}
