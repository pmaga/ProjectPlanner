using NHibernate;

namespace ProjectPlannerASP5.Base.Infrastructure.Orm
{
    public interface IPerRequestSessionFactory
    {
        ISession CreateSession();
    }
}