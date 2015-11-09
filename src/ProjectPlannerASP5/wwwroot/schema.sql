
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19D44C65F894640E]') AND parent_object_id = OBJECT_ID('Issues'))
alter table Issues  drop constraint FK19D44C65F894640E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C1C7FE5F894640E]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK2C1C7FE5F894640E


    if exists (select * from dbo.sysobjects where id = object_id(N'Issues') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Issues

    if exists (select * from dbo.sysobjects where id = object_id(N'Projects') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Projects

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table Issues (
        Id INT IDENTITY NOT NULL,
       Version DATETIME not null,
       IssueNumber INT null,
       CreateDate datetime2 null,
       DueDate DATETIME null,
       LastChangeDate datetime2 null,
       Summary NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Status INT null,
       UserName NVARCHAR(255) null,
       EntityStatus INT null,
       Project_id INT null,
       primary key (Id)
    )

    create table Projects (
        Id INT IDENTITY NOT NULL,
       Version DATETIME not null,
       Code NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       CreateDate datetime2 null,
       Status INT null,
       CreatorUserId UNIQUEIDENTIFIER null,
       EntityStatus INT null,
       primary key (Id)
    )

    create table Users (
        Project_id INT not null,
       Value NVARCHAR(255) null
    )

    alter table Issues 
        add constraint FK19D44C65F894640E 
        foreign key (Project_id) 
        references Projects

    alter table Users 
        add constraint FK2C1C7FE5F894640E 
        foreign key (Project_id) 
        references Projects
