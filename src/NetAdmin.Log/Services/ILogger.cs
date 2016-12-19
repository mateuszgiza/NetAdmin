namespace NetAdmin.Log
{
    public interface ILogger
    {
        void Log(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}