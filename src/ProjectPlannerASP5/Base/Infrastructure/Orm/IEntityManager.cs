using NHibernate;

namespace ProjectPlannerASP5.Base.Infrastructure.Orm
{
    public interface IEntityManager
    {
        ISession CurrentSession { get; }
    }
}