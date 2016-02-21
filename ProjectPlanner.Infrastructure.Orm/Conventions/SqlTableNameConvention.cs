using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ProjectPlanner.Infrastructure.Orm.Conventions
{
    public class SqlTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "s");
        }
    }
}
