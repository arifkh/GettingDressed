// Type: ServiceStack.OrmLite.OrmLiteConnectionFactory
// Assembly: ServiceStack.OrmLite, Version=3.9.32.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\dev\Prototypes\GettingReady\packages\ServiceStack.OrmLite.Sqlite32.3.9.32\lib\net40\ServiceStack.OrmLite.dll

using System;
using System.Collections.Generic;
using System.Data;

namespace ServiceStack.OrmLite
{
    public class OrmLiteConnectionFactory : IDbConnectionFactory
    {
        public OrmLiteConnectionFactory();
        public OrmLiteConnectionFactory(string connectionString);
        public OrmLiteConnectionFactory(string connectionString, bool autoDisposeConnection);
        public OrmLiteConnectionFactory(string connectionString, IOrmLiteDialectProvider dialectProvider);
        public OrmLiteConnectionFactory(string connectionString, bool autoDisposeConnection, IOrmLiteDialectProvider dialectProvider);
        public OrmLiteConnectionFactory(string connectionString, bool autoDisposeConnection, IOrmLiteDialectProvider dialectProvider, bool setGlobalConnection);
        public IOrmLiteDialectProvider DialectProvider { get; set; }
        public string ConnectionString { get; set; }
        public bool AutoDisposeConnection { get; set; }
        public System.Func<IDbConnection, IDbConnection> ConnectionFilter { get; set; }
        public IDbCommand AlwaysReturnCommand { get; set; }
        public IDbTransaction AlwaysReturnTransaction { get; set; }
        public Action<OrmLiteConnection> OnDispose { get; set; }
        public static Dictionary<string, OrmLiteConnectionFactory> NamedConnections { get; }

        #region IDbConnectionFactory Members

        public IDbConnection OpenDbConnection();
        public IDbConnection CreateDbConnection();

        #endregion

        public IDbConnection OpenDbConnection(string connectionKey);
        public void RegisterConnection(string connectionKey, string connectionString, IOrmLiteDialectProvider dialectProvider, bool autoDisposeConnection = true);
    }
}
