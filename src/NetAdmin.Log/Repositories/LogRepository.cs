using System;
using System.Collections.Generic;
using System.Linq;
using NetAdmin.Log.Contexts;
using Newtonsoft.Json;

namespace NetAdmin.Log
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _db;

        public LogRepository(LogDbContext context)
        {
            _db = context;
        }

        public void Add(ILog entity)
        {
            var log = new Log
            {
                Type = entity.Type,
                LogObject = JsonConvert.SerializeObject(entity)
            };

            _db.Logs.Add(log);
            _db.SaveChanges();
        }

        public Log GetById(long id)
        {
            return _db.Logs.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Log> GetAll()
        {
            return _db.Logs;
        }

        public IEnumerable<Log> GetAll<TType>()
        {
            return GetAll(typeof(TType));
        }

        public IEnumerable<Log> GetAll(Type type)
        {
            var enumType = (LogType)Enum.Parse(typeof(LogType), type.Name);
            return _db.Logs.Where(l => l.Type == enumType);
        }
    }
}