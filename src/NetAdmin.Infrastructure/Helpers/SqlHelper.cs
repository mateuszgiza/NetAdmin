using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NetAdmin.Infrastructure
{
    public static class SqlHelper
    {
        #region - Constants -

        private const string ConnectionFormat = "Data Source={0};Initial Catalog={3};User ID={1};Password={2};";

        #endregion

        public static Task<TResponse> DoCommandOperationAsync<TResponse>(ConnectionInfo connectionInfo, string query,
            Action<TResponse, SqlDataReader> operation) where TResponse : BaseResponse, new()
        {
            return Task.FromResult(DoCommandOperation(connectionInfo, query, operation));
        }

        public static TResponse DoCommandOperation<TResponse>(ConnectionInfo connectionInfo, string query,
            Action<TResponse, SqlDataReader> operation) where TResponse : BaseResponse, new()
        {
            var response = new TResponse();

            try
            {
                using (var conn = new SqlConnection(GetConnectionString(connectionInfo)))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = query;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    using (reader)
                    {
                        operation(response, reader);
                    }
                }
            }
            catch (SqlException e)
            {
                response.Message = e.Message;
                response.State = ResponseState.Error;
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
                response.State = ResponseState.Error;
            }

            return response;
        }

        public static TResponse DoQueryOperation<TRequest, TResponse>(TRequest request,
            Action<TRequest, TResponse, SqlDataReader> operation)
            where TRequest : class, IDbRequest
            where TResponse : IResponse, new()
        {
            var response = new TResponse();

            try
            {
                using (var conn = new SqlConnection(GetConnectionString(request.Connection)))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = request.CommandText;

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    using (reader)
                    {
                        operation(request, response, reader);
                    }
                }
            }
            catch (SqlException e)
            {
                // TODO: Add logging
                //response.Message = e.Message;
                //response.State = ResponseState.Error;
            }
            catch (Exception e)
            {
                // TODO: Add logging
                //response.Message = e.ToString();
                //response.State = ResponseState.Error;
            }

            return response;
        }

        #region - Private methods -

        private static string GetConnectionString(ConnectionInfo connectionInfo)
        {
            var connectionString = string.Format(ConnectionFormat,
                connectionInfo.Hostname, connectionInfo.Username, connectionInfo.Password, connectionInfo.Database);

            return connectionString;
        }

        #endregion
    }
}