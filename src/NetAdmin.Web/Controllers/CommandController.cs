using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Application;
using NetAdmin.Infrastructure;
using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Redis;

namespace NetAdmin.Web
{
    //[Authorize]
    public class CommandController : Controller
    {
        private readonly ICommandService _commandService;
        private readonly IRedisClientsManager _redisClientsManager;

        public CommandController(ICommandService commandService, IRedisClientsManager redisClientsManager)
        {
            _commandService = commandService;
            _redisClientsManager = redisClientsManager;
        }

        [HttpPost]
        public JsonResult GetDatabases([FromBody] ConnectionInfo connection)
        {
            var result = _commandService.GetDatabases(connection);
            return Json(new { databases = result.Databases });
        }

        [HttpPost]
        public JsonResult GetTables([FromBody] ConnectionInfo connection)
        {
            var result = _commandService.GetTables(connection, connection.Database);
            return Json(new { tables = result.Tables });
        }

        [HttpPost]
        public PartialViewResult GetTableData(ConnectionInfo connection)
        {
            if (!Request.IsAjaxRequest())
                return null;
            
            var tableDataResponse = new TableData();

            try
            {
                using (var conn = new SqlConnection(""))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "";// connection.Query;

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var table = ConvertToTableCollection(reader);
                    tableDataResponse.FieldNames = table.Item1;
                    tableDataResponse.Result = table.Item2;
                    tableDataResponse.RowsAffected = reader.RecordsAffected;
                }
            }
            catch (SqlException e)
            {
                tableDataResponse.Error = e.Message;
            }
            catch(Exception e)
            {
                tableDataResponse.Error = e.ToString();
            }

            return PartialView("Partials/GetTableData", tableDataResponse);
        }

        [HttpGet]
        public JsonResult GetConnections(string name)
        {
            string accessKey = $"userDbConnection:{name}";

            using (var redis = _redisClientsManager.GetClient())
            {
                var userdbs = redis.GetAllItemsFromList(accessKey)
                    .Map(JsonConvert.DeserializeObject<UserDbConnection>);

                return Json(userdbs);
            }
        }

        [HttpGet]
        public JsonResult Fill(string name)
        {
            string accessKey = $"userDbConnection:{name}";

            using (var redis = _redisClientsManager.GetClient())
            {
                var db1 = new UserDbConnection
                {
                    Host = "Host1@host1.com",
                    Username = "user1",
                    Password = "pwd1_hashed"
                };
                redis.AddItemToList(accessKey, db1.ToJson());
                
                var db2 = new UserDbConnection
                {
                    Host = "Host2@host2.com",
                    Username = "user22",
                    Password = "pwd2_hashed"
                };
                redis.AddItemToList(accessKey, db2.ToJson());

                var db3 = new UserDbConnection
                {
                    Host = "Host3@host3.com",
                    Username = "user333",
                    Password = "pwd3_hashed"
                };
                redis.AddItemToList(accessKey, db3.ToJson());

                return Json("OK");
            }
        }

        private class UserDbConnection
        {
            public string Host { get; set; }
            public int Port { get; set; } = 6379;
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private static (IEnumerable<string> names, IEnumerable<IEnumerable<string>> rows) ConvertToTableCollection(IDataReader reader)
        {
            var rows = new List<IEnumerable<string>>(10);
            var names = ReadFieldNames(reader);

            while (reader.Read())
            {
                var fields = new List<string>(10);

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var line = reader.GetValue(i).ToString();
                    fields.Add(line);
                }

                rows.Add(fields);
            }

            return (names, rows);
        }

        private static IEnumerable<string> ReadFieldNames(IDataRecord reader)
        {
            var names = new List<string>(10);
            
            for (var i = 0; i < reader.FieldCount; i++)
            {
                names.Add(reader.GetName(i));
            }

            return names;
        }
    }
}