using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;

namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    [DomainEntity]
    public abstract class Entity
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public int Id { get; private set; }
        public EntityStatus EntityStatus { get; private set; }

        protected Entity()
        {
            EntityStatus = EntityStatus.Active;
        }

        public void MarkAsArchived()
        {
            EntityStatus = EntityStatus.Archived;
        }
    }
}
