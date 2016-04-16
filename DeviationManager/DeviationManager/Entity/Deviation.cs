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
        public virtual String deviationRef { get; set; }
        [Browsable(false)]
        public virtual String deviationRiskCategory { get; set; }
        public virtual String requestedBy { get; set; }
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
        public virtual String detailStandardCondition { get; set; }
        [Browsable(false)]
        public virtual String detailRequestCondition { get; set; }
        public virtual DateTime? startDatePeriod { get; set; }
        public virtual DateTime? endDatePeriod { get; set; }
        public virtual DateTime? dateClosed { get; set; }
        [Browsable(false)]
        public virtual String status { get; set; }
        [Browsable(false)]
        public virtual Boolean isPrinted { get; set; }
       

        public virtual IList<Reason> reasons { get;  set; }
        public virtual IList<Approvement> approvements { get;  set; }
        public virtual IList<Attachments> attachements { get; set; }

        public Deviation()
        {
            reasons= new List<Reason>();
            approvements = new List<Approvement>();
            attachements = new List<Attachments>();
        }
    }
}
