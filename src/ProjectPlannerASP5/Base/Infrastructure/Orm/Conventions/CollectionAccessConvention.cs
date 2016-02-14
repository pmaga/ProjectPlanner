using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ProjectPlannerASP5.Base.Infrastructure.Orm.Conventions
{
    public class CollectionAccessConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            instance.Fetch.Select();
            instance.Cascade.All();
            instance.AsBag();
        }
    }
}
