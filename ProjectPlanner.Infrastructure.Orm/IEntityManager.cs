using NHibernate;

namespace ProjectPlanner.Infrastructure.Orm
{
    public interface IEntityManager
    {
        ISession CurrentSession { get; }
    }
}