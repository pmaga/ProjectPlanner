 namespace ProjectPlanner.Cqrs.Base.Infrastructure.Attributes
{
    public enum ComponentLifestyle
    {
        Singleton,
        Transient,
        PerRequest,
        PerSession
    }
}
