using System;

namespace ProjectPlanner.Projects.Domain
{
    public interface IProjectRepository
    {
        Project FindByCode(string code, Guid userId);

        void Save(Project project);
        void Delete(int entityId);
        Project Load(int projectId);
    }
}
