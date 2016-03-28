using System;
using NHibernate;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlanner.Projects.Domain;

namespace ProjectPlannerASP5.Models.Seeders
{
    public class ProjectPlannerSeedData
    {
        public void SeedData(ISession session)
        {
            if (session.QueryOver<Project>().SingleOrDefault() == null)
            {
                session.CreateSQLQuery(
                    @"SET IDENTITY_INSERT [dbo].[Projects] ON
INSERT INTO [dbo].[Projects] ([Id], [Version], [Code], [Name], [Description], [CreateTimeStamp], [LastUpdateTimeStamp], [Status], [CreatorUserId], [EntityStatus]) VALUES (1, N'2016-03-28 11:18:02', N'ATH', N'University of Bielsko-Biala', N'There are many variations of passages of Lorem Ipsum available, but 
the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look
even slightly believable.If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t 
anything embarrassing', N'2016-03-28 09:18:02', N'2016-03-28 09:18:02', 0, N'00000000-0000-0000-0000-000000000000', 0)
SET IDENTITY_INSERT [dbo].[Projects] OFF

INSERT INTO [dbo].[Issues] ([IssueNumber], [CreateTimeStamp], [DueDate], [LastUpdateTimeStamp], [Summary], [Description], [Status], [IssueStateStatus], [UserName], [EntityStatus], [Project_id]) VALUES (0, N'2016-03-28 09:18:02', NULL, N'2016-03-28 09:18:02', N'First Issue', N'Description', 0, 0, NULL, 0, 1)
INSERT INTO [dbo].[Issues] ([IssueNumber], [CreateTimeStamp], [DueDate], [LastUpdateTimeStamp], [Summary], [Description], [Status], [IssueStateStatus], [UserName], [EntityStatus], [Project_id]) VALUES (0, N'2015-03-25 09:18:02', N'2016-04-05 15:18:02', N'2015-03-25 09:18:02', N'Second Issue', N'Description', 0, 1, NULL, 0, 1)
INSERT INTO [dbo].[Issues] ([IssueNumber], [CreateTimeStamp], [DueDate], [LastUpdateTimeStamp], [Summary], [Description], [Status], [IssueStateStatus], [UserName], [EntityStatus], [Project_id]) VALUES (0, N'2015-07-06 09:18:02', N'2016-01-28 09:18:02', N'2015-07-06 09:18:02', N'Third Issue', N'Description', 0, 2, NULL, 0, 1)
INSERT INTO [dbo].[Issues] ([IssueNumber], [CreateTimeStamp], [DueDate], [LastUpdateTimeStamp], [Summary], [Description], [Status], [IssueStateStatus], [UserName], [EntityStatus], [Project_id]) VALUES (0, N'2016-02-15 09:18:02', N'2016-07-06 09:18:02', N'2016-02-15 09:18:02', N'Fourth Issue', N'Description', 0, 1, NULL, 0, 1)
INSERT INTO [dbo].[Issues] ([IssueNumber], [CreateTimeStamp], [DueDate], [LastUpdateTimeStamp], [Summary], [Description], [Status], [IssueStateStatus], [UserName], [EntityStatus], [Project_id]) VALUES (0, N'2016-03-01 09:18:02', NULL, N'2016-03-01 09:18:02', N'Fifth Issue', N'Description', 0, 0, NULL, 0, 1)
").ExecuteUpdate();
                session.Flush();
            }
        }
    }
}