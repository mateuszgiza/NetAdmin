using Xunit;
// using NetAdmin.Infrastructure;

namespace NetAdmin.Tests
{
    public class SqlQueryTest
    {
        // private readonly IQueryBus queryBus;

        // public SqlQueryTest(IQueryBus queryBus)
        // {
        //     this.queryBus = queryBus;
        // }

        // [Fact]
        // public void SqlQueryTest_ExecutesCorrectly()
        // {
        //     var sqlQuery = new SqlQuery {
        //         Hostname = "Host",
        //         Port = 80,
        //         Database = "master",
        //         Username = "Admin",
        //         Password = "Admin123",
        //         Query = "SELECT * FROM dd;"
        //     };

        //     var result = queryBus.SendQuery(sqlQuery);

        //     Assert.True(true, (result as SqlQueryResult).Data);
        // }

        [Fact]
        public void Test1()
        {
            Assert.True(true, "elo");
        }
    }
}