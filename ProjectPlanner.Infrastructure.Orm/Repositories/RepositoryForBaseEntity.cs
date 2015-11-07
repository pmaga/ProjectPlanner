using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Infrastructure.Orm.Repositories
{
    public class RepositoryForBaseEntity<TEntity> : Repository<TEntity, int>
        where TEntity : Entity
    {
        public override void Delete(int id)
        {
            TEntity entity = Load(id);
            entity.MarkAsArchived();
        }
    }
}
