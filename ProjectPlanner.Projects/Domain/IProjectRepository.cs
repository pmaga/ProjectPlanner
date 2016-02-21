using System;

namespace ProjectPlanner.Projects.Domain
{
    public interface IProjectRepository
    {
        Project FindByCode(string code, Guid userId);

        void Save(Project project);
        Project Load(int projectId);
    }
}
