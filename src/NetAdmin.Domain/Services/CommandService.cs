using NetAdmin.Domain.Responses;
using NetAdmin.Domain.Services.Interfaces;
using System.Threading.Tasks;
using System;
using NetAdmin.Domain.Models;
using System.Data.SqlClient;
using NetAdmin.Domain.Enums;
using System.Collections.Generic;

namespace NetAdmin.Domain.Services
{
    public class CommandService : ICommandService
    {
        private const string ConnectionFormat = "Data Source={0};Initial Catalog={3};User ID={1};Password={2};";

        public async Task<DatabaseListResponse> GetDatabasesAsync(ConnectionInfo connectionInfo)
        {
            const string databaseQuery = "SELECT name FROM sys.databases;";

            var databaseResponse = new DatabaseListResponse();

            try
            {
                using (var conn = new SqlConnection(GetConnectionString(connectionInfo)))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = databaseQuery;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    var databaseList = new List<string>();

                    using (reader) {
                        while(reader.Read()) {
                            var name = reader.GetValue(0).ToString();
                            databaseList.Add(name);
                        }
                    }

                    databaseResponse.Databases = databaseList;
                }
            }
            catch (SqlException e)
            {
                databaseResponse.Message = e.Message;
                databaseResponse.State = ResponseState.Error;
            }
            catch(Exception e)
            {
                databaseResponse.Message = e.ToString();
                databaseResponse.State = ResponseState.Error;
            }

            return databaseResponse;
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
