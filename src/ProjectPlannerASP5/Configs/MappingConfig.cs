using AutoMapper;
using ProjectPlannerASP5.Entites;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Configs
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Issue, EditIssueViewModel>();
                config.CreateMap<EditIssueViewModel, Issue>();

                config.CreateMap<Issue, IssueView>()
                    //.ForMember(dest => dest.IssueFullNumber, opt => opt.MapFrom(src => src.Project.Code + " - " + src.IssueNumber))
                    .ForMember(dest => dest.IssueFullNumber, opt => opt.Ignore())
                    .ForMember(dest => dest.Reporter, opt => opt.Ignore());
                config.CreateMap<Project, ProjectView>();
            });
        }
    }
}
