using NHibernate;

namespace ProjectPlanner.Infrastructure.Orm
{
    public interface IPerRequestSessionFactory
    {
        ISession CreateSession();
    }
}