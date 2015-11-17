﻿using System.Linq;
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
                .Select(n => new ProjectListDto(n.Id, n.Code, n.Status, 0, n.CreateDate));
        }
    }
}
