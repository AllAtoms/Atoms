using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Mapper;

namespace Atoms.Permission.Model
{
    public class C_Role
    {
        [Description("角色Id")]
        public int Id { get; set; }

        [Description("角色名称")]
        public string Name { get; set; }
        [Description("角色代码")]
        public string Code { get; set; }
        [Description("角色类型（如：acd/cpd）")]
        public int Rtype { get; set; }

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
