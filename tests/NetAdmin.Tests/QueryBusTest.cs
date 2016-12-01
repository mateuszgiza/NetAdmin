using NetAdmin.Infrastructure;
using Xunit;
using Moq;
using System;

namespace NetAdmin.Tests
{
    public class QueryBusTest
    {
        [Fact]
        public void QueryBus_HandlesCorrectly()
        {
            var expected = "1,2,3";

            Func<Type, IHandleQuery> handlersFactory = t =>
            {
                var response = new GetDatabasesResponse { Databases = new[] { "1", "2", "3" } };
                var commandServiceMock = Mock.Of<CommandService>(m =>
                    m.GetDatabasesAsync(It.IsAny<GetDatabasesRequest>()) == response);
                return new SqlQueryHandler(commandServiceMock);
            };
            var queryBus = new QueryBus(handlersFactory);

            var sqlQuery = new SqlQuery
            {
                Hostname = "Host", 
                Port = 80,
                Database = "master",
                Username = "Admin",
                Password = "Admin123",
                Query = "SELECT * FROM dd;"
            };

            var result = queryBus.SendQuery(sqlQuery);

            Assert.Equal(expected, (result as SqlQueryResult).Data);
        }
    }
}
