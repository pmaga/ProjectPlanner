﻿using AutoMapper;
using ProjectPlannerASP5.Entities;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.ViewModels;

namespace ProjectPlannerASP5.Configs
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Issue, EditIssueViewModel>().ReverseMap();

                config.CreateMap<Issue, IssueView>()
                    //.ForMember(dest => dest.IssueFullNumber, opt => opt.MapFrom(src => src.Project.Code + " - " + src.IssueNumber))
                    .ForMember(dest => dest.IssueFullNumber, opt => opt.Ignore())
                    .ForMember(dest => dest.Reporter, opt => opt.Ignore());
                config.CreateMap<Project, ProjectView>();

                config.CreateMap<Project, EditProjectViewModel>().ReverseMap();

            });
        }
    }
}
