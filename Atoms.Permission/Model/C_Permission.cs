using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Mapper;

namespace Atoms.Permission.Model
{
    public class C_Permission
    {
        [Description("权限Id")]
        public int Id { get; set; }

        [Description("权限类型(10模块,20操作权限,30特殊权限)")]
        public int Ptype { get; set; }
        [Description("上级权限代码")]
        public string ParentCode { get; set; }
        [Description("权限名称")]
        public string Name { get; set; }
        [Description("权限代码(规则：上级_模块名_功能名)")]
        public string Code { get; set; }
        [Description("权限图标")]
        public string Icon { get; set; }
        [Description("权限链接")]
        public string Url { get; set; }
        [Description("权限排序")]
        public int Sort { get; set; }

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
