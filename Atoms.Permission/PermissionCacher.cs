using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Atoms.Permission.Model;

namespace Atoms.Permission
{
    public class PermissionCacher
    {
        public static List<C_Permission> GetIfExist(int userId)
        {
            var key = "core_permission_key_uid_" + userId;
            var cache = HttpRuntime.Cache;
            if (cache[key] == null) return new List<C_Permission>();
            return cache[key] as List<C_Permission>;
        }

        public static void AddCache(int userId, List<C_Permission> cps)
        {
            var key = "core_permission_key_uid_" + userId;
            var cache = HttpRuntime.Cache;
            var timeSpan = new TimeSpan(0, 5, 0);
            cache.Insert(key, cps, null, DateTime.MaxValue, timeSpan);
        }

        public static List<C_Permission> GetIfExist(string roleCode)
        {
            var key = "core_permission_key_rcode_" + roleCode;
            var cache = HttpRuntime.Cache;
            if (cache[key] == null) return new List<C_Permission>();
            return cache[key] as List<C_Permission>;
        }

        public static void AddCache(string roleCode, List<C_Permission> cps)
        {
            var key = "core_permission_key_rcode_" + roleCode;
            var cache = HttpRuntime.Cache;
            var timeSpan = new TimeSpan(0, 5, 0);
            cache.Insert(key, cps, null, DateTime.MaxValue, timeSpan);
        }
    }
}
