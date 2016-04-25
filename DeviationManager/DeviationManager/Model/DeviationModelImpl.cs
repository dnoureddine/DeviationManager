using DeviationManager.Entity;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviationManager.Model
{
    public class DeviationModel : DeviationModelInter
    {

        /****************** add Derivation ******************************/

        public Deviation addDeviation(Deviation deviation)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(deviation);
                    transaction.Commit();
                }
            }

            return deviation;
        }

        /************************* List all Derivation **********************************/
        public IList<Deviation> listDeviations()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviations = session.CreateCriteria(typeof(Deviation)).List<Deviation>();
                    return deviations;
                }
            }
        }


        /************* Get Deviation using Deviation Ref  ****/
        public Deviation getDeviationWithRef(String deviationRef)
        {
            try
            {
                var session = NHibernateHelper.OpenSession();
                var transaction = session.BeginTransaction();

                var deviation = session.CreateCriteria(typeof(Deviation))
                    .Add(Restrictions.Eq("deviationRef", deviationRef))
                    .UniqueResult<Deviation>();

                return deviation;
            }
            catch(Exception ex){
                return null;
            }
               
                   
        }

        /*********************** Get a Deviation *****************************/
        public Deviation getDeviation(int deviationId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviation = session.Get<Deviation>(deviationId);
                    return deviation;
                }
            }

        }

        /****************** Delete Deviation ****************/
        public void deleteDeviation(int deviationId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviation = this.getDeviation(deviationId);
                    if (deviation != null)
                    {
                        session.Delete(deviation);
                        transaction.Commit();
                    }
               
                }
            }

        }



        /****************** update Deviation ****************/
        public void updateDeviation(Deviation deviation)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Merge(deviation);
                    transaction.Commit();
                }
            }

        }


        /****************** close Deviation ****************/
        public String closeDeviation(String deviationRef)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Deviation deviation = this.getDeviationWithRef(deviationRef);
                    if (deviation != null)
                    {
                        deviation.status = "closed";
                        deviation.dateClosed = DateTime.Now;
                        session.Merge(deviation);
                        transaction.Commit();
                        return "closed";
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /****************** extend Deviation ****************/
        public void extendDeviation(Deviation deviation)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    deviation.status = "extended";
                    session.Merge(deviation);
                    transaction.Commit();
                }
            }
        }


        /****************** If the Deviation is printed ****************/
        public void setIsPrintedDeviation(Deviation deviation)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    deviation.isPrinted=true;
                    session.Merge(deviation);
                    transaction.Commit();
                }
            }
        }



        /*****************  reject Deviation ************/
        public void rejectDeviation(Deviation deviation)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    deviation.status="rejected";
                    session.Merge(deviation);
                    transaction.Commit();
                }
            }
        }

        
        /******* add an approvement group  */

        public ApprovementGroup addApprovementGroup(ApprovementGroup approvementGroupe)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(approvementGroupe);
                    transaction.Commit();
                }
            }

            return approvementGroupe;
        }


        /***************** get an approvement group */
        public ApprovementGroup getApprovementGroup(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var approvementGroup = session.Get<ApprovementGroup>(id);
                    return approvementGroup;
                }
            }
        }


        /************* get list approvement group  *************/
        public IList<ApprovementGroup> listApprovementGroup()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var approvementGroups = session.CreateCriteria(typeof(ApprovementGroup)).List<ApprovementGroup>();
                    return approvementGroups;
                }
            }
        }


        /**** delete approvement group   ***/
        public void deleteApprovementGroup(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var approvementGroup = this.getApprovementGroup(id);
                    if (approvementGroup != null)
                    {
                        session.Delete(approvementGroup);
                        transaction.Commit();
                    }

                }
            }
        }


        /************* get Deviation nombe *********/
        public string getDeviationNumber()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Deviation deviation=null;
                    string year = DateTime.Now.Year.ToString() ;
                    var deviations = session.CreateCriteria(typeof(Deviation)).List<Deviation>();
                    if (deviations.Count != 0)
                    {
                        deviation = session.CreateCriteria(typeof(Deviation)).List<Deviation>().Last();
                    }

                    if (deviation == null)
                    {
                        return year + "-01";
                      
                    }
                    else
                    {
                        int index = deviation.deviationId + 1;

                        if (deviation.deviationId < 9)
                        { 
                            return year + "-0" + index;
                        }
                        else
                        {
                            return year + "-" + index;
                        } 
                    }
                }
            }

           
        }


        /****** search Deviation by devationRef */
        public IList<Deviation> filterDeviationByRef(String refDev){

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviations = session.CreateCriteria(typeof(Deviation))
                     .Add(Restrictions.Like("deviationRef", refDev, MatchMode.Anywhere))
                     .List<Deviation>();

                    return deviations;
                }
            }

        }

        /****** search Deviation by Requested by */
        public IList<Deviation> filterDeviationByRequestedBy(String requestedBy)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviations = session.CreateCriteria(typeof(Deviation))
                     .Add(Restrictions.Like("requestedBy", requestedBy, MatchMode.Anywhere))
                     .List<Deviation>();

                    return deviations;
                }
            }

        }

        /****** search Deviation by Requested Rick category */
        public IList<Deviation> filterDeviationByRiskCategory(String riskCategory)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviations = session.CreateCriteria(typeof(Deviation))
                     .Add(Restrictions.Eq("deviationRiskCategory", riskCategory))
                     .List<Deviation>();

                    return deviations;
                }
            }

        }

        /****** search Deviation by Deviation type */
        public IList<Deviation> filterDeviationByDeviationType(String deviationType)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var deviations = session.CreateCriteria(typeof(Deviation))
                     .Add(Restrictions.Eq("deviationType", deviationType))
                     .List<Deviation>();

                    return deviations;
                }
            }

        }

        /****** search Deviation using all properties*/
        public IList<Deviation> filterDeviationByAll(String deviationRef, String requestedBy, String deviationRiskCategory, String deviationType)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var creteria  = session.CreateCriteria(typeof(Deviation));
                    if (deviationRef != "")
                    {
                        creteria.Add(Restrictions.Eq("deviationRef", deviationRef));
                    }
                    if (requestedBy != "")
                    {
                        creteria.Add(Restrictions.Eq("requestedBy", requestedBy));
                    }
                    if (deviationRiskCategory != "")
                    {
                        creteria.Add(Restrictions.Eq("deviationRiskCategory", deviationRiskCategory));
                    }
                    if (deviationType != "")
                    {
                        creteria.Add(Restrictions.Eq("deviationType", deviationType));
                    }


                    var deviations= creteria.List<Deviation>();

                    return deviations;
                }
            }

        }

        /*********************** Get an Approvement *****************************/
        public Approvement getApprovement(int approvementID)
        {
            try
            {
                var session = NHibernateHelper.OpenSession();
                var transaction = session.BeginTransaction();

                var approvement = session.Get<Approvement>(approvementID);
                return approvement;
            }
            catch (Exception ex)
            {
                return null;
            }
               
            
        }


        /****** update Approvement  ****/
        public void updateApprovement(Approvement approvement)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Merge(approvement);
                    transaction.Commit();
                }
            }

        }

        //***************
        /************************* List all Derivation **********************************/
        public ApprovementGroup getApprovementGroup(Approvement approvement)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var approvementLazy = session.Get<Approvement>(approvement.approvementId);
                    return approvement.approvementGroup;
                }
            }
        }

        //delete attachemnt
        public bool deleteAttachment(String fileNameDB)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var attachment = session.CreateCriteria(typeof(Attachments))
                        .Add(Restrictions.Eq("fileNameDb", fileNameDB))
                        .UniqueResult<Attachments>();

                    if (attachment != null)
                    {
                        session.Delete(attachment);
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /*****   get user name from ative directory for signature *****/
        public String getUserNameFromActiveDirectory()
        {
            String name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return name;
        }


        //verify if the deviation is closed
        public bool isDeviationClosed(Deviation deviation)
        {
            if (deviation.status == "closed")
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        /******____class   */

    }
}
