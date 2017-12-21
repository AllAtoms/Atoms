using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atoms.Permission.Model;
using Orm.Son.Core;

namespace Atoms.Permission
{
    public class PermissionService
    {
        internal static string DbConnName;
        public static void Init(string connStr)
        {
            DbConnName = connStr;
            SonFact.init(connStr);
            PermissionDataCore.InitTables();
        }

        public static List<C_Permission> GetPermission(int userId)
        {
            var list = PermissionCacher.GetIfExist(userId);
            if (list.Any()) return list;
            var result = PermissionDataCore.GetPermission(userId);
            PermissionCacher.AddCache(userId, result);
            return result;
        }

        public static List<C_Permission> GetPermission(string roleCode)
        {
            var list = PermissionCacher.GetIfExist(roleCode);
            if (list.Any()) return list;
            var result = PermissionDataCore.GetPermission(roleCode);
            PermissionCacher.AddCache(roleCode, result);
            return result;
        }

        public static C_Role GetRole(int userId)
        {
            throw new NotImplementedException();
        }

        public static C_Role GetRole(string roleCode)
        {
            throw new NotImplementedException();
        }

        public static int AddPermission(C_Permission permission)
        {
            throw new NotImplementedException();
        }

        public static int AddRole(C_Role role)
        {
            throw new NotImplementedException();
        }

        public static int AddRolePermission(C_RolePermission rolePermission)
        {
            throw new NotImplementedException();
        }

        public static int AddUserRole(C_UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
