using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;

namespace ProjectPlanner.Tests.Helpers
{
    public class TestInjectorHelper : InjectorHelper
    {
        public TestInjectorHelper() : base(new EmptyEventPublisher())
        {
        }
    }
}