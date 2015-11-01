using Microsoft.AspNet.Identity.EntityFramework;
using ProjectPlannerASP5.Entities;
using System.Collections.Generic;

namespace ProjectPlannerASP5.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<ProjectUser> Projects{ get; set; }
    }
}