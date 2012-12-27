// Type: ServiceStack.OrmLite.OrmLiteWriteConnectionExtensions
// Assembly: ServiceStack.OrmLite, Version=3.9.32.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\dev\Prototypes\GettingReady\GettingReady.Service\bin\ServiceStack.OrmLite.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace ServiceStack.OrmLite
{
    public static class OrmLiteWriteConnectionExtensions
    {
        public static bool TableExists(this IDbConnection dbConn, string tableName);
        public static void CreateTables(this IDbConnection dbConn, bool overwrite, params Type[] tableTypes);
        public static void CreateTableIfNotExists(this IDbConnection dbConn, params Type[] tableTypes);
        public static void DropAndCreateTables(this IDbConnection dbConn, params Type[] tableTypes);
        public static void CreateTable<T>(this IDbConnection dbConn) where T : new();
        public static void CreateTable<T>(this IDbConnection dbConn, bool overwrite) where T : new();
        public static void CreateTableIfNotExists<T>(this IDbConnection dbConn) where T : new();
        public static void DropAndCreateTable<T>(this IDbConnection dbConn) where T : new();
        public static void CreateTable(this IDbConnection dbConn, bool overwrite, Type modelType);
        public static void CreateTableIfNotExists(this IDbConnection dbConn, Type modelType);
        public static void DropAndCreateTable(this IDbConnection dbConn, Type modelType);
        public static void DropTables(this IDbConnection dbConn, params Type[] tableTypes);
        public static void DropTable(this IDbConnection dbConn, Type modelType);
        public static void DropTable<T>(this IDbConnection dbConn) where T : new();
        public static string GetLastSql(this IDbConnection dbConn);
        public static int ExecuteSql(this IDbConnection dbConn, string sql);
        public static void Update<T>(this IDbConnection dbConn, params T[] objs) where T : new();
        public static void UpdateAll<T>(this IDbConnection dbConn, IEnumerable<T> objs) where T : new();
        public static void Delete<T>(this IDbConnection dbConn, params T[] objs) where T : new();
        public static void DeleteAll<T>(this IDbConnection dbConn, IEnumerable<T> objs) where T : new();
        public static void DeleteById<T>(this IDbConnection dbConn, object id) where T : new();
        public static void DeleteByIds<T>(this IDbConnection dbConn, IEnumerable idValues) where T : new();
        public static void DeleteAll<T>(this IDbConnection dbConn);
        public static void DeleteAll(this IDbConnection dbConn, Type tableType);
        public static void Delete<T>(this IDbConnection dbConn, string sqlFilter, params object[] filterParams) where T : new();
        public static void Delete(this IDbConnection dbConn, Type tableType, string sqlFilter, params object[] filterParams);
        public static void Save<T>(this IDbConnection dbConn, T obj) where T : new();
        public static void Insert<T>(this IDbConnection dbConn, params T[] objs) where T : new();
        public static void InsertAll<T>(this IDbConnection dbConn, IEnumerable<T> objs) where T : new();
        public static void Save<T>(this IDbConnection dbConn, params T[] objs) where T : new();
        public static void SaveAll<T>(this IDbConnection dbConn, IEnumerable<T> objs) where T : new();
        public static IDbTransaction BeginTransaction(this IDbConnection dbConn);
        public static IDbTransaction BeginTransaction(this IDbConnection dbConn, IsolationLevel isolationLevel);
        public static void ExecuteProcedure<T>(this IDbConnection dbConn, T obj);
    }
}
