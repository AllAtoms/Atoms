using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atoms.Permission.Model;
using Orm.Son.Core;

namespace Atoms.Permission
{
    internal class PermissionDataCore
    {

        public static void InitTables()
        {
            SonFact.Cur.CreateTable<C_Permission>();
            SonFact.Cur.CreateTable<C_Role>();
            SonFact.Cur.CreateTable<C_RolePermission>();
            SonFact.Cur.CreateTable<C_UserRole>();
        }

        public static List<C_Permission> GetPermission(int userId)
        {
            var sql = string.Format(@"select cp.* from C_Permission cp (nolock)
                                    inner join C_RolePermission crp (nolock) on cp.Code= crp.PermissionCode
                                    inner join C_Role cr (nolock) on crp.RoleCode = cr.Code 
                                    inner join C_UserRole cur (nolock) on cur.RoleCode = cr.Code 
                                    where cp.IsValid=1 and crp.IsValid=1 and cr.IsValid=1 and cur.IsValid=1 and cur.UserId = {0} order by cp.Sort desc", userId);
            var result = SonFact.Cur.ExecuteQuery<C_Permission>(sql);
            return result;
        }

        public static List<C_Permission> GetPermission(string roleCode)
        {
            var sql = string.Format(@"select cp.* from C_Permission cp (nolock)
                                    inner join C_RolePermission crp (nolock) on cp.Code= crp.PermissionCode
                                    inner join C_Role cr (nolock) on crp.RoleCode = cr.Code 
                                    where cp.IsValid=1 and crp.IsValid=1 and cr.IsValid=1 and cr.Code = '{0}' order by cp.Sort desc", roleCode);
            var result = SonFact.Cur.ExecuteQuery<C_Permission>(sql);
            return result;
        }

    }
}
