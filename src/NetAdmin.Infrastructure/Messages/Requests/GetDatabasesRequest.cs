﻿using NetAdmin.Common.Abstractions;

namespace NetAdmin.Infrastructure
{
    public class GetDatabasesRequest : IRequest
    {
        public ConnectionInfo Connection { get; set; }
    }
}