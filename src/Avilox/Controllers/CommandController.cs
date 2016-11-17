using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Avilox.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avilox.Controllers
{
    public class CommandController : Controller
    {
        private const string ConnectionFormat = "Data Source={0};Initial Catalog={3};User ID={1};Password={2};";

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ConnectionModel { Error = "Fill boxes" };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ConnectionModel connection)
        {
            var connectionString = string.Format(ConnectionFormat, connection.Hostname, connection.Username,
                connection.Password, connection.Database);

            try 
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = connection.Query;

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var table = ConvertToTableCollection(reader);
                    connection.FieldNames = table.Item1;
                    connection.Result = table.Item2;
                }
            }
            catch(Exception e)
            {
                connection.Error = e.ToString();
            }

            return View(connection);
        }

        private static Tuple<IEnumerable<string>, IEnumerable<IEnumerable<string>>> ConvertToTableCollection(IDataReader reader)
        {
            var collection = new List<IEnumerable<string>>(10);
            var names = ReadFieldNames(reader);
            
            while (reader.Read())
            {
                var fields = new List<string>(10);

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var line = reader.GetValue(i).ToString();
                    fields.Add(line);
                }
                
                collection.Add(fields);
            }

            var tuple = new Tuple<IEnumerable<string>, IEnumerable<IEnumerable<string>>>(names, collection);
            return tuple;
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