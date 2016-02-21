using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;

namespace ProjectPlanner.Infrastructure.Orm.Conventions
{
    public class NoLazyLoadReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.LazyLoad(Laziness.NoProxy);
        }
    }
}
