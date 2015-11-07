namespace ProjectPlanner.Cqrs.Base.DDD.Domain
{
    public abstract class Entity
    {
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
