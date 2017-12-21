using Orm.Son.Core;

namespace Atoms.Configer
{
    internal class Db : SonConnection
    {
        public Db() : base(Configer.DbConnName)
        {
        }
    }
}
