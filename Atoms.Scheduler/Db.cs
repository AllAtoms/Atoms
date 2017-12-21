using Orm.Son.Core;

namespace Atoms.Scheduler
{
    internal class Db : SonConnection
    {
        public Db() : base(Scheduler.DbConnName)
        {
        }
    }
}
