﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ProjectPlanner.Infrastructure.Orm.Conventions
{
    public class SqlTimestampConvention : IVersionConvention
    {
        public void Apply(IVersionInstance instance)
        {
            if (instance.Type.Name == "BinaryBlob")
            {
                instance.Nullable();
                instance.CustomSqlType("timestamp");
                instance.Generated.Always();
            }
        }
    }
}
