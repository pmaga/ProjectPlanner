﻿using System;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ProjectPlanner.Infrastructure.Orm.Conventions;
using ProjectPlanner.Infrastructure.Orm.Interceptors;

namespace ProjectPlanner.Infrastructure.Orm
{//TODO: Zweryfikowac mapowania (na bazie)
    public class EntityManager : IEntityManager
    {
        private readonly IPerRequestSessionFactory _perRequestSessionFactory;
        private ISession _currentSession;

        private static readonly Lazy<ISessionFactory> NHibernateSessionFactory =
            new Lazy<ISessionFactory>(() =>
            {
                var config = Configure();
                var factory = config.BuildSessionFactory();

                using (var session = factory.OpenSession(new CreateAndModifiedDateInterceptor()))
                {
                    SeedData(session);
                    session.Flush();
                }
                return factory;
            });

        public static Action<ISession> SeedData = s => { };
        public static Func<Assembly[]> GetAssemblies = () => new Assembly[0];

        public ISession CurrentSession
        {
            get
            {
                if (_currentSession == null)
                {
                    _currentSession = SessionFactory.OpenSession(new CreateAndModifiedDateInterceptor());
                }
                return _currentSession;
            }
        }

        public static ISessionFactory SessionFactory => NHibernateSessionFactory.Value;

        public EntityManager(IPerRequestSessionFactory perRequestSessionFactory)
        {
            _perRequestSessionFactory = perRequestSessionFactory;
        }

        private static Configuration Configure()
        {
            var config = Fluently.Configure()
                .Database(() =>
                {
                    return MsSqlConfiguration.MsSql2012.ConnectionString(
                        c =>
                        {
                            c.Server(".").Database("ProjectPlannerDb")
                                .Username("pawel")
                                .Password("sa");
                        });
                })
                .Mappings(m =>
                {
                    var autoPersistenceModel = AutoMap.Assemblies(new AutomappingConfiguration(), GetAssemblies());
                    autoPersistenceModel.Conventions.Add(new SqlEnumTypeConvention());
                    autoPersistenceModel.Conventions.Add(new UseNewSqlDateTime2TypeConvention());
                    autoPersistenceModel.Conventions.Add(new CollectionAccessConvention());
                    autoPersistenceModel.Conventions.Add(new SqlTimestampConvention());
                    autoPersistenceModel.Conventions.Add(new SqlTableNameConvention());
                    autoPersistenceModel.Conventions.Add(new DefaultStringLengthConvention());
                    autoPersistenceModel.Conventions.Add(DefaultLazy.Never());
                    
                    m.AutoMappings.Add(autoPersistenceModel);
                })
                .BuildConfiguration();


            var schema = new SchemaExport(config);
            schema.SetOutputFile("schema.sql");
            schema.Execute(true, true, false);

            return config;
        }
    }
}
