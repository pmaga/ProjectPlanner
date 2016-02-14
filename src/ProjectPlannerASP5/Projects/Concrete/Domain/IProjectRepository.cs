using System;

namespace ProjectPlannerASP5.Projects.Concrete.Domain
{
    public interface IProjectRepository
    {
        Project FindByCode(string code, Guid userId);

        void Save(Project project);
        Project Load(int projectId);
    }
}
