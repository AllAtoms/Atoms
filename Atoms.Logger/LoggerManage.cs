using Orm.Son.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Atoms.Logger
{
    internal class LoggerManage
    {
        public bool CheckOrCreateDb()
        {
            using (var db = new Db())
            {
                return db.CreateTable<AtomLogger>();
            }
        }

        public long Add(AtomLogger log)
        {
            try
            {
                throw new Exception("这个有问题哦");
                var result = SonFact.Cur.Insert(log);
                return result;
            }
            catch (Exception e)
            {
                var errMsg = e.Message;
                var innerErr = e.InnerException != null ? e.InnerException.Message + " StackTrace: " + e.InnerException.StackTrace : "";
                SaveToFile("Error:" + errMsg + " InnerError:" + innerErr, 4);
                return 1;
            }

        }


        public static void SaveToFile(string content, int level)
        {
            try
            {
                var path = GetFilePath(level);
                var method = new StackTrace(true).GetFrame(2).GetMethod();
                var declaringType = method.DeclaringType;
                var nspace = declaringType != null ? declaringType.Namespace : string.Empty;
                var md = "<" + nspace + "." + method.Name + "> ";

                using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 1024, false))
                {
                    var time = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + "]");
                    var bty = Encoding.UTF8.GetBytes(time + md + content + "\r\n");
                    fs.Write(bty, 0, bty.Length);
                    fs.Close();
                }
            }
            catch
            {

            }
        }

        private static string GetFilePath(int level)
        {
            var logPath = AppDomain.CurrentDomain.BaseDirectory + "/Logs/";
            switch (level)
            {
                case 1:
                    logPath += "Info/"; break;
                case 2:
                    logPath += "Warn/"; break;
                case 3:
                    logPath += "Error/"; break;
                case 4:
                    logPath += "Fatal/"; break;
                case 5:
                    logPath += "Monitor/"; break;
                case 6:
                    logPath += "Exception/"; break;
            }
            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
            logPath += DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            return logPath;
        }

        public enum LogLevel
        {
            Info = 1,
            Warn = 2,
            Error = 3,
            Fatal = 4,
            Monitor = 5,
            Exception = 6
        }


    }
}
