using Orm.Son.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atoms.Scheduler
{
    internal class AtomSchedule
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string Descriptions { get; set; }
        public string JobUrl { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Cron { get; set; }
        public DateTime AddTime { get; set; }
        [Description("状态 1正常 2添加中 3删除中 4已删除")]
        public int State { get; set; }
    }
}
