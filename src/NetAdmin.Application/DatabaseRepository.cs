using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using NetAdmin.Infrastructure;

namespace NetAdmin.Application
{
    public class DatabaseRepository
    {
        private readonly IMemoryCache _memoryCache;

        public DatabaseRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public DatabaseList GetDatabaseList(GetDatabasesRequest request)
        {
            const string query = "SELECT name FROM sys.databases;";
            var dbRequest = new CommonDbRequest
            {
                Connection = ResolveConnectionWithCache(request.Connection),
                CommandText = query
            };

            return SqlHelper.DoQueryOperation<CommonDbRequest, DatabaseList>(dbRequest, (req, response, reader) =>
            {
                var databaseList = new List<string>();

                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    databaseList.Add(name);
                }

                response.Databases = databaseList;
                //response.State = ResponseState.Success;
            });
        }

        public TableList GetTableList(GetTablesRequest request)
        {
            const string query = "SELECT table_name from INFORMATION_SCHEMA.tables;";
            request.Connection.Database = request.Database;
            var dbRequest = new CommonDbRequest
            {
                Connection = ResolveConnectionWithCache(request.Connection),
                CommandText = query
            };

            return SqlHelper.DoQueryOperation<CommonDbRequest, TableList>(dbRequest, (req, response, reader) =>
            {
                var tableList = new List<string>();

                while (reader.Read())
                {
                    var name = reader.GetValue(0).ToString();
                    tableList.Add(name);
                }

                response.Tables = tableList;
            });
        }

        private ConnectionInfo ResolveConnectionWithCache(ConnectionInfo connection)
        {
            const string cacheKeyName = "connection";

            return _memoryCache.GetOrCreate(cacheKeyName, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(30);
                return connection;
            });
        }
    }
}