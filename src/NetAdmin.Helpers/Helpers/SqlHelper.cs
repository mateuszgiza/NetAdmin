using NetAdmin.Common.Enums;
using NetAdmin.Common.Responses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace NetAdmin.Helpers.Helpers
{
    public static class SqlHelper
    {
        public static Task<TResponse> DoCommandOperationAsync<TResponse>(Action<TResponse> operation) where TResponse : BaseResponse, new()
        {
            return Task.FromResult(DoCommandOperation(operation));
        }

        public static TResponse DoCommandOperation<TResponse>(ConnectionInfoAction<TResponse> operation) where TResponse : BaseResponse, new()
        {
            var response = new TResponse();

            try
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
                operation(response);
            }
            catch(SqlException e)
            {
                response.Message = e.Message;
                response.State = ResponseState.Error;
            }
            catch(Exception e)
            {
                response.Message = e.ToString();
                response.State = ResponseState.Error;
            }

            return response;
        }
    }
}
