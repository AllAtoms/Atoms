using System;
using static Atoms.Logger.LoggerManage;

namespace Atoms.Logger
{
    public class Logger
    {
        internal static string DbConnName;
        internal static LoggerManage Logmgt = new LoggerManage();
        internal static string ServerSrc = null;
        public static void Init(string dbConnStr,string serverSrc=null)
        {
            DbConnName = dbConnStr;
            ServerSrc = serverSrc; 
            Logmgt.CheckOrCreateDb();
        }

        public static bool Info(string txt, string logType = "std", string user = null)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Info,
                LogUser = user,
                AddTime = DateTime.Now,
                LogTxt = txt,
                ContentLength = 0,
                Duration =0,
                LogUrl = null,
                ServerSrc = ServerSrc
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Warn(string txt, string logType = "std", string user = null)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Warn,
                LogUser = user,
                AddTime = DateTime.Now,
                LogTxt = txt,
                ContentLength = 0,
                Duration = 0,
                LogUrl = null,
                ServerSrc = ServerSrc
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Error(string txt, string logType = "std", string user = null)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Error,
                LogUser = user,
                AddTime = DateTime.Now,
                LogTxt = txt,
                ContentLength = 0,
                Duration = 0,
                LogUrl = null,
                ServerSrc = ServerSrc
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Fatal(string txt, string logType = "std", string user = null)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Fatal,
                LogUser = user,
                AddTime = DateTime.Now,
                LogTxt = txt,
                ContentLength = 0,
                Duration = 0,
                LogUrl = null,
                ServerSrc = ServerSrc
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Monitor(string logUrl = "", string user = null, long contentSize=0 , long duration = 0, string logType = "monitor", string param = "")
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Monitor,
                LogUser = user,
                AddTime = DateTime.Now,
                LogTxt = param,
                LogUrl = logUrl,
                ContentLength = 0,
                Duration = duration,
                ServerSrc = ServerSrc
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Exception(Exception ex, string logType = "exception", string user = null, string txt = "")
        {
            var innerEx = ex.InnerException != null ? ex.InnerException.Message : "";

            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Exception,
                LogUser = user,
                AddTime = DateTime.Now,
                LogTxt = ex.Message+" | "+ innerEx,
                LogUrl = ex.StackTrace,
                ContentLength = 0,
                Duration = 0,
                ServerSrc = ServerSrc
            };

            return Logmgt.Add(log) > 0;
        }

    }
}
