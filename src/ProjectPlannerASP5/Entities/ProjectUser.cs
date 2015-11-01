using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5.Entities
{
    public class ProjectUser
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string UserId { get; set; }
        public AppUser User{ get; set; }
    }
}
