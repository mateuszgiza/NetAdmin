using NetAdmin.Common.Responses;
using NetAdmin.Domain.Services.Interfaces;
using System.Threading.Tasks;
using System;
using NetAdmin.Domain.Models;
using System.Data.SqlClient;
using NetAdmin.Common.Enums;
using System.Collections.Generic;
using NetAdmin.Helpers.Helpers;

namespace NetAdmin.Domain.Services
{
    public class CommandService : ICommandService
    {
        private const string ConnectionFormat = "Data Source={0};Initial Catalog={3};User ID={1};Password={2};";

        public async Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo)
        {
            const string databaseQuery = "SELECT name FROM sys.databases;";

            return await SqlHelper.DoCommandOperationAsync<DatabaseListResponse>(response =>
            {
                using (var conn = new SqlConnection(GetConnectionString(connectionInfo)))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = databaseQuery;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    var databaseList = new List<string>();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetValue(0).ToString();
                            databaseList.Add(name);
                        }
                    }

                    response.Databases = databaseList;
                    response.State = ResponseState.Success;
                }
            });
        }

        public async Task<TableListResponse> GetTablesAsync(ConnectionInfo connectionInfo)
        {
            const string databaseQuery = "SELECT name FROM sys.tables;";

            var tableResponse = new TableListResponse();

            try
            {
                using (var conn = new SqlConnection(GetConnectionString(connectionInfo)))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = databaseQuery;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    var tableList = new List<string>();

                    using (reader) {
                        while(reader.Read()) {
                            var name = reader.GetValue(0).ToString();
                            tableList.Add(name);
                        }
                    }

                    tableResponse.Tables = tableList;
                }
            }
            catch (SqlException e)
            {
                tableResponse.Message = e.Message;
                tableResponse.State = ResponseState.Error;
            }
            catch(Exception e)
            {
                tableResponse.Message = e.ToString();
                tableResponse.State = ResponseState.Error;
            }

            return tableResponse;
        }

        private string GetConnectionString(ConnectionInfo connectionInfo)
        {
            var connectionString = string.Format(ConnectionFormat,
                connectionInfo.Hostname, connectionInfo.Username, connectionInfo.Password, connectionInfo.Database);

            return connectionString;
        }
    }
}
