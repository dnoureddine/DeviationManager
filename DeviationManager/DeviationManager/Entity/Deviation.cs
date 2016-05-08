using DeviationManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DeviationManager.Entity
{
    public class Deviation
    {

        [Browsable(false)]
        public virtual int deviationId { get; protected set; }

        [DisplayName("Ref")]
        public virtual String deviationRef { get; set; }
        [Browsable(false)]
        public virtual String deviationRiskCategory { get; set; }
        [DisplayName("Requested By")]
        public virtual String requestedBy { get; set; }
        [DisplayName("Created In")]
        public virtual DateTime? dateCreation { get; set; }
        [Browsable(false)]
        public virtual String signature { get; set; }
        [Browsable(false)]
        public virtual String position { get; set; }
        [Browsable(false)]
        public virtual String deviationType { get; set; }
        [Browsable(false)]
        public virtual String describeOtherType { get; set; }
        [Browsable(false)]
        public virtual String detailRequestCondition { get; set; }
        [DisplayName("Begin Period")]
        public virtual DateTime? startDatePeriod { get; set; }
        [DisplayName("End Period")]
        public virtual DateTime? endDatePeriod { get; set; }
        [DisplayName("Status")]
        public virtual String status { get; set; }
        [Browsable(false)]
        public virtual Boolean isPrinted { get; set; }
        [DisplayName("Closed In")]
        public virtual DateTime? dateClosed { get; set; }
        [DisplayName("Product")]
        public virtual String product { get; set; }
        [DisplayName("Machine")]
        public virtual String anlage { get; set; }
         [DisplayName("Reasons")]
        public virtual String detailStandardCondition { get; set; }

        [Browsable(false)]
        public virtual IList<Reason> reasons { get;  set; }
        [Browsable(false)]
        public virtual IList<Approvement> approvements { get;  set; }
        [Browsable(false)]
        public virtual IList<Attachments> attachements { get; set; }



        public virtual String Approved
        {
            get
            {
                String isApproved = "Pending";
                bool isRejected = false;
                foreach (var approvement in approvements)
                {
                    if (approvement.rejected == true)
                    {
                        isRejected = true;
                        break;
                    }
                }


                if (isRejected)
                {
                    isApproved = "Rejected";
                }
                else 
                {
                    bool approved = true;
                    foreach (var approvement in approvements)
                    {
                        if (approvement.approved == false)
                        {
                            approved = false;
                            break;
                        }
                    }

                    if (approved)
                    {
                        isApproved = "Approved";
                    }
                    else if (this.status == "closed")
                    {
                        isApproved = "Closed";
                    }
                }


                return isApproved;
            }
        }
        public Deviation()
        {
            reasons= new List<Reason>();
            approvements = new List<Approvement>();
            attachements = new List<Attachments>();

        }
    }
}
