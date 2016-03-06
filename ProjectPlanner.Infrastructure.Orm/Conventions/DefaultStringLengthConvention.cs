using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace ProjectPlanner.Infrastructure.Orm.Conventions
{
    public class DefaultStringLengthConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(instance => instance.Type == typeof(string))
                .Expect(instance => instance.Length == 0);
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.Length(100);
        }
    }
}
