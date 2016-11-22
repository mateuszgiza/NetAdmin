using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using NetAdmin.Helpers.Extensions;
using NetAdmin.Domain.Models;
using NetAdmin.Domain.Services.Interfaces;

namespace NetAdmin.Web.Controllers
{
    public class CommandController : Controller
    {
        private const string ConnectionFormat = "Data Source={0};Initial Catalog={3};User ID={1};Password={2};";

        private ICommandService _commandService;

        public CommandController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ConnectionModel();
            return View(model);
        }

        [HttpPost]
        public PartialViewResult GetTableData(ConnectionModel connection)
        {
            if (!Request.IsAjaxRequest())
                return null;

            var connectionString = string.Format(ConnectionFormat, connection.Hostname, connection.Username,
                connection.Password, connection.Database);

            var tableDataResponse = new TableData();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = connection.Query;

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

        public IActionResult GetDatabasesMenu()
        {
            return ViewComponent("DatabaseMenu");
        }

        public IActionResult GetTablesMenu()
        {
            return ViewComponent("TableMenu");
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