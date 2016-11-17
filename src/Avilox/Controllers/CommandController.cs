using System;
using System.Data.SqlClient;
using Avilox.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avilox.Controllers
{
    public class CommandController : Controller
    {
        private const string CONNECTION_FORMAT = "Data Source={0};Initial Catalog={3};User ID={1};Password={2};";

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ConnectionModel { Result = "Fill boxes" };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ConnectionModel connection)
        {
            string connectionString = string.Format(CONNECTION_FORMAT, connection.HostName, connection.Username, connection.Password, connection.Database);

            try 
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = connection.Query;

                    conn.Open();
                    connection.Result = cmd.ExecuteReader().ToString();
                }
            }
            catch(Exception e)
            {
                connection.Result = e.ToString();
            }

            return View(connection);
        }
    }
}