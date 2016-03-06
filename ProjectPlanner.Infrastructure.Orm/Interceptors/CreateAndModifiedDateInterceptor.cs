using NHibernate;
using NHibernate.Type;
using System;

namespace ProjectPlanner.Infrastructure.Orm.Interceptors
{
    public class CreateAndModifiedDateInterceptor : EmptyInterceptor
    {
        private const string CreateTimeStampName = "CreateTimeStamp";
        private const string LastUpdateimeStampName = "LastUpdateTimeStamp";

        public override bool OnFlushDirty(object entity,
                                          object id,
                          object[] currentState,
                          object[] previousState,
                          string[] propertyNames,
                          IType[] types)
        {
            for (int i = 0; i < propertyNames.Length; i++)
            {
                if (LastUpdateimeStampName.Equals(propertyNames[i]))
                {
                    currentState[i] = DateTime.UtcNow;
                    return true;
                }
            }
            return false;
        }

        public override bool OnSave(object entity,
                                    object id,
                    object[] state,
                    string[] propertyNames,
                    IType[] types)
        {
            var createDateModified = false;
            var lastUpdateDateModified = false;

            for (int i = 0; i < propertyNames.Length; i++)
            {
                if (CreateTimeStampName.Equals(propertyNames[i]))
                {
                    state[i] = DateTime.UtcNow;
                    createDateModified = true;
                    continue;
                }
                if (LastUpdateimeStampName.Equals(propertyNames[i]))
                {
                    state[i] = DateTime.UtcNow;
                    lastUpdateDateModified = true;
                }
            }

            if (createDateModified && lastUpdateDateModified)
            {
                return true;
            }

            return false;
        }
    }
}
