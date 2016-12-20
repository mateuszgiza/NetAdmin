﻿namespace NetAdmin.Infrastructure
{
    public interface IDbRequest : IRequest
    {
        ConnectionInfo Connection { get; }
        string CommandText { get; }
    }
}