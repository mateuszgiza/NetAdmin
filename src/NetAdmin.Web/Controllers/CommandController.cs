using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Application;
using NetAdmin.Infrastructure;

namespace NetAdmin.Web
{
    //[Authorize]
    public class CommandController : Controller
    {
        private readonly ICommandService _commandService;

        public CommandController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        public JsonResult GetDatabases([FromBody] ConnectionInfo connection)
        {
            var result = _commandService.GetDatabases(connection);
            return Json(new {databases = result.Databases});
        }

        [HttpPost]
        public JsonResult GetTables([FromBody] ConnectionInfo connection)
        {
            var result = _commandService.GetTables(connection, connection.Database);
            return Json(new {tables = result.Tables});
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
                    cmd.CommandText = ""; // connection.Query;

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
            catch (Exception e)
            {
                tableDataResponse.Error = e.ToString();
            }

            return PartialView("Partials/GetTableData", tableDataResponse);
        }

        private static (IEnumerable<string> names, IEnumerable<IEnumerable<string>> rows) ConvertToTableCollection(
            IDataReader reader)
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
                names.Add(reader.GetName(i));

            return names;
        }
    }
}