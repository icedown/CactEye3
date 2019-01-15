
using System.Text;
using UnityEngine;

namespace CactEye3
{
    class Log : Singleton<Log>
    {
        public LogLevel CurrentLogLevel = LogLevel.DEBUG;

        public void LogEntry(string msg, LogLevel level)
        {
            if(level > CurrentLogLevel)
            {
                return;
            }
            StringBuilder logEntry = new StringBuilder();
            logEntry.Append("CactEye3: ");
            switch (level)
            {
                case LogLevel.CRITICAL:
                    logEntry.Append("CRITICAL: ");
                    break;

                case LogLevel.ERROR:
                    logEntry.Append("ERROR: ");
                    break;

                case LogLevel.WARNING:
                    logEntry.Append("WARNING: ");
                    break;

                case LogLevel.INFO:
                    logEntry.Append("INFO: ");
                    break;

                case LogLevel.DEBUG:
                    logEntry.Append("DEBUG: ");
                    break;
            }

            logEntry.Append(msg);

            if(level == LogLevel.WARNING)
            {
                Debug.LogWarning(logEntry.ToString());
            }
            else if(level == LogLevel.ERROR || level == LogLevel.CRITICAL)
            {
                Debug.LogWarning(logEntry.ToString());
            }
            else
            {
                Debug.Log(logEntry.ToString());
            }
        }
        
    }

    public enum LogLevel
    {
        CRITICAL = 0,
        ERROR = 1,
        WARNING = 2,
        INFO = 3,
        DEBUG = 4 
    }

}
