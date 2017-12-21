using Orm.Son.Core;

namespace Atoms.Logger
{
    internal class Db : SonConnection
    {
        public Db() : base(Logger.DbConnName)
        {
        }
    }
}
