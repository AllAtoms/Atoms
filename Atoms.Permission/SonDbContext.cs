using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Core;

namespace Atoms.Permission
{
    internal class SonDbContext : SonConnection
    {
        public SonDbContext() : base(PermissionService.DbConnName)
        {
        }
    }
}
