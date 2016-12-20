namespace NetAdmin.Log
{
    public enum LogType : byte
    {
        Info = 1,
        Warning = 1 << 1,
        Error = 1 << 2
    }
}