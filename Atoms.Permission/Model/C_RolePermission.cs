﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Mapper;

namespace Atoms.Permission.Model
{
    public class C_RolePermission
    {
        [Description("角色权限Id")]
        public int Id { get; set; }

        [Description("权限代码")]
        public string PermissionCode { get; set; }
        [Description("角色代码")]
        public string RoleCode { get; set; }

        [Description("添加时间")]
        public DateTime AddTime { get; set; }
        [Description("添加人")]
        public int AddUser { get; set; }
        [Description("编辑时间")]
        public DateTime EditTime { get; set; }
        [Description("编辑人")]
        public int EditUser { get; set; }
        [Description("是否可用")]
        public bool IsValid { get; set; }
    }
}
