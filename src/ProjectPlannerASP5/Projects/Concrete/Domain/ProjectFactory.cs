using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Application;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlannerASP5.Projects.Abstract.Domain.Exceptions;

namespace ProjectPlannerASP5.Projects.Concrete.Domain
{
    [DomainFactory]
    public class ProjectFactory
    {
        private readonly ISystemUser _user;
        private readonly IProjectRepository _projectRepository;
        private readonly InjectorHelper _injectorHelper;

        public ProjectFactory(ISystemUser user, IProjectRepository projectRepository,
            InjectorHelper injectorHelper)
        {
            _user = user;
            _projectRepository = projectRepository;
            _injectorHelper = injectorHelper;
        }

        public Project CreateProject(string code, string name)
        {
            CheckIfProjectExists(code);

            var project = new Project(_user.UserId, code, name); 
            _injectorHelper.InjectDependencies(project);

            project.AddUser(_user.UserId);

            return project;
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
