using System;
using static Atoms.Logger.LoggerManage;

namespace Atoms.Logger
{
    public class Logger
    {
        internal static string DbConnName;
        internal static LoggerManage Logmgt = new LoggerManage();
        public static void Init(string dbConnStr)
        {
            DbConnName = dbConnStr;
            Logmgt.CheckOrCreateDb();
        }

        public static bool Info(string txt, string logType = "std", int userId = 0)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Info,
                LogUser = userId,
                AddTime = DateTime.Now,
                LogTxt = txt
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Warn(string txt, string logType = "std", int userId = 0)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Warn,
                LogUser = userId,
                AddTime = DateTime.Now,
                LogTxt = txt
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Error(string txt, string logType = "std", int userId = 0)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Error,
                LogUser = userId,
                AddTime = DateTime.Now,
                LogTxt = txt
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Fatal(string txt, string logType = "std", int userId = 0)
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Fatal,
                LogUser = userId,
                AddTime = DateTime.Now,
                LogTxt = txt
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Monitor(string logUrl = "", int userId = 0, double duration = 0, string logType = "monitor", string txt = "")
        {
            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Monitor,
                LogUser = userId,
                AddTime = DateTime.Now,
                LogTxt = txt,
                LogUrl = logUrl,
                Duration = duration
            };

            return Logmgt.Add(log) > 0;
        }

        public static bool Exception(Exception ex,string logUrl = "", string logType = "exception", int userId = 0, string txt = "")
        {
            var innerEx = ex.InnerException != null ? ex.InnerException.Message : "";

            var log = new AtomLogger()
            {
                LogType = logType,
                LogLevel = (int)LogLevel.Exception,
                LogUser = userId,
                AddTime = DateTime.Now,
                LogTxt = ex.Message+" | "+ innerEx,
                LogUrl = logUrl
            };

            return Logmgt.Add(log) > 0;
        }

    }
}
