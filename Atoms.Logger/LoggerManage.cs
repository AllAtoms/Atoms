using Orm.Son.Core;

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
            using (var db = new Db())
            {
                return db.Insert(log);
            }
        }

        public enum LogLevel
        {
            Info = 1,
            Warn =2,
            Error =3,
            Fatal = 4,
            Monitor = 5,
            Exception =6
        }


    }
}
