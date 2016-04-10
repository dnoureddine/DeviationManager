﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DeviationManager.Entity;

namespace DeviationManager.Mappings
{
    public class DeviationMap : ClassMap<Deviation>
    {
        public DeviationMap()
        {
            Id(x => x.deviationId);
            Map(x => x.deviationRef);
            Map(x => x.deviationRiskCategory);
            Map(x => x.requestedBy);
            Map(x => x.dateCreation);
            Map(x => x.signature);
            Map(x => x.deviationType);
            Map(x => x.describeOtherType);
            Map(x => x.detailRequestCondition);
            Map(x => x.detailStandardCondition);
            Map(x => x.startDatePeriod);
            Map(x => x.endDatePeriod);
            Map(x => x.status);
            Map(x => x.isPrinted);


            HasMany(x => x.reasons).Not.LazyLoad()
                .Cascade.All();

            HasMany(x => x.approvements).Not.LazyLoad()
                .Cascade.All();
        }
    }
}