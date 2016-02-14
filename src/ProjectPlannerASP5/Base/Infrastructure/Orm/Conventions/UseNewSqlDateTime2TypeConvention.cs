using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ProjectPlannerASP5.Base.Infrastructure.Orm.Conventions
{
    public class UseNewSqlDateTime2TypeConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type == typeof (DateTime))
            {
                instance.CustomSqlType("datetime2");
            }
        }
    }
}
