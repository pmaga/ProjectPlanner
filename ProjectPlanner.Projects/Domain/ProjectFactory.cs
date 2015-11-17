using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.Projects.Domain
{
    [DomainFactory]
    public class ProjectFactory
    {
        private readonly ISystemUser _user;
        private readonly IProjectRepository _projectRepository;

        public ProjectFactory(ISystemUser user, IProjectRepository projectRepository)
        {
            _user = user;
            _projectRepository = projectRepository;
        }

        public Project CreateProject(string code, string name)
        {
            CheckIfProjectExists(code);

            return new Project(_user.UserId, code, name); 
        }

        private void CheckIfProjectExists(string code)
        {
            if (_projectRepository.FindByCode(code, _user.UserId) != null)
            {
                throw new ProjectCreationException($"Cannot create new project, because project with code: {code} already exists!",
                    _user.UserId);
            }
        }
    }
}
