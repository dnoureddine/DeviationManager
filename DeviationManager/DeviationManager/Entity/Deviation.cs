using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviationManager.Entity
{
    public class Deviation
    {
        public virtual int deviationId { get; protected set; }
        public virtual String deviationRef { get; set; }
        public virtual String deviationRiskCategory { get; set; }
        public virtual String requestedBy { get; set; }
        public virtual DateTime? dateCreation { get; set; }
        public virtual String signature { get; set; }
        public virtual String position { get; set; }
        public virtual String deviationType { get; set; }
        public virtual String describeOtherType { get; set; }
        public virtual String detailStandardCondition { get; set; }
        public virtual String detailRequestCondition { get; set; }
        public virtual DateTime? startDatePeriod { get; set; }
        public virtual DateTime? endDatePeriod { get; set; }
        public virtual String status { get; set; }
        public virtual Boolean isPrinted { get; set; }
       

        public virtual IList<Reason> reasons { get;  set; }
        public virtual IList<Approvement> approvements { get;  set; }

        public Deviation()
        {
            reasons= new List<Reason>();
            approvements = new List<Approvement>();
        }
    }
}
