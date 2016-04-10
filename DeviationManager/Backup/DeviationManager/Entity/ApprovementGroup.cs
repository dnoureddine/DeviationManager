using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviationManager.Entity
{
    public class ApprovementGroup
    {
        public virtual int approvalId { get; protected set; }
        public virtual String liblle { get; set; }
        public virtual String role { get; set; }
    }
}
