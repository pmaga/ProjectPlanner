using System;
using Microsoft.AspNet.Http;
using System.Security.Claims;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Application;

namespace ProjectPlannerASP5.Application
{
    public class SystemUser : ISystemUser
    {
        public Guid UserId { get; } = Guid.Empty;

        public SystemUser(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = httpContextAccessor.HttpContext.User.GetUserId();
            if (currentUserId != null)
            {
                UserId = new Guid(currentUserId);
            }
        }
    }
}
