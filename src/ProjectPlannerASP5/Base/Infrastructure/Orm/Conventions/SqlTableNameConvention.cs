using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ProjectPlannerASP5.Base.Infrastructure.Orm.Conventions
{
    public class SqlTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "s");
        }
    }
}
