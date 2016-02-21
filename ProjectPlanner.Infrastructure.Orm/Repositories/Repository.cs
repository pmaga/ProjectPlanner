namespace ProjectPlanner.Infrastructure.Orm.Repositories
{
    public class Repository<TEntity, TKey> where TEntity : class
    {
        public IEntityManager EntityManager { get; set; }

        public Repository(IEntityManager entityManager)
        {
            EntityManager = entityManager;
        }

        public virtual TEntity Load(TKey id)
        {
            return EntityManager.CurrentSession.Get<TEntity>(id);
        }

        public virtual void Delete(TKey id)
        {
            EntityManager.CurrentSession.Delete(Load(id));
        }

        public virtual void Save(TEntity entity)
        {
            EntityManager.CurrentSession.SaveOrUpdate(entity);
        }
    }
}
