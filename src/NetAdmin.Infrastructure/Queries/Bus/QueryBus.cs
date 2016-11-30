using System;

namespace NetAdmin.Infrastructure
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IHandleQuery> _handlersFactory;

        public QueryBus(Func<Type, IHandleQuery> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public IQueryResult SendQuery<TQuery>(TQuery query) where TQuery : IQuery
        {
            var handler = (IHandleQuery<TQuery>) _handlersFactory(typeof(TQuery));
            var result = handler.Handle(query);
            
            return result;
        }
    }
}