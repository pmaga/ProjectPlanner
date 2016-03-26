using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;

namespace ProjectPlanner.Infrastructure.Orm.Repositories
{
    public class RepositoryForBaseEntity<TEntity> : Repository<TEntity, int>
        where TEntity : Entity
    {
        public InjectorHelper InjectorHelper { get; set; }

        public RepositoryForBaseEntity(IEntityManager entityManager, InjectorHelper injectorHelper)
            : base(entityManager)
        {
            InjectorHelper = injectorHelper;
        }

        public override TEntity Load(int id)
        {
            TEntity entity = base.Load(id);
            InjectDependenciesIfAggregateRoot(entity);

            return entity;
        }

        private void InjectDependenciesIfAggregateRoot(TEntity entity)
        {
            if (entity is AggregateRoot)
            {
                InjectorHelper.InjectDependencies((AggregateRoot) (object) entity);
            }
        }

        public override void Delete(int id)
        {
            TEntity entity = Load(id);
            entity.MarkAsArchived();
            
        }
    }
}
