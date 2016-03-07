using System;
using System.Linq;
using NHibernate.Linq;
using ProjectPlanner.Cqrs.Base.CQRS.Query.Attributes;
using ProjectPlanner.Infrastructure.Orm;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Presentation;

namespace ProjectPlanner.Projects.Presentation.Implementation
{
    [Finder]
    public class ProjectFinder : IProjectFinder
    {
        private readonly IEntityManager _entityManager;

        public ProjectFinder(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public IQueryable<ProjectListDto> FindProjects()
        {
            return _entityManager.CurrentSession.Query<Project>() //TODO: Pozbyc sie referencji do NHibernate?
                .Select(n => new ProjectListDto(n.Id, n.Code, n.Name, n.Status, 0, n.CreateTimeStamp));
        }

        public ProjectDetailsDto GetProjectDetails(int projectId)
        {
            var project = _entityManager.CurrentSession.Query<Project>()
                .SingleOrDefault(p => p.Id == projectId);
            
            return project == null ? null :
                new ProjectDetailsDto(project.Id, "Customer", project.Code,
                    project.Name, project.Description, 
                    project.CreateTimeStamp, project.LastUpdateTimeStamp,
                    40, project.Status);
        }

        public ProjectEditDto GetProject(int projectId)
        {
            var project = _entityManager.CurrentSession.Query<Project>()
                .SingleOrDefault(p => p.Id == projectId);

            return project == null ? null :
                new ProjectEditDto
                {
                    Id = project.Id,
                    Code = project.Code,
                    Name = project.Name,
                    Description = project.Description,
                    CreateTimeStamp = project.CreateTimeStamp,
                    LastUpdateTimeStamp = project.LastUpdateTimeStamp,
                    Status = project.Status
                };
        }
    }
}
